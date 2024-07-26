using System.Net.Mail;
using System.Net;

namespace Yara.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class EmailNewsletterController : Controller
	{
		MasterDbcontext dbcontext;
		IIEmailNewsletter iEmailNewsletter;

		public EmailNewsletterController(MasterDbcontext dbcontext1, IIEmailNewsletter iEmailNewsletter1)
		{
			dbcontext = dbcontext1;
			iEmailNewsletter = iEmailNewsletter1;
		}

		public IActionResult MyEmailNewsletter()
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListEmailNewsletters = iEmailNewsletter.GetAll();
			return View(vmodel);
		}

		public IActionResult MyEmailNewsletterAr()
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListEmailNewsletters = iEmailNewsletter.GetAll();
			return View(vmodel);
		}

		public IActionResult AddEmailNewsletter(int? IdEmailNewsletter)
		{
			var model = new ViewmMODeElMASTER();
			if (IdEmailNewsletter != null)
			{
				model.EmailNewsletter = iEmailNewsletter.GetById(IdEmailNewsletter.Value);
			}
			return View(model);
		}

		public IActionResult AddEmailNewsletterAr(int? IdEmailNewsletter)
		{
			var model = new ViewmMODeElMASTER();
			if (IdEmailNewsletter != null)
			{
				model.EmailNewsletter = iEmailNewsletter.GetById(IdEmailNewsletter.Value);
			}
			return View(model);
		}

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBEmailNewsletter slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdEmailNewsletter = model.EmailNewsletter.IdEmailNewsletter;
                slider.IdUser = model.EmailNewsletter.IdUser;
                slider.SubscriptionDate = model.EmailNewsletter.SubscriptionDate;
                slider.CurrentState = model.EmailNewsletter.CurrentState;
                slider.MailSender = model.EmailNewsletter.MailSender;
                slider.DateEntry = model.EmailNewsletter.DateEntry;
                slider.DateTimeEntry = model.EmailNewsletter.DateTimeEntry;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdEmailNewsletter == 0 || slider.IdEmailNewsletter == null)
                {
                    //if (file.Count() > 0)
                    //{
                    //    string Photo = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                    //    var fileStream = new FileStream(Path.Combine(@"wwwroot/Images/Home", Photo), FileMode.Create);
                    //    file[0].CopyTo(fileStream);
                    //    slider.Photo = Photo;
                    //    fileStream.Close();
                    //}
                    //else
                    //{
                    //    TempData["Message"] = ResourceWeb.VLimageuplode;
                    //    return Redirect(returnUrl);
                    //}
                    //if (dbcontext.TBOrderNews.Where(a => a.CatchReceiptNo == slider.CatchReceiptNo).ToList().Count > 0)
                    //{
                    //    var PhotoNAme = slider.Photo;
                    //    var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);

                    //    TempData["CatchReceiptNo"] = ResourceWeb.VLCatchReceiptNoDoplceted;
                    //    return Redirect(returnUrl);
                    //}
                    //if (dbcontext.TBOrderNews.Where(a => a.DescriptionOrder == slider.DescriptionOrder).ToList().Count > 0)
                    //{
                    //    var PhotoNAme = slider.Photo;
                    //    var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);

                    //    TempData["DescriptionOrder"] = ResourceWeb.VLDescriptionOrderDoplceted;
                    //    return Redirect(returnUrl);
                    //}

                    var reqwest = iEmailNewsletter.saveData(slider);
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

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBEmailNewsletter slider, List<IFormFile> Files, string returnUrl)
        //{
        //	try
        //	{
        //		if (slider.IdEmailNewsletter == 0 || slider.IdEmailNewsletter == null)
        //		{
        //			if (dbcontext.TBEmailNewsletters.Any(e => e.IdUser == slider.IdUser))
        //			{
        //				TempData["EmailNewsletter"] = "Duplicate entry detected!";
        //				return RedirectToAction("AddEmailNewsletter", model);
        //			}

        //			var result = iEmailNewsletter.SaveData(slider);
        //                  if (result == true)
        //                  {
        //                      //send email
        //                      var emailSetting = await dbcontext.TBEmailNewsletters
        //                         .OrderByDescending(n => n.IdEmailNewsletter)
        //                         .Where(a => a.CurrentState == true && a.IsSubscribed == true)
        //                         .FirstOrDefaultAsync();

        //                      // التحقق من وجود إعدادات البريد الإلكتروني
        //                      if (emailSetting != null)
        //                      {
        //                          var message = new MimeMessage();
        //                          message.From.Add(new MailboxAddress("New Order", emailSetting.MailSender));
        //                          message.To.Add(new MailboxAddress("saif aldin", "saifaldin_s@hotmail.com"));
        //                          message.Subject = "طلب جديد من :" + slider.DateEntry;
        //                          var builder = new BodyBuilder
        //                          {
        //                              TextBody = $"طلب جديد\n" +
        //                                         $"وصف الطلب: {slider.DescriptionOrder}\n" +
        //                                         $"تاريخ الطلب: {slider.OrderDate}\n" +
        //                                         $"الوزن: {slider.Weight}\n" +
        //                                         $"المبلغ: {slider.CostPrice}\n" +
        //                                         $"مبلغ العميل: {slider.Price}\n" +
        //                                         $"سعر الصرف: {slider.ExchangedPrice}\n" +
        //                                         $"رقم السند: {slider.CatchReceiptNo}"
        //                          };

        //                          // إضافة الصورة كملف مرفق إذا كانت موجودة
        //                          if (!string.IsNullOrEmpty(slider.Photo))
        //                          {
        //                              var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Home", slider.Photo);
        //                              builder.Attachments.Add(imagePath);
        //                          }

        //                          message.Body = builder.ToMessageBody();

        //                          using (var client = new SmtpClient())
        //                          {
        //                              await client.ConnectAsync(emailSetting.SmtpServer, emailSetting.PortServer, SecureSocketOptions.StartTls);
        //                              await client.AuthenticateAsync(emailSetting.MailSender, emailSetting.PasswordEmail);
        //                              await client.SendAsync(message);
        //                              await client.DisconnectAsync(true);
        //                          }
        //                      }
        //                      else
        //                      {
        //                          // التعامل مع الحالة التي لا توجد فيها إعدادات البريد الإلكتروني
        //                          // يمكنك تسجيل خطأ أو تنفيذ إجراءات أخرى هنا
        //                      }

        //                      TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
        //                      return RedirectToAction("MyOrderNewAr");
        //                  }
        //                  else
        //                  {
        //                      var PhotoNAme = slider.Photo;
        //                      var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
        //                      TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
        //                      return Redirect(returnUrl);`
        //                  }
        //   //               if (result)
        //			//{
        //			//	//SendEmail(slider);
        //			//	TempData["SavedSuccessfully"] = "Saved and sent successfully!";
        //			//	return RedirectToAction("MyEmailNewsletter");
        //			//}
        //			//else
        //			//{
        //			//	TempData["ErrorSave"] = "Error saving data!";
        //			//	return Redirect(returnUrl);
        //			//}
        //		}
        //		else
        //		{
        //			var result = iEmailNewsletter.UpdateData(slider);
        //			if (result)
        //			{
        //				//SendEmail(slider);
        //				TempData["SavedSuccessfully"] = "Updated and sent successfully!";
        //				return RedirectToAction("MyEmailNewsletter");
        //			}
        //			else
        //			{
        //				TempData["ErrorSave"] = "Error updating data!";
        //				return Redirect(returnUrl);
        //			}
        //		}
        //	}
        //	catch
        //	{
        //		TempData["ErrorSave"] = "Error saving data!";
        //		return Redirect(returnUrl);
        //	}
        //}

        //private void SendEmail(TBEmailNewsletter emailNewsletter)
        //{
        //	var fromAddress = new MailAddress("your-email@example.com", "Your Name");
        //	var toAddress = new MailAddress(emailNewsletter.IdUser, emailNewsletter.IdUser);
        //	const string fromPassword = "your-email-password";
        //	string subject = emailNewsletter.Title;
        //	string body = emailNewsletter.Content;

        //	var smtp = new SmtpClient
        //	{
        //		Host = "smtp.example.com",
        //		Port = 587,
        //		EnableSsl = true,
        //		DeliveryMethod = SmtpDeliveryMethod.Network,
        //		UseDefaultCredentials = false,
        //		Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        //	};
        //	using (var message = new MailMessage(fromAddress, toAddress)
        //	{
        //		Subject = subject,
        //		Body = body,
        //		IsBodyHtml = true
        //	})
        //	{
        //		smtp.Send(message);
        //	}
        //}

        [Authorize(Roles = "Admin")]
		public IActionResult Delete(int id)
		{
			var result = iEmailNewsletter.DeleteData(id);
			if (result)
			{
				TempData["DeletedSuccessfully"] = "Deleted successfully!";
			}
			else
			{
				TempData["ErrorDelete"] = "Error deleting data!";
			}
			return RedirectToAction("MyEmailNewsletter");
		}
	}
}
