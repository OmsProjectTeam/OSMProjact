
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
        public async Task<IActionResult> MyProfile(string id)
        {
            // Get the current logged-in user
            var user = await _userManager.GetUserIdAsync(string id);
            if (user == null)
            {
                return Unauthorized();
            }
            //if (!int.TryParse(user.Id, out int merchantId))
            //{
            //    return BadRequest("Invalid merchant ID.");
            //}

            //var merchant = await iMerchant.GetMerchantAsync(merchantId);
            //if (merchant == null)
            //{
            //    return NotFound();
            //}

            var viewModel = new ViewmMODeElMASTER
            {
                Merchant = merchant
            };

            return View(viewModel);
        }
    }
}
