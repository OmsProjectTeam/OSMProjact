using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
	public class FAQListController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
