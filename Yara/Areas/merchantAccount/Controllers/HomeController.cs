using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.merchantAccount.Controllers
{
    [Area("merchantAccount")]
    [Authorize(Roles = "Admin,Customer")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
