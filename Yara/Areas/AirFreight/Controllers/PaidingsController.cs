using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.AirFreight.Controllers
{
    [Area("AirFreight")]
    [Authorize(Roles = "Admin,AirFreight")]
    public class PaidingsController : Controller
    {
        IIPaidings iPaidings;
        UserManager<ApplicationUser> userManager;
        MasterDbcontext dbcontext;
        IIOrderNew iOrderNew;
        IICurrenciesExchangeRates iCurrenciesTransactions;
        IIExchangeRate iExchangeRate;
        public PaidingsController(IIPaidings iPaidings1, MasterDbcontext dbcontext1, IIOrderNew iOrderNew1, UserManager<ApplicationUser> userManager, IICurrenciesExchangeRates iCurrenciesTransactions1, IIExchangeRate iExchangeRate1)
        {
            iPaidings = iPaidings1;
            dbcontext = dbcontext1;
            iOrderNew = iOrderNew1;
            this.userManager = userManager;
            iExchangeRate = iExchangeRate1;
            iCurrenciesTransactions = iCurrenciesTransactions1;
        }

        public IActionResult MyPaiding()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.userName = userManager.GetUserName(User);

            vmodel.ListViewPaings = iPaidings.GetAllDataentry(vmodel.userName);

            return View(vmodel);
        }

        public IActionResult MyPaidingAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.userName = userManager.GetUserName(User);

            vmodel.ListViewPaings = iPaidings.GetAllDataentry(vmodel.userName);

            return View(vmodel);
        }



        public IActionResult AddPaidingsImage(int? IdPaings)
        {
            ViewmMODeElMASTER vmodell = new ViewmMODeElMASTER();

            var userName = userManager.GetUserName(User);
            ViewBag.Order = iOrderNew.GetAllDataentry(userName);


            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewPaings = iPaidings.GetAll();
            if (IdPaings != null)
            {
                vmodel.Paing = iPaidings.GetById(Convert.ToInt32(IdPaings));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        public IActionResult AddPaidingsArImageAr(int? IdPaings)
        {
            ViewmMODeElMASTER vmodell = new ViewmMODeElMASTER();

            var userName = userManager.GetUserName(User);
            ViewBag.Order = iOrderNew.GetAllDataentry(userName);


            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.userName = userManager.GetUserName(User);

            vmodel.ListViewPaings = iPaidings.GetAllDataentry(vmodel.userName);
            if (IdPaings != null)
            {
                vmodel.Paing = iPaidings.GetById(Convert.ToInt32(IdPaings));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }


        public IActionResult AddPaidings(int? IdPaings)
        {
            ViewmMODeElMASTER vmodell = new ViewmMODeElMASTER();

            var userName = userManager.GetUserName(User);
            ViewBag.Order = iOrderNew.GetAllDataentry(userName);
            ViewBag.Currenc = iCurrenciesTransactions.GetAll();


            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.userName = userManager.GetUserName(User);
            vmodel.ListViewExchangeRate = iExchangeRate.GetAll();

            // Set the default ToCurrencyID
            vmodel.ExchangeRate = new TBExchangeRate
            {
                ToIdCurrenciesExchangeRates = 2 // Default value
            };

            vmodel.ListViewPaings = iPaidings.GetAllDataentry(vmodel.userName);
            if (IdPaings != null)
            {
                vmodel.Paing = iPaidings.GetById(Convert.ToInt32(IdPaings));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        public IActionResult AddPaidingsAr(int? IdPaings)
        {
            ViewmMODeElMASTER vmodell = new ViewmMODeElMASTER();

            var userName = userManager.GetUserName(User);
            ViewBag.Order = iOrderNew.GetAllDataentry(userName);
            ViewBag.Currenc = iCurrenciesTransactions.GetAll();


            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.userName = userManager.GetUserName(User);
            vmodel.ListViewExchangeRate = iExchangeRate.GetAll();

            // Set the default ToCurrencyID
            vmodel.ExchangeRate = new TBExchangeRate
            {
                ToIdCurrenciesExchangeRates = 2 // Default value
            };

            vmodel.ListViewPaings = iPaidings.GetAllDataentry(vmodel.userName);
            if (IdPaings != null)
            {
                vmodel.Paing = iPaidings.GetById(Convert.ToInt32(IdPaings));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }









        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBPaing slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdPaings = model.Paing.IdPaings;
                slider.IdOrderNew = model.Paing.IdOrderNew;
                slider.ResivedMony = model.Paing.ResivedMony;
                slider.Photo = model.Paing.Photo;
                slider.ReceiptNo = model.Paing.ReceiptNo;
                slider.ReceiptStatment = model.Paing.ReceiptStatment;
                slider.ReceiptDate = model.Paing.ReceiptDate;
                slider.DataEntry = model.Paing.DataEntry;
                slider.DateTimeEntry = model.Paing.DateTimeEntry;
                slider.CurrentState = model.Paing.CurrentState;
                slider.Photo = model.Paing.Photo;
                var file = HttpContext.Request.Form.Files;

                // add
                if (slider.IdPaings == 0 || slider.IdPaings == null)
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
                    if (dbcontext.TBPaings.Where(a => a.ReceiptNo == slider.ReceiptNo).ToList().Count > 0)
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);

                        TempData["ReceiptNo"] = ResourceWeb.VLReceiptNoDoplceted;
                        return Redirect(returnUrl);
                    }

                    var reqwest = iPaidings.saveData(slider);
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
                            message.To.Add(new MailboxAddress("pritom", "saifaldin_s@hotmail.com"));
                            message.Subject = "عملية تسليم من قبل :" + slider.DataEntry;
                            var builder = new BodyBuilder
                            {
                                TextBody = $"تسليم الطلب\n" +
                                           $"رقم السند : {slider.ReceiptNo}\n" +
                                           $"تاريخ السند: {slider.ReceiptDate}\n" +

                                           $"المبلغ: {slider.ResivedMony}\n" +
                                           $"البيان : {slider.ReceiptStatment}\n" +

                                           $"تمت بنجاح وقد خرجت للتوصيل"
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
                        return RedirectToAction("MyPaiding");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }

                // update
                else
                {
                    //var reqweistDeletPoto = iPaidings.DELETPHOTO(slider.IdInformationCompanies);

                    if (file.Count() == 0)

                    {
                        slider.Photo = model.Paing.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iPaidings.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MyPaiding");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iPaidings.DELETPHOTO(slider.IdPaings);
                        var reqestUpdate2 = iPaidings.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MyPaiding");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }

                    //var reqestUpdate = iPaidings.UpdateData(slider);
                    //if (reqestUpdate == true)
                    //{
                    //	TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                    //	return RedirectToAction("MyPaidingAr");
                    //}
                    //else
                    //{
                    //	var PhotoNAme = slider.Photo;
                    //	var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
                    //	TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                    //	return Redirect(returnUrl);
                    //}

                }
            }
            catch
            {
                var file = HttpContext.Request.Form.Files;
                if (file.Count() == 0)

                {
                    //var PhotoNAme = slider.Photo;
                    //var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
            }
        }

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> SaveAr(ViewmMODeElMASTER model, TBPaing slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.IdPaings = model.Paing.IdPaings;
				slider.IdOrderNew = model.Paing.IdOrderNew;
				slider.ResivedMony = model.Paing.ResivedMony;
				slider.Photo = model.Paing.Photo;
				slider.ReceiptNo = model.Paing.ReceiptNo;
				slider.ReceiptStatment = model.Paing.ReceiptStatment;
				slider.ReceiptDate = model.Paing.ReceiptDate;
				slider.DataEntry = model.Paing.DataEntry;
				slider.DateTimeEntry = model.Paing.DateTimeEntry;
				slider.CurrentState = model.Paing.CurrentState;
				slider.Photo = model.Paing.Photo;
				var file = HttpContext.Request.Form.Files;

				// add
				if (slider.IdPaings == 0 || slider.IdPaings == null)
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
					if (dbcontext.TBPaings.Where(a => a.ReceiptNo == slider.ReceiptNo).ToList().Count > 0)
					{
						var PhotoNAme = slider.Photo;
						var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);

						TempData["ReceiptNo"] = ResourceWeb.VLReceiptNoDoplceted;
						return Redirect(returnUrl);
					}

					var reqwest = iPaidings.saveData(slider);
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
							message.To.Add(new MailboxAddress("pritom", "nohadking@hotmail.com"));
							message.Subject = "عملية تسليم من قبل :" + slider.DataEntry;
							var builder = new BodyBuilder
							{
								TextBody = $"تسليم الطلب\n" +
										   $"رقم السند : {slider.ReceiptNo}\n" +
										   $"تاريخ السند: {slider.ReceiptDate}\n" +

										   $"المبلغ: {slider.ResivedMony}\n" +
										   $"البيان : {slider.ReceiptStatment}\n" +

										   $"تمت بنجاح وقد خرجت للتوصيل"
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
						return RedirectToAction("MyPaidingAr");
					}
					else
					{
						var PhotoNAme = slider.Photo;
						var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}

				// update
				else
				{
					//var reqweistDeletPoto = iPaidings.DELETPHOTO(slider.IdInformationCompanies);

					if (file.Count() == 0)

					{
						slider.Photo = model.Paing.Photo;
						//TempData["Message"] = ResourceWeb.VLimageuplode;
						var reqestUpdate2 = iPaidings.UpdateData(slider);
						if (reqestUpdate2 == true)
						{
							TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
							return RedirectToAction("MyPaidingAr");
						}
						else
						{
							var PhotoNAme = slider.Photo;
							//var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
							TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
							return Redirect(returnUrl);
						}
					}
					else
					{
						var reqweistDeletPoto = iPaidings.DELETPHOTO(slider.IdPaings);
						var reqestUpdate2 = iPaidings.UpdateData(slider);
						if (reqestUpdate2 == true)
						{
							TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
							return RedirectToAction("MyPaidingAr");
						}
						else
						{
							var PhotoNAme = slider.Photo;
							var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
							TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
							return Redirect(returnUrl);
						}
					}

					//var reqestUpdate = iPaidings.UpdateData(slider);
					//if (reqestUpdate == true)
					//{
					//	TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
					//	return RedirectToAction("MyPaidingAr");
					//}
					//else
					//{
					//	var PhotoNAme = slider.Photo;
					//	var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
					//	TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
					//	return Redirect(returnUrl);
					//}

				}
			}
			catch
			{
				var file = HttpContext.Request.Form.Files;
				if (file.Count() == 0)

				{
					//var PhotoNAme = slider.Photo;
					//var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
					TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
					return Redirect(returnUrl);
				}
				else
				{
					var PhotoNAme = slider.Photo;
					var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
					TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
					return Redirect(returnUrl);
				}
			}
		}

		[Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdPaings)
        {
            var reqwistDelete = iPaidings.deleteData(IdPaings);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyPaiding");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyPaiding");
            }
        }

		[Authorize(Roles = "Admin")]
		public IActionResult DeleteDataAr(int IdPaings)
		{
			var reqwistDelete = iPaidings.deleteData(IdPaings);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWebAr.VLdELETESuccessfully;
				return RedirectToAction("MyPaidingAr");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWebAr.VLErrorDeleteData;
				return RedirectToAction("MyPaidingAr");
			}
		}

		[HttpGet]
        public IActionResult GetExchangeRate(int fromCurrencyId, int toCurrencyId, double revisedMoney)
        {
            // Fetch the exchange rate from the database
            var exchangeRate = iExchangeRate.GetAll()
                              .FirstOrDefault(e => e.IdCurrenciesExchangeRates == fromCurrencyId && e.ToIdCurrenciesExchangeRates == toCurrencyId)?
                              .Rate;

            var exchangeRateValue = exchangeRate * (decimal)revisedMoney;

            if (exchangeRate != null)
            {
                return Json(exchangeRateValue);
            }
            return Json("N/A");
        }
        //[HttpGet]
        //public IActionResult GetOrderDetails(int orderId, int fromCurrencyId, int toCurrencyId)
        //{
        //    // Fetch the exchange rate from the database
        //    var exchangeRate = iExchangeRate.GetAll()
        //                      .FirstOrDefault(e => e.IdCurrenciesExchangeRates == fromCurrencyId && e.ToIdCurrenciesExchangeRates == toCurrencyId)?
        //                      .Rate;

        //    var order = iOrderNew.GetById(orderId);
        //    if (order != null)
        //    {
        //        var revisedMoney = order.CostPrice;
        //        var exchangedPrice = order.ExchangedPrice;
        //        var finalExchangedPrice = revisedMoney * exchangedPrice;

        //        return Json(new
        //        {
        //            revisedMoney = revisedMoney,
        //            exchangedPrice = exchangedPrice,
        //            finalExchangedPrice = finalExchangedPrice
        //        });
        //    }
        //    return Json(null);
        //}

        [HttpGet]
        public IActionResult GetOrderDetails(int orderId, int fromCurrencyId, int toCurrencyId, double revisedMoney, bool isManual = false)
        {
            // Fetch the exchange rate from the database
            var exchangeRate = iExchangeRate.GetAll()
                              .FirstOrDefault(e => e.IdCurrenciesExchangeRates == fromCurrencyId && e.ToIdCurrenciesExchangeRates == toCurrencyId)?
                              .Rate;

            //var exchangeRateValue = exchangeRate * (decimal)revisedMoney;

            if (isManual)
            {
                var exchangeRateValue = exchangeRate * (decimal)revisedMoney;
                return Json(new
                {
                    exchangedPrice = exchangeRateValue
                });
            }
            else
            {
                var order = iOrderNew.GetById(orderId);
                if (order != null)
                {
                    var finalRevisedMoney = order.CostPrice;
                    var exchangedPrice = order.ExchangedPrice;

                    return Json(new
                    {
                        revisedMoney = finalRevisedMoney,
                        exchangedPrice = exchangedPrice
                    });
                }
                return Json(null);
            }
        }

    }
}
