using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.AirFreight.Controllers
{
	[Area("AirFreight")]
	[Authorize(Roles = "Admin,AirFreight")]
	public class HomeController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		public HomeController(UserManager<ApplicationUser> userManager, IIUser iUser)
        {
			_userManager = userManager;
		}
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				return NotFound();

			var role = await _userManager.GetRolesAsync(user);

			ViewBag.UserName = user.UserName;
			ViewBag.UserId = user.Id;
			ViewBag.UserImage = user.ImageUser;
			ViewBag.Name = user.Name;
			ViewBag.UserRole = role[0];
			return View(user);
		}
	}
}
