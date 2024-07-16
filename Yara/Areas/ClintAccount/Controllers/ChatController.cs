using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.ClintAccount.Controllers
{
	[Area("ClintAccount")]
	[Authorize(Roles = "Admin,Customer")]
	public class ChatController : Controller
	{
		IIConnectAndDisconnect iConnectAndDisconnect;
        public ChatController(IIConnectAndDisconnect iConnectAndDisconnect1)
        {
            iConnectAndDisconnect = iConnectAndDisconnect1;
        }
        public IActionResult Index()
		{
			ViewmMODeElMASTER viewmMODeElMASTER = new ViewmMODeElMASTER();
			var users = viewmMODeElMASTER.ConnectAndDisConnect = iConnectAndDisconnect.GetAll();

			if(users != null)
			{
                return View(viewmMODeElMASTER);
            }

            return View();
		}
	}
}
