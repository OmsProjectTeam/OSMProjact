using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Yara.Areas.ClintAccount.Controllers
{
    [Area("ClintAccount")]
    [Authorize(Roles = "Admin,Customer")]
    public class ChatController : Controller
    {
        IIConnectAndDisconnect iConnectAndDisconnect;
        IIUserInformation iUserInformation;
        IIMessageChat iMessageChat;
        UserManager<ApplicationUser> iUserManager;
        IIFAQ iFAQ;
        IIFAQList iFAQList;
        IIFAQDescreption iFAQDescreption;
        MasterDbcontext dbcontext;
        public ChatController(IIConnectAndDisconnect iConnectAndDisconnect1, IIMessageChat iMessageChat1, IIUserInformation iUserInformation1, UserManager<ApplicationUser> iUserManager1, IIFAQ iFAQ1, IIFAQDescreption iFAQDescreption1, IIFAQList iFAQList1, MasterDbcontext dbcontext)
        {
            iConnectAndDisconnect = iConnectAndDisconnect1;
            iMessageChat = iMessageChat1;
            iUserInformation = iUserInformation1;
            iUserManager = iUserManager1;
            iFAQ = iFAQ1;
            iFAQDescreption = iFAQDescreption1;
            iFAQList = iFAQList1;
            this.dbcontext = dbcontext;
        }
        //      public async Task<IActionResult> Index()
        //{

        //	ViewmMODeElMASTER viewmMODeElMASTER = new ViewmMODeElMASTER();
        //	var currentUserId = iUserManager.GetUserId(User);

        //	viewmMODeElMASTER.ViewChatMessage = iMessageChat.GetByReciverId(currentUserId);

        //          var admins = iUserInformation.GetAllbyRole();
        //          var support = iUserInformation.GetActiveSupport();

        //	List<VwUser> avilable = new List<VwUser>();
        //	avilable = admins;

        //          foreach (var item in support)
        //	{
        //              avilable.Add(item);
        //          } 

        //	viewmMODeElMASTER.Users = avilable;
        //	ViewBag.Supports = support;

        //          viewmMODeElMASTER.ListFAQ = iFAQ.GetAll();
        //	viewmMODeElMASTER.ListFAQDescription = iFAQDescreption.GetAll();
        //	viewmMODeElMASTER.ListFAQList = iFAQList.GetAll();

        //          return View(viewmMODeElMASTER);
        //}

        public async Task<IActionResult> Index()
        {
            ViewmMODeElMASTER viewModel = new ViewmMODeElMASTER();
            var currentUserId = iUserManager.GetUserId(User);

            viewModel.ViewChatMessage = iMessageChat.GetByReciverId(currentUserId);

            var admins = iUserInformation.GetAllbyRole();
            var support = iUserInformation.GetActiveSupport();

            List<VwUser> avilable = new List<VwUser>();
            avilable = admins;

            foreach (var item in support)
            {
                avilable.Add(item);
            }

            viewModel.Users = avilable;
            ViewBag.Supports = support;

            viewModel.ListFAQ = iFAQ.GetAll();
            viewModel.ListFAQDescription = iFAQDescreption.GetAll();
            viewModel.ListFAQList = iFAQList.GetAll();

            return View(viewModel);
        }

        [HttpGet]
        [Route("/ClintAccount/Chat/OwnChat/{anotherId}")]
        public async Task<IActionResult> OwnChat(string anotherId)
        {
            var viewModel = new ViewmMODeElMASTER();
            var currentUserId = iUserManager.GetUserId(User);

            var IamSender = iMessageChat.GetBySenderIdAndReciverId(currentUserId, anotherId);
            var IamReciver = iMessageChat.GetBySenderIdAndReciverId(anotherId, currentUserId);
            IamSender.AddRange(IamReciver);

            viewModel.ViewChatMessage = IamSender.OrderBy(m => m.MessageeTime).ToList();
            ViewBag.another = iUserInformation.GetById(anotherId).UserName;
            ViewBag.anotherId = anotherId;
            ViewBag.img = iUserInformation.GetById(currentUserId).ImageUser;
            ViewBag.UserId = currentUserId;

            return View(viewModel);
        }

        [HttpPost]
        [Route("ClintAccount/Chat/UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Ok("null");

            string fileName = Guid.NewGuid().ToString();
            var filePath = Path.Combine("wwwroot/Images/Home/", fileName + file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { filePath = $"/Images/Home/{file.FileName}" });
        }

        [HttpGet]
        [Route("/ClintAccount/Chat/GetMessages")]
        public async Task<IActionResult> GetMessages(string anotherId)
        {
            var currentUserId = iUserManager.GetUserId(User);

            var IamSender = iMessageChat.GetBySenderIdAndReciverId(currentUserId, anotherId);
            var IamReciver = iMessageChat.GetBySenderIdAndReciverId(anotherId, currentUserId);
            IamSender.AddRange(IamReciver);

            var messages = IamSender.OrderBy(m => m.MessageeTime).Select(m => new
            {
                m.Message,
                m.SenderId,
                m.ReciverId,
                m.ImgMsg,
                m.MessageeTime
            }).ToList();

            return Json(messages);
        }

        //[HttpGet]
        //      [Route("/ClintAccount/Chat/OwnChat/{anotherId}")]
        //      public async Task<IActionResult> OwnChat(string anotherId)
        //      {
        //	ViewmMODeElMASTER viewmMODeElMASTER = new ViewmMODeElMASTER();

        //	var currentUserId = iUserManager.GetUserId(User);



        //	var IamSender = iMessageChat.GetBySenderIdAndReciverId(currentUserId, anotherId);
        //	var IamReciver = iMessageChat.GetBySenderIdAndReciverId(anotherId, currentUserId);


        //	foreach (var item in IamReciver)
        //	{
        //		IamSender.Add(item);
        //	}

        //	viewmMODeElMASTER.ViewChatMessage = IamSender;
        //	ViewBag.another = (iUserInformation.GetById(anotherId)).UserName;
        //	ViewBag.anotherId = (iUserInformation.GetById(anotherId)).Id;

        //	//viewmMODeElMASTER.ViewChatMessage = iMessageChat.GetByReciverId(currentUserId);
        //	ViewBag.img = (iUserInformation.GetById(currentUserId)).ImageUser;
        //	ViewBag.UserId = currentUserId;

        //          /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //          ///
        //          ////For Send Email
        //          //var anotherUser = await iUserManager.FindByIdAsync(anotherId);
        //          //var user = await iUserManager.GetUserAsync(User);
        //          /////////////////////////////////////////////////////////////
        //          //var emailSetting = await dbcontext.TBEmailAlartSettings
        //          //              .OrderByDescending(n => n.IdEmailAlartSetting)
        //          //              .Where(a => a.CurrentState == true && a.Active == true)
        //          //              .FirstOrDefaultAsync(); 

        //          //if (emailSetting != null)
        //          //{
        //          //    var message = new MimeMessage();
        //          //    message.From.Add(new MailboxAddress("New Order", emailSetting.MailSender));
        //          //    message.To.Add(new MailboxAddress("saif aldin", "saifaldin_s@hotmail.com"));
        //          //    message.Subject = "محادثة جديدة";
        //          //    var builder = new BodyBuilder
        //          //    {
        //          //        TextBody = $"تجري محادثة حاليا بين {anotherUser.Name}  و {user.Name}"
        //          //    };

        //          //    message.Body = builder.ToMessageBody();

        //          //    using (var client = new SmtpClient())
        //          //    {
        //          //        await client.ConnectAsync(emailSetting.SmtpServer, emailSetting.PortServer, SecureSocketOptions.StartTls);
        //          //        await client.AuthenticateAsync(emailSetting.MailSender, emailSetting.PasswordEmail);
        //          //        await client.SendAsync(message);
        //          //        await client.DisconnectAsync(true);
        //          //    }
        //          //}
        //          ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //          ///
        //          return View(viewmMODeElMASTER);
        //}

        //[HttpPost]
        //       [Route("ClintAccount/Chat/UploadFile")]
        //       public async Task<IActionResult> UploadFile(IFormFile file)
        //       {
        //           if (file == null || file.Length == 0)
        //               return Ok("null");

        //           string fileName = Guid.NewGuid().ToString();
        //           var filePath = Path.Combine("wwwroot/Images/Home/", fileName+file.FileName);

        //           using (var stream = new FileStream(filePath, FileMode.Create))
        //           {
        //               await file.CopyToAsync(stream);
        //           }

        //           return Ok(new { filePath = $"/Images/Home/{file.FileName}" });
        //       }
        //   }

    }
}

