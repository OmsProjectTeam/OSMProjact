

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
		public async Task<IActionResult> MyProfile(string userId)
		{

			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			var userd = vmodel.sUser = iUserInformation.GetById(userId);
		
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
				return NotFound();

			return View(vmodel);
		}

		public async Task<IActionResult> MyProfileAr(string userId)
		{

			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			var userd = vmodel.sUser = iUserInformation.GetById(userId);

			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
				return NotFound();

			return View(vmodel);
		}




		public async Task<IActionResult> ShowUserData(string userId)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			//vmodel.ListVwUser = iUserInformation.GetAll();
			if (userId != null)
			{
				vmodel.sUser = iUserInformation.GetById(Convert.ToString(userId));
				return View(vmodel);
			}
			else
			{
				return View(new RegisterViewModel());
			}
		}

        public async Task<IActionResult> ShowUserDataAr(string userId)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            //vmodel.ListVwUser = iUserInformation.GetAll();
            if (userId != null)
            {
                vmodel.sUser = iUserInformation.GetById(Convert.ToString(userId));
                return View(vmodel);
            }
            else
            {
                return View(new RegisterViewModel());
            }
        }


        public IActionResult ChangePassword(string userId)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			//vmodel.ListVwUser = iUserInformation.GetAll();
			if (userId != null)
			{
				vmodel.sUser = iUserInformation.GetById(Convert.ToString(userId));
				return View(vmodel);
			}
			else
			{
				return View(new RegisterViewModel());
			}
		}

		public IActionResult ChangePasswordAr(string userId)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			//vmodel.ListVwUser = iUserInformation.GetAll();
			if (userId != null)
			{
				vmodel.sUser = iUserInformation.GetById(Convert.ToString(userId));
				return View(vmodel);
			}
			else
			{
				return View(new RegisterViewModel());
			}
		}
	}
}
