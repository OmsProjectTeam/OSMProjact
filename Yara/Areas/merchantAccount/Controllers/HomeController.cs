using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.merchantAccount.Controllers
{
    [Area("merchantAccount")]
    [Authorize(Roles = "Admin,Merchant")]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        IIUserInformation iUserInformation;

        public HomeController(UserManager<ApplicationUser> userManager, IIUser iUser, IIUserInformation iUserInformation1)
        {
            _userManager = userManager;
            iUserInformation = iUserInformation1;
        }
        public async Task<IActionResult> Index(string userId)
        {



            return View();
        }

		public async Task<IActionResult> IndexAr()
		{
			//var user = await _userManager.GetUserAsync(User);
			//if (user == null)
			//    return NotFound();

			//var role = await _userManager.GetRolesAsync(user);

			//ViewBag.UserName = user.UserName;
			//ViewBag.UserId = user.Id;
			//ViewBag.UserImage = user.ImageUser;
			//ViewBag.Name = user.Name;
			//ViewBag.UserRole = role[0];
			return View();
		}

	}
}
