
namespace Yara.Areas.merchantAccount.Controllers
{
	[Area("merchantAccount")]
	[Authorize(Roles = "Admin,Merchant")]
	public class ProfileController : Controller
	{
		IIMerchant iMerchant;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProfileController(IIMerchant iMerchant1, UserManager<ApplicationUser> userManager)
		{
            iMerchant = iMerchant1;
			_userManager = userManager;
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
