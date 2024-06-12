

using Microsoft.AspNetCore.Authorization;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		[AllowAnonymous]
		public IActionResult Denied()
        {
            return View();
        }
    }
}
