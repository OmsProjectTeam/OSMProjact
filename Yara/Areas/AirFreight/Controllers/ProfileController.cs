

namespace Yara.Areas.AirFreight.Controllers
{
	[Area("AirFreight")]
	[Authorize(Roles = "Admin,AirFreight")]
	public class ProfileController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		IIUserInformation iUserInformation;
		public ProfileController(UserManager<ApplicationUser> userManager, IIUserInformation iUserInformation1)
        {
			_userManager = userManager;
			iUserInformation= iUserInformation1;
		}
		public async Task<IActionResult> MyProfile(string? id)
		{


			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
				return NotFound();

			return View(user);
		}

		public async Task<IActionResult> ShowUserData(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
				return NotFound();

			return View(user);
		}
	}
}
