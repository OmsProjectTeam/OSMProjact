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
			var users = viewmMODeElMASTER.ConnectAndDisConnect = iConnectAndDisconnect.GetAll();

			var currentUserId = iUserManager.GetUserId(User);

			var secundUser = await iUserManager.FindByNameAsync("a@a.com");
			var secundUserId = secundUser.Id;

			var IamSender = viewmMODeElMASTER.ViewChatMessage = iMessageChat.GetBySenderIdAndReciverId(currentUserId, secundUserId);
			var IamReciver = viewmMODeElMASTER.ViewChatMessage = iMessageChat.GetBySenderIdAndReciverId(secundUserId, currentUserId);

			return View(viewmMODeElMASTER);
		}
	}
}
