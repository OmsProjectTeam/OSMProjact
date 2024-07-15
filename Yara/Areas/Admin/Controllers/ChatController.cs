using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class ChatController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
