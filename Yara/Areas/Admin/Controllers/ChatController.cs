using Domin.Entity.SignalR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class ChatController : Controller
	{
		IIConnectAndDisconnect iConnectAndDisconnect;
		IIUserInformation iUserInformation;
		IIMessageChat iMessageChat;
		UserManager<ApplicationUser> iUserManager;
		public ChatController(IIConnectAndDisconnect iConnectAndDisconnect1, IIMessageChat iMessageChat1, IIUserInformation iUserInformation1, UserManager<ApplicationUser> iUserManager1)
		{
			iConnectAndDisconnect = iConnectAndDisconnect1;
			iMessageChat = iMessageChat1;
			iUserInformation = iUserInformation1;
			iUserManager = iUserManager1;

		}
		public async Task<IActionResult> Index()
		{
            ViewmMODeElMASTER viewmMODeElMASTER = new ViewmMODeElMASTER();
            var currentUserId = iUserManager.GetUserId(User);

			viewmMODeElMASTER.ViewChatMessage = iMessageChat.GetByReciverId(currentUserId);
			

            return View(viewmMODeElMASTER);
		}

		public async Task<IActionResult> OwnChat(string anotherId) 
		{
            ViewmMODeElMASTER viewmMODeElMASTER = new ViewmMODeElMASTER();
            var users = viewmMODeElMASTER.ConnectAndDisConnect = iConnectAndDisconnect.GetAll();

            var currentUserId = iUserManager.GetUserId(User);

            var IamSender = iMessageChat.GetBySenderIdAndReciverId(currentUserId, anotherId);
            var IamReciver = iMessageChat.GetBySenderIdAndReciverId(anotherId, currentUserId);

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
			if (viewmMODeElMASTER!=null)
			{
                return View(viewmMODeElMASTER);
            }
			else { return View(null); }

            return View(viewmMODeElMASTER);
        }
	}
}
