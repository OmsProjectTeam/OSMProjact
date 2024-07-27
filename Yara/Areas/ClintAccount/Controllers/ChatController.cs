using Microsoft.AspNetCore.Mvc;

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
        public ChatController(IIConnectAndDisconnect iConnectAndDisconnect1, IIMessageChat iMessageChat1, IIUserInformation iUserInformation1, UserManager<ApplicationUser> iUserManager1, IIFAQ iFAQ1, IIFAQDescreption iFAQDescreption1, IIFAQList iFAQList1)
        {
            iConnectAndDisconnect = iConnectAndDisconnect1;
			iMessageChat = iMessageChat1;
			iUserInformation = iUserInformation1;
			iUserManager = iUserManager1;
			iFAQ = iFAQ1;
            iFAQDescreption = iFAQDescreption1;
			iFAQList = iFAQList1;

        }
        public async Task<IActionResult> Index()
		{

			ViewmMODeElMASTER viewmMODeElMASTER = new ViewmMODeElMASTER();
			var currentUserId = iUserManager.GetUserId(User);

			viewmMODeElMASTER.ViewChatMessage = iMessageChat.GetByReciverId(currentUserId);

            var admins = iUserInformation.GetAllbyRole();
            var support = iUserInformation.GetActiveSupport();

			List<VwUser> avilable = new List<VwUser>();
			avilable = admins;

            foreach (var item in support)
			{
                avilable.Add(item);
            } 

			viewmMODeElMASTER.Users = avilable;


            viewmMODeElMASTER.ListFAQ = iFAQ.GetAll();
			viewmMODeElMASTER.ListFAQDescription = iFAQDescreption.GetAll();
			viewmMODeElMASTER.ListFAQList = iFAQList.GetAll();

            return View(viewmMODeElMASTER);
		}

        public async Task<IActionResult> OwnChat(string anotherId)
        {
			ViewmMODeElMASTER viewmMODeElMASTER = new ViewmMODeElMASTER();

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

			return View(viewmMODeElMASTER);
		}
    }
}
