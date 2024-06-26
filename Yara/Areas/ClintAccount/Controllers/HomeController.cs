
using Domin.Entity;
using Infarstuructre.BL;
using System.Diagnostics;

namespace Yara.Areas.ClintAccount.Controllers;

[Area("ClintAccount")]
[Authorize(Roles = "Admin,Customer")]
public class HomeController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
	IIUserInformation iUserInformation;

	public HomeController(UserManager<ApplicationUser> userManager, IIUser iUser,IIUserInformation iUserInformation1)
	{
		_userManager = userManager;
		iUserInformation= iUserInformation1;
	}
	public async Task<IActionResult> Index(string userId)
	{


		
		return View();
	}
}
