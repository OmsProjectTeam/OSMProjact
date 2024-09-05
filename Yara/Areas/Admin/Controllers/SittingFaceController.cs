using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class SittingFaceController : Controller
    {
        public IActionResult MySittingFace()
        {
            return View();
        }
        public IActionResult MyPricingSystem()
        {
            return View();
        }
    }
}
