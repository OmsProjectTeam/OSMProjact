using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.ClintAccount.Controllers
{
	[Area("ClintAccount")]
	[Authorize(Roles = "Admin,Customer")]
	public class ChatController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
