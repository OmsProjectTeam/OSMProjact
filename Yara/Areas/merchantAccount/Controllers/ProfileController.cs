﻿
using Infarstuructre.BL;

namespace Yara.Areas.merchantAccount.Controllers
{
    [Area("merchantAccount")]
    [Authorize(Roles = "Admin,Merchant")]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIUserInformation iUserInformation;
        private readonly IHttpClientFactory _httpClient;


        public ProfileController(UserManager<ApplicationUser> userManager, IHttpClientFactory httpClient, IIUserInformation iUserInformation)
        {
            _userManager = userManager;
            _httpClient = httpClient;
            this.iUserInformation = iUserInformation;
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

		public async Task<IActionResult> MyProfileAr(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
				return NotFound();

			return View(user);
		}

		public async Task<IActionResult> ShowUserData(string id)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			//vmodel.ListVwUser = iUserInformation.GetAll();
			if (id != null)
			{
				vmodel.sUser = iUserInformation.GetById(Convert.ToString(id));
				return View(vmodel);
			}
			else
			{
				return View(new RegisterViewModel());
			}
		}

		public async Task<IActionResult> ShowUserDataAr(string id)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			//vmodel.ListVwUser = iUserInformation.GetAll();
			if (id != null)
			{
				vmodel.sUser = iUserInformation.GetById(Convert.ToString(id));
				return View(vmodel);
			}
			else
			{
				return View(new RegisterViewModel());
			}
		}

		public IActionResult ChangePassword(string Id)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			//vmodel.ListVwUser = iUserInformation.GetAll();
			if (Id != null)
			{
				vmodel.sUser = iUserInformation.GetById(Convert.ToString(Id));
				return View(vmodel);
			}
			else
			{
				return View(new RegisterViewModel());
			}
		}

		public IActionResult ChangePasswordAr(string Id)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			//vmodel.ListVwUser = iUserInformation.GetAll();
			if (Id != null)
			{
				vmodel.sUser = iUserInformation.GetById(Convert.ToString(Id));
				return View(vmodel);
			}
			else
			{
				return View(new RegisterViewModel());
			}
		}
	}

    }


