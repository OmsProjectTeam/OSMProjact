using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.ClintAccount.Controllers;

[Area("ClintAccount")]
[Authorize(Roles = "Admin,Customer")]
public class ProfileController : Controller
{
	private readonly UserManager<ApplicationUser> _userManager;

	public ProfileController(UserManager<ApplicationUser> userManager)
	{
		_userManager = userManager;
	}

	public async Task<IActionResult> MyProfile(string id)
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
