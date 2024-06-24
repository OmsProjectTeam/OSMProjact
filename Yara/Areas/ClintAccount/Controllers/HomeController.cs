
using System.Diagnostics;

namespace Yara.Areas.ClintAccount.Controllers;

[Area("ClintAccount")]
[Authorize(Roles = "Admin,Customer")]
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
		return View();
	}
}
