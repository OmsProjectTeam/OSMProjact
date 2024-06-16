

namespace Yara.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class OrderController : Controller
	{
        public OrderController()
        {
            
        }
        public IActionResult Index()
		{
			return View();
		}
	}
}
