using Domin.Entity.SignalR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ChatController : Controller
    {
        MasterDbcontext db;
        IIConnectAndDisconnect iConnectAndDisconnect;
        IIUserInformation iUserInformation;
        IIMessageChat iMessageChat;
        UserManager<ApplicationUser> iUserManager;
        public ChatController(IIConnectAndDisconnect iConnectAndDisconnect1, IIMessageChat iMessageChat1, IIUserInformation iUserInformation1, UserManager<ApplicationUser> iUserManager1, MasterDbcontext db)
        {
            iConnectAndDisconnect = iConnectAndDisconnect1;
            iMessageChat = iMessageChat1;
            iUserInformation = iUserInformation1;
            iUserManager = iUserManager1;
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            ViewmMODeElMASTER viewmMODeElMASTER = new ViewmMODeElMASTER();
            var currentUserId = iUserManager.GetUserId(User);

            viewmMODeElMASTER.ViewChatMessage = iMessageChat.GetByReciverId(currentUserId);


            return View(viewmMODeElMASTER);
        }

        [AllowAnonymous]
        [HttpGet("OwnChat/{anotherId}")]
        [Route("/Admin/Chat/OwnChat/{anotherId}")]
        public async Task<IActionResult> OwnChat(string anotherId)
        {
            ViewmMODeElMASTER viewmMODeElMASTER = new ViewmMODeElMASTER();
            var users = viewmMODeElMASTER.ConnectAndDisConnect = iConnectAndDisconnect.GetAll();

            var currentUserId = iUserManager.GetUserId(User);
            ViewBag.MyId1 = currentUserId;

            var IamSender = iMessageChat.GetBySenderIdAndReciverId(currentUserId, anotherId);
            var IamReciver = iMessageChat.GetBySenderIdAndReciverId(anotherId, currentUserId);
            ///////////////////////////////////////////////////////////////////////////////////////////

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            foreach (var item in IamReciver)
            {
                IamSender.Add(item);
            }

            viewmMODeElMASTER.ViewChatMessage = IamSender;
            ViewBag.another = (iUserInformation.GetById(anotherId)).UserName;
            ViewBag.anotherId = (iUserInformation.GetById(anotherId)).Id;
            //viewmMODeElMASTER.ViewChatMessage = iMessageChat.GetByReciverId(currentUserId);
            ViewBag.img = (iUserInformation.GetById(currentUserId)).ImageUser;
            ViewBag.UserId = currentUserId;

            return View(viewmMODeElMASTER);
        }

        [HttpGet("Refresh/{anotherId}")]
        [Route("/Admin/Chat/Refresh/{anotherId}")]
        public async Task<IActionResult> Refresh(string anotherId)
        {
            ViewmMODeElMASTER viewmMODeElMASTER1 = new ViewmMODeElMASTER();

            var currentUserId = iUserManager.GetUserId(User);
            var IamSender = iMessageChat.GetBySenderIdAndReciverId(currentUserId, anotherId);
            var IamReciver = iMessageChat.GetBySenderIdAndReciverId(anotherId, currentUserId);

            foreach (var item in IamReciver)
            {
                IamSender.Add(item);
            }

            viewmMODeElMASTER1.ViewChatMessage = IamSender;
            ViewBag.UserId = currentUserId;

            return PartialView("Refresh", viewmMODeElMASTER1);
        }



        [HttpPost]
        [Route("/Admin/chat/uploadFile")]
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
    }
}
