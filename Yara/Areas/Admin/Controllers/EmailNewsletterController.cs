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
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListEmailNewsletters = iEmailNewsletter.GetAll();
            if (IdEmailNewsletter != null)
			{
                vmodel.EmailNewsletter = iEmailNewsletter.GetById(Convert.ToInt32(IdEmailNewsletter));
            }
			return View(vmodel);
		}

		public IActionResult AddEmailNewsletterAr(int? IdEmailNewsletter)
		{
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListEmailNewsletters = iEmailNewsletter.GetAll();
            if (IdEmailNewsletter != null)
            {
                vmodel.EmailNewsletter = iEmailNewsletter.GetById(Convert.ToInt32(IdEmailNewsletter));
            }
            return View(vmodel);
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
                    var reqwest = iEmailNewsletter.saveData(slider);
                    if (reqwest == true)
                    {
						var emailSetting = await dbcontext.TBEmailAlartSettings
						  .OrderByDescending(n => n.IdEmailAlartSetting)
						  .Where(a => a.CurrentState == true && a.Active == true)
						  .FirstOrDefaultAsync();
						// التحقق من وجود إعدادات البريد الإلكتروني
						if (emailSetting != null)
						{
							var message = new MimeMessage();
							message.From.Add(new MailboxAddress("New new message", emailSetting.MailSender));
							message.To.Add(new MailboxAddress("Hi", slider.MailSender));
                            message.Subject = "أهلا بك بالنشرة البريدية";
							var builder = new BodyBuilder
							{
								TextBody = $"اهلا بك بين عائلتنا  \n" +
										   $"ستكون على اطلاع دائم  بكل العروض واحدث الخصوم\n" +
										   $"تاريخ : {slider.DateTimeEntry}\n" +
										   $"سيتم أعتماد هذا البريد لتظل على إطلاع دائم : {slider.MailSender}\n"

							};

							

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
						return RedirectToAction("MyEmailNewsletter");
						
                        
                    }
                    else
                    {
                        //var PhotoNAme = slider.Photo;
                        //var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
				else
				{
					// Update logic if needed
					var reqwest = iEmailNewsletter.UpdateData(slider);
					if (reqwest == true)
					{
						TempData["Updated successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyEmailNewsletter");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}
			}
			catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
				return Redirect(returnUrl);
			}
        }

        [Authorize(Roles = "Admin")]
		public IActionResult Delete(int IdEmailNewsletter)
		{
			var result = iEmailNewsletter.DeleteData(IdEmailNewsletter);
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
