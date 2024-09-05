using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CheckCustmerController : Controller
    {
        MasterDbcontext dbcontext;

        private readonly UserManager<ApplicationUser> _userManager;
        IIUserInformation iUserInformation;
        IICity iCity;
        IIArea iArea;
        IIShippingPrice iShippingPrice;
        IICurrenciesExchangeRates iCurrenciesExchangeRates;
        IITypeSystemDelivery iTypeSystemDelivery;
        IICityDeliveryTariffs iCityDeliveryTariffs;
        IIShippingAddresseClint iShippingAddresseClint;

        IIOrderNew iOrderNew;
        IIOrderCase iOrderCase;
        IIOrderStatus iOrderStatus;
        IIClintWitheDeliveryTariffs iClintWitheDeliveryTariffs;
        IICurrenciesExchangeRates iCurrenciesTransactions;

        IITransaction iTransaction;
        IIExchangeRate iExchangeRate;
        public CheckCustmerController(IIExchangeRate iExchangeRate1, IITransaction iTransaction, MasterDbcontext dbcontext1, IIUserInformation iUserInformation1, IICity iCity1, IIArea iArea1, IIShippingPrice iShippingPrice1, IICurrenciesExchangeRates iCurrenciesExchangeRates1, IITypeSystemDelivery iTypeSystemDelivery1, 
            IICityDeliveryTariffs iCityDeliveryTariffs1, IIShippingAddresseClint iShippingAddresseClint1, UserManager<ApplicationUser> userManager, IICurrenciesExchangeRates iCurrenciesTransactions1, IIOrderNew iOrderNew1, IIOrderCase iOrderCase1, IIOrderStatus iOrderStatus1, IIClintWitheDeliveryTariffs iClintWitheDeliveryTariffs1)
        {
            dbcontext = dbcontext1;
            iUserInformation = iUserInformation1;
            iCity = iCity1;
            iArea = iArea1;
            iShippingPrice = iShippingPrice1;
            iCurrenciesExchangeRates = iCurrenciesExchangeRates1;
            iTypeSystemDelivery = iTypeSystemDelivery1;
            iCityDeliveryTariffs = iCityDeliveryTariffs1;
            iShippingAddresseClint = iShippingAddresseClint1;
            _userManager = userManager;
            iCurrenciesTransactions = iCurrenciesTransactions1;
            iOrderNew = iOrderNew1;
            iOrderCase = iOrderCase1;
            iOrderStatus = iOrderStatus1;
            iClintWitheDeliveryTariffs = iClintWitheDeliveryTariffs1;
            iTransaction = iTransaction;
            iExchangeRate = iExchangeRate1;
        }
        public IActionResult MyCheckCustmer()
        {
            ViewBag.City = iCity.GetAll();
            ViewBag.Area = iArea.GetAll();
            ViewBag.ShippingPrice = iShippingPrice.GetAll();
            ViewBag.Currenc = iCurrenciesExchangeRates.GetAll();
            ViewBag.TypeSystemDelivery = iTypeSystemDelivery.GetAll();
            ViewBag.CityDeliveryTariffs = iCityDeliveryTariffs.GetAll();
            ViewBag.user = iUserInformation.GetAllByNameall();

            ViewBag.OrderCase = iOrderCase.GetAll();
            ViewBag.OrderStatus = iOrderStatus.GetAll();
            ViewBag.ClintWith = iClintWitheDeliveryTariffs.GetAll();
            ViewBag.ShippingPrice = iShippingPrice.GetAll();
            ViewBag.Currenc = iCurrenciesTransactions.GetAll();

            return View();
        }
        public IActionResult MyCheckCustmerAr()
        {
            ViewBag.City = iCity.GetAll();
            ViewBag.Area = iArea.GetAll();
            ViewBag.ShippingPrice = iShippingPrice.GetAll();
            ViewBag.Currenc = iCurrenciesExchangeRates.GetAll();
            ViewBag.TypeSystemDelivery = iTypeSystemDelivery.GetAll();
            ViewBag.CityDeliveryTariffs = iCityDeliveryTariffs.GetAll();
            ViewBag.user = iUserInformation.GetAllByNameall();

            ViewBag.OrderCase = iOrderCase.GetAll();
            ViewBag.OrderStatus = iOrderStatus.GetAll();
            ViewBag.ClintWith = iClintWitheDeliveryTariffs.GetAll();
            ViewBag.ShippingPrice = iShippingPrice.GetAll();
            ViewBag.Currenc = iCurrenciesTransactions.GetAll();

            return View();
        }
     

        [HttpPost]
        public async Task<IActionResult> GitPhouneNumber(string PhoneNumber)
        {
            // Search for the phone number in ViewShippingAddresseClint
            var phoneNo = await dbcontext.ViewShippingAddresseClint
                                         .FirstOrDefaultAsync(u => u.PhoneNumber == PhoneNumber);
            if (phoneNo != null)
            {
                // Return the existing data from ViewShippingAddresseClint
                return Json(new
                {
                    Success = true,
                    Name = phoneNo.Name,
                    Description = phoneNo.Description,
                    City = phoneNo.CityName,
                    Area = phoneNo.AreaName,
                    LandMark = phoneNo.NearestLandmark,
                    //Address = phoneNo.AreaName,
                    NikeName = phoneNo.NikeNAme,
                    CustPriceOver10 = phoneNo.ClintPricePerkgUnder10,
                    CustPriceUnder10 = phoneNo.ClintPricePerkgAbove10,
                    System = phoneNo.TypeSystemDelivery,
                    Currency = phoneNo.CurrencyName,
                    CityDeliveryTariff = phoneNo.IdCityDeliveryTariffs,
                    DealingStatus = phoneNo.CurrentState,
                    PhoneNumber = phoneNo.PhoneNumber
                });
            }
            // Search the AspNetUsers table for the phone number
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == PhoneNumber);
            if (user != null)
            {
                // Check if other data is already available
                bool isDataComplete = !string.IsNullOrEmpty(user.Email) &&
                                      !string.IsNullOrEmpty(user.UserName) &&
                                      !string.IsNullOrEmpty(user.Name);
                if (isDataComplete)
                {
                    // Data is complete, return the existing user data
                    return Json(new
                    {
                        Success = true,
                        Name = user.Name,
                        Email = user.Email,
                        UserName = user.UserName,
                        PhoneNumber = user.PhoneNumber,
                        Message = "Existing user data retrieved."
                    });
                }
                else
                {
                    // Data is not complete, update the user with missing data
                    user.Email = user.Email ?? $"{PhoneNumber}@{PhoneNumber}";
                    user.UserName = user.UserName ?? PhoneNumber;
                    user.Name = user.Name ?? PhoneNumber;
                    user.ImageUser = user.ImageUser ?? "default-image-path.jpg";                   
                    var updateResult = await _userManager.UpdateAsync(user);
                    if (updateResult.Succeeded)
                    {
                        // Return the updated user data
                        return Json(new
                        {
                            Success = true,
                            Name = user.Name,
                            Email = user.Email,
                            UserName = user.UserName,
                            PhoneNumber = user.PhoneNumber,
                            Message = "Existing user data updated and retrieved."
                        });
                    }
                    else
                    {
                        // Return error if updating the user failed
                        string updateErrorMessage = string.Join("; ", updateResult.Errors.Select(e => e.Description));
                        return Json(new
                        {
                            Success = false,
                            Message = $"Failed to update existing user: {updateErrorMessage}"
                        });
                    }
                }
            }
            // If the phone number was not found in both tables, create a new user
            string email = $"{PhoneNumber}@{PhoneNumber}";
            string username = PhoneNumber;
            string fullName = PhoneNumber;
            string password = PhoneNumber.Length >= 5 ? PhoneNumber.Substring(PhoneNumber.Length - 5) : PhoneNumber;
            var newUser = new ApplicationUser
            {
                UserName = username,
                Email = email,
                Name = fullName,
                PhoneNumber = PhoneNumber,
                ImageUser = "default-image-path.jpg",
                ActiveUser = true
            };
            try
            {
                var createResult = await _userManager.CreateAsync(newUser, password);
                if (createResult.Succeeded)
                {
                    // Assign the default role (e.g., Customer) to the new user
                var addrol=    await _userManager.AddToRoleAsync(newUser, "Customer");
                    if(addrol.Succeeded)
                    // Return success with new user info
                    return Json(new
                    {
                        Success = true,
                        Name = newUser.Name,
                        Email = newUser.Email,
                        UserName = newUser.UserName,
                        PhoneNumber = newUser.PhoneNumber,
                        UserId = newUser.Id,
                        Message = "New customer registered successfully!"
                    });
                    else
                    {
                        return Json(new
                        {
                            Success = false,
                            Name = newUser.Name,
                            Email = newUser.Email,
                            UserName = newUser.UserName,
                            PhoneNumber = newUser.PhoneNumber,
                            Message = "Error role!"
                        });
                    }
                }
                else
                {
                    // Capture and return specific errors during user creation
                    string createErrorMessage = string.Join("; ", createResult.Errors.Select(e => e.Description));
                    return Json(new
                    {
                        Success = false,
                        Message = $"User creation failed: {createErrorMessage}"
                    });
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors during the process
                return Json(new
                {
                    Success = false,
                    Message = $"An error occurred while registering the new user: {ex.Message}"
                });
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> SaveModal(ViewmMODeElMASTER model, TBShippingAddresseClint slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdShippingAddresseClint = model.ShippingAddresseClint.IdShippingAddresseClint;
                slider.IdUser = model.ShippingAddresseClint.IdUser;
                slider.IdCity = model.ShippingAddresseClint.IdCity;
                slider.IdArea = model.ShippingAddresseClint.IdArea;
                slider.IdShippingPrices = model.ShippingAddresseClint.IdShippingPrices;
                slider.IdCurrenciesExchangeRates = model.ShippingAddresseClint.IdCurrenciesExchangeRates;
                slider.NearestLandmark = model.ShippingAddresseClint.NearestLandmark;
                slider.ClintPricePerkgUnder10 = model.ShippingAddresseClint.ClintPricePerkgUnder10;
                slider.ClintPricePerkgAbove10 = model.ShippingAddresseClint.ClintPricePerkgAbove10;
                slider.IdTypeSystemDelivery = model.ShippingAddresseClint.IdTypeSystemDelivery;
                slider.IdCityDeliveryTariffs = model.ShippingAddresseClint.IdCityDeliveryTariffs;

                slider.DeliveryPriceClint = model.ShippingAddresseClint.DeliveryPriceClint;
                slider.Description = model.ShippingAddresseClint.Description;
                slider.Active = model.ShippingAddresseClint.Active;
                slider.DataEntry = model.ShippingAddresseClint.DataEntry;
                slider.DateTimeEntry = model.ShippingAddresseClint.DateTimeEntry;
                slider.CurrentState = model.ShippingAddresseClint.CurrentState;
                if (slider.IdShippingAddresseClint == 0 || slider.IdShippingAddresseClint == null)
                {
                    var reqwest = iShippingAddresseClint.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyCheckCustmer");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("MyCheckCustmer");
                    }
                }
                else
                {
                    var reqestUpdate = iShippingAddresseClint.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyCheckCustmer");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("MyCheckCustmer");
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return RedirectToAction("MyCheckCustmer");
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CheckCustomerModalSave(ViewmMODeElMASTER model, TBOrderNew slider, List<IFormFile> Files, string returnUrl)
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
                            message.To.Add(new MailboxAddress("saif aldin", "saifaldin_s@hotmail.com"));
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
						return RedirectToAction("MyCheckCustmer");
					}
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return RedirectToAction("MyCheckCustmer");
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
                            return RedirectToAction("MyCheckCustmer");
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
                            return RedirectToAction("MyCheckCustmer");
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
