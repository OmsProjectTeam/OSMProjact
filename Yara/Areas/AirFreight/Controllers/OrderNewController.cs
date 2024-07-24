using Domin.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Yara.Areas.AirFreight.Controllers
{
    [Area("AirFreight")]
    [Authorize(Roles = "Admin,AirFreight")]
    public class OrderNewController : Controller
    {
        IIOrderNew iOrderNew;
        IIOrderCase iOrderCase;
        IIOrderStatus iOrderStatus;
        IIClintWitheDeliveryTariffs iClintWitheDeliveryTariffs;
        MasterDbcontext dbcontext;
        IIShippingPrice iShippingPrice;
        UserManager<ApplicationUser> _userManager;
        IIExchangeRate iExchangeRate;
        IICurrenciesExchangeRates iCurrenciesExchangeRates;
        public OrderNewController(IIOrderNew iOrderNew1, IIOrderCase iOrderCase1, IIOrderStatus iOrderStatus1, IIClintWitheDeliveryTariffs iClintWitheDeliveryTariffs1, MasterDbcontext dbcontext1, IIShippingPrice iShippingPrice1, UserManager<ApplicationUser> userManager,IIExchangeRate iExchangeRate1, IICurrenciesExchangeRates iCurrenciesTransactions1)
        {
            iOrderNew = iOrderNew1;
            iOrderCase = iOrderCase1;
            iOrderStatus = iOrderStatus1;
            iClintWitheDeliveryTariffs = iClintWitheDeliveryTariffs1;
            dbcontext = dbcontext1;
            iShippingPrice = iShippingPrice1;
            _userManager = userManager;
            iExchangeRate= iExchangeRate1;
            iCurrenciesExchangeRates = iCurrenciesTransactions1;
        }
        public async Task<IActionResult> MyOrderNew(string? userId)

        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrderNew = iOrderNew.GetAllDataentry(user.UserName);
            return View(vmodel);
        }

        public async Task<IActionResult> MyOrderNewAr()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrderNew = iOrderNew.GetAllDataentry(user.UserName);
            return View(vmodel);
        }
        public async Task<IActionResult> AddOrderNew(int? IdOrderNew)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            var clintDeliveryTariff = await dbcontext.ViewInformationCompanies
                .Where(t => t.EmailCompany == user.Email)
                .ToListAsync();

            var shippingPriceSelectList = clintDeliveryTariff.Select(t => new SelectListItem
            {
                Value = t.IdInformationCompanies.ToString(), // تحويل القيمة إلى نص
                Text = t.NikeNAme
            }).ToList();
            var ordersttuse= dbcontext.order_status.Where(t => t.Id== 1037 ).ToList();

            var order = ordersttuse.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(), // تحويل القيمة إلى نص
                Text = t.Description
            }).ToList();

            ViewBag.OrderStatus = new SelectList(order, "Value", "Text");
          //  ViewBag.OrderStatus = iOrderStatus.GetAll();


            ViewBag.ShippingPrice = new SelectList(shippingPriceSelectList, "Value", "Text");



            ViewBag.OrderCase = iOrderCase.GetAll();
         
            ViewBag.ClintWith = iClintWitheDeliveryTariffs.GetAll();
          //  ViewBag.ShippingPrice = iShippingPrice.GetAll(); // قد يكون لديك خطأ هنا لأنك قمت بتعيين نفس الخاصية مرتين
            ViewBag.exch = iExchangeRate.GetAll();
            ViewBag.Currenc = iCurrenciesExchangeRates.GetAll();

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrderNew = iOrderNew.GetAll();
            if (IdOrderNew != null)
            {
                vmodel.OrderNew = iOrderNew.GetById(Convert.ToInt32(IdOrderNew));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }




        public async Task<IActionResult> AddOrderNewAr(int? IdOrderNew)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            var clintDeliveryTariff = await dbcontext.ViewInformationCompanies
                .Where(t => t.EmailCompany == user.Email)
                .ToListAsync();

            var shippingPriceSelectList = clintDeliveryTariff.Select(t => new SelectListItem
            {
                Value = t.IdInformationCompanies.ToString(), // تحويل القيمة إلى نص
                Text = t.NikeNAme
            }).ToList();

            ViewBag.ShippingPrice = new SelectList(shippingPriceSelectList, "Value", "Text");



            ViewBag.OrderCase = iOrderCase.GetAll();
            ViewBag.OrderStatus = iOrderStatus.GetAll();
            ViewBag.ClintWith = iClintWitheDeliveryTariffs.GetAll();
            //  ViewBag.ShippingPrice = iShippingPrice.GetAll(); // قد يكون لديك خطأ هنا لأنك قمت بتعيين نفس الخاصية مرتين
            ViewBag.exch = iExchangeRate.GetAll();
            ViewBag.Currenc = iCurrenciesExchangeRates.GetAll();

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrderNew = iOrderNew.GetAll();
            if (IdOrderNew != null)
            {
                vmodel.OrderNew = iOrderNew.GetById(Convert.ToInt32(IdOrderNew));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBOrderNew slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdOrderNew = model.OrderNew.IdOrderNew;
                slider.IdClintWitheDeliveryTariffs = model.OrderNew.IdClintWitheDeliveryTariffs;
                slider.IdInformationCompanies = model.OrderNew.IdInformationCompanies;
                slider.IdorderStatus = model.OrderNew.IdorderStatus;
                slider.IdorderCases = model.OrderNew.IdorderCases;
                slider.OrderDate = model.OrderNew.OrderDate;
                slider.DescriptionOrder = model.OrderNew.DescriptionOrder;
                slider.Weight = model.OrderNew.Weight;
                slider.CostPrice = model.OrderNew.CostPrice;
                slider.Price = model.OrderNew.Price;
                slider.Addres = model.OrderNew.Addres;
                slider.Nouts = model.OrderNew.Nouts;
                slider.DataEntry = model.OrderNew.DataEntry;
                slider.DateTimeEntry = model.OrderNew.DateTimeEntry;
                slider.CurrentState = model.OrderNew.CurrentState;
                slider.CatchReceiptNo = model.OrderNew.CatchReceiptNo;
                slider.Photo = model.OrderNew.Photo;
                slider.IsPaid = model.OrderNew.IsPaid;
                slider.ExchangedPrice = model.OrderNew.ExchangedPrice;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdOrderNew == 0 || slider.IdOrderNew == null)
                {
                    if (file.Count() > 0)
                    {
                        string Photo = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                        var fileStream = new FileStream(Path.Combine(@"wwwroot/Images/Home", Photo), FileMode.Create);
                        file[0].CopyTo(fileStream);
                        slider.Photo = Photo;
                        fileStream.Close();
                    }
                    else
                    {
                        TempData["Message"] = ResourceWeb.VLimageuplode;
                        return Redirect(returnUrl);
                    }
                    if (dbcontext.TBOrderNews.Where(a => a.CatchReceiptNo == slider.CatchReceiptNo).ToList().Count > 0)
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);

                        TempData["CatchReceiptNo"] = ResourceWeb.VLCatchReceiptNoDoplceted;
                        return Redirect(returnUrl);
                    }
                    if (dbcontext.TBOrderNews.Where(a => a.DescriptionOrder == slider.DescriptionOrder).ToList().Count > 0)
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);

                        TempData["DescriptionOrder"] = ResourceWeb.VLDescriptionOrderDoplceted;
                        return Redirect(returnUrl);
                    }

                    var reqwest = iOrderNew.saveData(slider);
                    if (reqwest == true)
                    {
                        //send email
                        var emailSetting = await dbcontext.TBEmailAlartSettings
                           .OrderByDescending(n => n.IdEmailAlartSetting)
                           .Where(a => a.CurrentState == true && a.Active == true)
                           .FirstOrDefaultAsync();

                        // التحقق من وجود إعدادات البريد الإلكتروني
                        if (emailSetting != null)
                        {
                            var message = new MimeMessage();
                            message.From.Add(new MailboxAddress("New Order", emailSetting.MailSender));
                            message.To.Add(new MailboxAddress("saif aldin", "nohadking@hotmail.com"));
                            message.Subject = "طلب جديد من :" + slider.DataEntry;
                            var builder = new BodyBuilder
                            {
                                TextBody = $"طلب جديد\n" +
                                           $"وصف الطلب: {slider.DescriptionOrder}\n" +
                                           $"تاريخ الطلب: {slider.OrderDate}\n" +
                                           $"الوزن: {slider.Weight}\n" +
                                           $"المبلغ: {slider.CostPrice}\n" +
                                           $"مبلغ العميل: {slider.Price}\n" +
                                           $"سعر الصرف: {slider.ExchangedPrice}\n" +
                                           $"رقم السند: {slider.CatchReceiptNo}"
                            };

                            // إضافة الصورة كملف مرفق إذا كانت موجودة
                            if (!string.IsNullOrEmpty(slider.Photo))
                            {
                                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Home", slider.Photo);
                                builder.Attachments.Add(imagePath);
                            }

                            message.Body = builder.ToMessageBody();

                            using (var client = new SmtpClient())
                            {
                                await client.ConnectAsync(emailSetting.SmtpServer, emailSetting.PortServer, SecureSocketOptions.StartTls);
                                await client.AuthenticateAsync(emailSetting.MailSender, emailSetting.PasswordEmail);
                                await client.SendAsync(message);
                                await client.DisconnectAsync(true);
                            }
                        }
                        else
                        {
                            // التعامل مع الحالة التي لا توجد فيها إعدادات البريد الإلكتروني
                            // يمكنك تسجيل خطأ أو تنفيذ إجراءات أخرى هنا
                        }

                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyOrderNewAr");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iOrderNew.DELETPHOTO(slider.IdInformationCompanies);

                    if (file.Count() == 0)
                    {
                        slider.Photo = model.OrderNew.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iOrderNew.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MyOrderNewAr");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iOrderNew.DELETPHOTO(slider.IdInformationCompanies);
                        var reqestUpdate2 = iOrderNew.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MyOrderNewAr");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }
                }
            }
            catch
            {
                var file = HttpContext.Request.Form.Files;
                if (file.Count() == 0)
                {
                    //var PhotoNAme = slider.Photo;
                    //var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
            }
        }

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> SaveAr(ViewmMODeElMASTER model, TBOrderNew slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.IdOrderNew = model.OrderNew.IdOrderNew;
				slider.IdClintWitheDeliveryTariffs = model.OrderNew.IdClintWitheDeliveryTariffs;
				slider.IdInformationCompanies = model.OrderNew.IdInformationCompanies;
				slider.IdorderStatus = model.OrderNew.IdorderStatus;
				slider.IdorderCases = model.OrderNew.IdorderCases;
				slider.OrderDate = model.OrderNew.OrderDate;
				slider.DescriptionOrder = model.OrderNew.DescriptionOrder;
				slider.Weight = model.OrderNew.Weight;
				slider.CostPrice = model.OrderNew.CostPrice;
				slider.Price = model.OrderNew.Price;
				slider.Addres = model.OrderNew.Addres;
				slider.Nouts = model.OrderNew.Nouts;
				slider.DataEntry = model.OrderNew.DataEntry;
				slider.DateTimeEntry = model.OrderNew.DateTimeEntry;
				slider.CurrentState = model.OrderNew.CurrentState;
				slider.CatchReceiptNo = model.OrderNew.CatchReceiptNo;
				slider.Photo = model.OrderNew.Photo;
				slider.IsPaid = model.OrderNew.IsPaid;
				slider.ExchangedPrice = model.OrderNew.ExchangedPrice;
				var file = HttpContext.Request.Form.Files;
				if (slider.IdOrderNew == 0 || slider.IdOrderNew == null)
				{
					if (file.Count() > 0)
					{
						string Photo = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
						var fileStream = new FileStream(Path.Combine(@"wwwroot/Images/Home", Photo), FileMode.Create);
						file[0].CopyTo(fileStream);
						slider.Photo = Photo;
						fileStream.Close();
					}
					else
					{
						TempData["Message"] = ResourceWeb.VLimageuplode;
						return Redirect(returnUrl);
					}
					if (dbcontext.TBOrderNews.Where(a => a.CatchReceiptNo == slider.CatchReceiptNo).ToList().Count > 0)
					{
						var PhotoNAme = slider.Photo;
						var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);

						TempData["CatchReceiptNo"] = ResourceWeb.VLCatchReceiptNoDoplceted;
						return Redirect(returnUrl);
					}
					if (dbcontext.TBOrderNews.Where(a => a.DescriptionOrder == slider.DescriptionOrder).ToList().Count > 0)
					{
						var PhotoNAme = slider.Photo;
						var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);

						TempData["DescriptionOrder"] = ResourceWeb.VLDescriptionOrderDoplceted;
						return Redirect(returnUrl);
					}

					var reqwest = iOrderNew.saveData(slider);
					if (reqwest == true)
					{
						//send email
						var emailSetting = await dbcontext.TBEmailAlartSettings
						   .OrderByDescending(n => n.IdEmailAlartSetting)
						   .Where(a => a.CurrentState == true && a.Active == true)
						   .FirstOrDefaultAsync();

						// التحقق من وجود إعدادات البريد الإلكتروني
						if (emailSetting != null)
						{
							var message = new MimeMessage();
							message.From.Add(new MailboxAddress("New Order", emailSetting.MailSender));
							message.To.Add(new MailboxAddress("saif aldin", "nohadking@hotmail.com"));
							message.Subject = "طلب جديد من :" + slider.DataEntry;
							var builder = new BodyBuilder
							{
								TextBody = $"طلب جديد\n" +
										   $"وصف الطلب: {slider.DescriptionOrder}\n" +
										   $"تاريخ الطلب: {slider.OrderDate}\n" +
										   $"الوزن: {slider.Weight}\n" +
										   $"المبلغ: {slider.CostPrice}\n" +
										   $"مبلغ العميل: {slider.Price}\n" +
										   $"سعر الصرف: {slider.ExchangedPrice}\n" +
										   $"رقم السند: {slider.CatchReceiptNo}"
							};

							// إضافة الصورة كملف مرفق إذا كانت موجودة
							if (!string.IsNullOrEmpty(slider.Photo))
							{
								var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Home", slider.Photo);
								builder.Attachments.Add(imagePath);
							}

							message.Body = builder.ToMessageBody();

							using (var client = new SmtpClient())
							{
								await client.ConnectAsync(emailSetting.SmtpServer, emailSetting.PortServer, SecureSocketOptions.StartTls);
								await client.AuthenticateAsync(emailSetting.MailSender, emailSetting.PasswordEmail);
								await client.SendAsync(message);
								await client.DisconnectAsync(true);
							}
						}
						else
						{
							// التعامل مع الحالة التي لا توجد فيها إعدادات البريد الإلكتروني
							// يمكنك تسجيل خطأ أو تنفيذ إجراءات أخرى هنا
						}

						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyOrderNewAr");
					}
					else
					{
						var PhotoNAme = slider.Photo;
						var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}
				else
				{
					//var reqweistDeletPoto = iOrderNew.DELETPHOTO(slider.IdInformationCompanies);

					if (file.Count() == 0)
					{
						slider.Photo = model.OrderNew.Photo;
						//TempData["Message"] = ResourceWeb.VLimageuplode;
						var reqestUpdate2 = iOrderNew.UpdateData(slider);
						if (reqestUpdate2 == true)
						{
							TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
							return RedirectToAction("MyOrderNewAr");
						}
						else
						{
							var PhotoNAme = slider.Photo;
							//var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
							TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
							return Redirect(returnUrl);
						}
					}
					else
					{
						var reqweistDeletPoto = iOrderNew.DELETPHOTO(slider.IdInformationCompanies);
						var reqestUpdate2 = iOrderNew.UpdateData(slider);
						if (reqestUpdate2 == true)
						{
							TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
							return RedirectToAction("MyOrderNewAr");
						}
						else
						{
							var PhotoNAme = slider.Photo;
							var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
							TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
							return Redirect(returnUrl);
						}
					}
				}
			}
			catch
			{
				var file = HttpContext.Request.Form.Files;
				if (file.Count() == 0)
				{
					//var PhotoNAme = slider.Photo;
					//var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
					TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
					return Redirect(returnUrl);
				}
				else
				{
					var PhotoNAme = slider.Photo;
					var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
					TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
					return Redirect(returnUrl);
				}
			}
		}

		[Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdOrderNew)
        {
            var reqwistDelete = iOrderNew.deleteData(IdOrderNew);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyOrderNew");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyOrderNew");
            }
        }

		[Authorize(Roles = "Admin")]
		public IActionResult DeleteDataAr(int IdOrderNew)
		{
			var reqwistDelete = iOrderNew.deleteData(IdOrderNew);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWebAr.VLdELETESuccessfully;
				return RedirectToAction("MyOrderNewAr");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWebAr.VLErrorDeleteData;
				return RedirectToAction("MyOrderNewAr");
			}
		}


		[HttpGet]
        public IActionResult GetPrices(int selectedCompanyId, float weight, int toCurrencyId, int fromCurrencyId)
        {
            var exchangeRate = iExchangeRate.GetAll()
            .LastOrDefault(e => e.IdCurrenciesExchangeRates == fromCurrencyId && e.ToIdCurrenciesExchangeRates == toCurrencyId)?
            .Rate;
            //var eeee=   exchangeRate.FirstOrDefault(e => e.IdCurrenciesExchangeRates == fromCurrencyId && e.ToIdCurrenciesExchangeRates == toCurrencyId)?.Rate;

            //        var clintDeliveryTariff = dbcontext.TBExchangeRates
            //.Where(t => t.IdCurrenciesExchangeRates == fromCurrencyId)?.Rate;

            //      var towr= dbcontext.TBExchangeRates
            //.Where(t => t.ToIdCurrenciesExchangeRates == toCurrencyId);
            //int fromCurrencyId = 1;
            var prices = iShippingPrice.GetAll()
                .FirstOrDefault(x => x.IdInformationCompanies == selectedCompanyId);
            if (prices != null)
            {
                if (weight <= 10)
                {
                    return Json(new
                    {
                        costPrice = prices.CoPricePerkgUnder10 * (decimal)weight,
                        price = prices.CoPricePerkgAbove10 * (decimal)weight,
                        exchangePrice = prices.CoPricePerkgAbove10 * (decimal)weight * exchangeRate
                    });
                }
                else
                {
                    return Json(new
                    {
                        costPrice = prices.ClintPricePerkgUnder10 * (decimal)weight,
                        price = prices.ClintPricePerkgAbove10 * (decimal)weight,
                        exchangePrice = prices.CoPricePerkgAbove10 * (decimal)weight * exchangeRate
                    });
                }
            }

            return Json(null);
        }

    }
}
