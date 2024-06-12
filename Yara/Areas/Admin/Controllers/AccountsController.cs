


namespace Yara.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class AccountsController : Controller
	{
		#region Declaration
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly MasterDbcontext _context;
		IIRolsInformation iRolsInformation;
		IIUserInformation iUserInformation;
		#endregion

		#region Constructor
		public AccountsController(RoleManager<IdentityRole> roleManager,
			UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, MasterDbcontext context, IIRolsInformation iRolsInformation1, IIUserInformation iUserInformation1)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
			iRolsInformation = iRolsInformation1;
			iUserInformation = iUserInformation1;
		}
		#endregion

		#region Method
		[Authorize(Roles = "Admin,User")]
		public IActionResult Roles()
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListIdentityRole = iRolsInformation.GetAll();
			return View(vmodel);
		}

		public IActionResult AddEditRoles(string? Id)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListIdentityRole = iRolsInformation.GetAll();
			if (Id != null)
			{
				vmodel.sIdentityRole = iRolsInformation.GetById(Convert.ToString(Id));
				return View(vmodel);
			}
			else
			{
				return View(vmodel);
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Roles(ViewmMODeElMASTER model)
		{
			if (!ModelState.IsValid)
			{
				//var role = new IdentityRole
				//{
				//    Id = model.NewRole.RoleId,
				//    Name = model.NewRole.RoleName
				//};
				// Create
				if (model.sIdentityRole.Id == null)
				{
					//role.Id = Guid.NewGuid().ToString();
					var result = await _roleManager.CreateAsync(new IdentityRole(model.sIdentityRole.Name));

					if (result.Succeeded)// Succeeded 
						SessionMsg(Helper.Success, Resource.ResourceWeb.lbSave, Resource.ResourceWeb.lbSaveMsgRole);
					else // Not Successeded
						SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotSaved, Resource.ResourceWeb.lbNotSavedMsgRole);
				}//Update
				else
				{
					var RoleUpdate = await _roleManager.FindByIdAsync(model.sIdentityRole.Id);
					RoleUpdate.Id = model.sIdentityRole.Id;
					RoleUpdate.Name = model.sIdentityRole.Name;
					var Result = await _roleManager.UpdateAsync(RoleUpdate);
					if (Result.Succeeded) // Succeeded
						SessionMsg(Helper.Success, Resource.ResourceWeb.lbUpdate, Resource.ResourceWeb.lbUpdateMsgRole);
					else  // Not Successeded
						SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotUpdate, Resource.ResourceWeb.lbNotUpdateMsgRole);
				}
			}
			return RedirectToAction("Roles");
		}
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> DeleteRole(string Id)
		{
			var role = _roleManager.Roles.FirstOrDefault(x => x.Id == Id);
			if ((await _roleManager.DeleteAsync(role)).Succeeded)
			{
				TempData["Delete successful"] = ResourceWeb.VLDeletesuccessful;
				return RedirectToAction(nameof(Roles));
			}
			else
			{
				TempData["Delete Error"] = ResourceWeb.VLDeleteError;
				return RedirectToAction("Roles");

			}
		}
		[Authorize(Roles = "Admin,User")]
		public IActionResult Registers()
		{


			//ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			//vmodel.ListVwUser = iUserInformation.GetAll();
			//return View(vmodel);





			var model = new RegisterViewModel
			{






				NewRegister = new NewRegister(),
				Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList(),
				Users = _context.VwUsers.OrderBy(x => x.Role).ToList() //_userManager.Users.OrderBy(x=>x.Name).ToList()
			};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Registers(RegisterViewModel model)
		{




			if (!ModelState.IsValid)
			{
				var file = HttpContext.Request.Form.Files;
				if (file.Count() > 0)
				{
					string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
					var fileStream = new FileStream(Path.Combine(@"wwwroot/", Helper.PathSaveImageuser, ImageName), FileMode.Create);
					file[0].CopyTo(fileStream);
					model.NewRegister.ImageUser = ImageName;
				}
				else
				{
					model.NewRegister.ImageUser = model.NewRegister.ImageUser;
				}
				var user = new ApplicationUser
				{
					Id = model.NewRegister.Id,
					Name = model.NewRegister.Name,
					UserName = model.NewRegister.Email,
					Email = model.NewRegister.Email,
					ActiveUser = model.NewRegister.ActiveUser,
					ImageUser = model.NewRegister.ImageUser,
					PhoneNumber = model.NewRegister.PhoneNumber

				};
				if (user.Id == null)
				{
					//Craete
					user.Id = Guid.NewGuid().ToString();
					var result = await _userManager.CreateAsync(user, model.NewRegister.Password);
					if (result.Succeeded)
					{
						//Succsseded
						var Role = await _userManager.AddToRoleAsync(user, model.NewRegister.RoleName);
						if (Role.Succeeded)
							SessionMsg(Helper.Success, Resource.ResourceWeb.lbSave, Resource.ResourceWeb.lbNotSavedMsgUserRole);
						else
							SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotSaved, Resource.ResourceWeb.lbNotSavedMsgUser);
					}
					else //Not Successeded
						SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotSaved, Resource.ResourceWeb.lbNotUpdateMsgUser);
				}
				else
				{
					//Update
					var userUpdate = await _userManager.FindByIdAsync(user.Id);
					userUpdate.Id = model.NewRegister.Id;
					userUpdate.Name = model.NewRegister.Name;
					userUpdate.UserName = model.NewRegister.Email;
					userUpdate.Email = model.NewRegister.Email;
					userUpdate.ActiveUser = model.NewRegister.ActiveUser;
					userUpdate.ImageUser = model.NewRegister.ImageUser;

					var result = await _userManager.UpdateAsync(userUpdate);
					if (result.Succeeded)
					{
						var oldRole = await _userManager.GetRolesAsync(userUpdate);
						await _userManager.RemoveFromRolesAsync(userUpdate, oldRole);
						var AddRole = await _userManager.AddToRoleAsync(userUpdate, model.NewRegister.RoleName);
						if (AddRole.Succeeded)
							SessionMsg(Helper.Success, Resource.ResourceWeb.lbUpdate, Resource.ResourceWeb.lbNotUpdateMsgUserRole);
						else
							SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotUpdate, Resource.ResourceWeb.lbNotUpdateMsgUserRole);
					}
					else // Not Successeded
						SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotUpdate, Resource.ResourceWeb.lbNotUpdateMsgUser);
				}
				return RedirectToAction("Registers", "Accounts");
			}
			return RedirectToAction("Registers", "Accounts");
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> DeleteUser(string userId)
		{
			var User = _userManager.Users.FirstOrDefault(x => x.Id == userId);

			if (User.ImageUser != null && User.ImageUser != Guid.Empty.ToString())
			{
				var PathImage = Path.Combine(@"wwwroot/", Helper.PathImageuser, User.ImageUser);
				if (System.IO.File.Exists(PathImage))
					System.IO.File.Delete(PathImage);
			}
			if ((await _userManager.DeleteAsync(User)).Succeeded)
				return RedirectToAction("Registers", "Accounts");

			return RedirectToAction("Registers", "Accounts");
		}

		[Authorize(Roles = "Admin,User")]
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


		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin,User")]
		public async Task<IActionResult> ChangePassword1(ViewmMODeElMASTER model1, RegisterViewModel? model)
		{
            var user = await _userManager.FindByIdAsync(model1.sUser.Id);
			if (user != null)
			{
				await _userManager.RemovePasswordAsync(user);
				var AddNewPassword = await _userManager.AddPasswordAsync(user, model1.SChangePassword.NewPassword);
				if (AddNewPassword.Succeeded)
					return RedirectToAction(nameof(Registers));
				else
					return RedirectToAction(nameof(ChangePassword1));
			}

			return RedirectToAction(nameof(Registers));

		}
		[AllowAnonymous]
		public IActionResult Login(string returnUrl)
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AllowAnonymous]
		public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				var Result = await _signInManager.PasswordSignInAsync(model.Eamil,
					model.Password, model.RememberMy, false);
				if (Result.Succeeded)
					if (returnUrl == null)
					{

						return RedirectToAction("Index", "Home", new { area = "" });
					}
					else
					{
						return Redirect(returnUrl);
					}

				else
					ViewBag.ErrorLogin = false;

			}
			return View(model);
		}
		[AllowAnonymous]
		public async Task<IActionResult> Logout1()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home", new { area = "" });
		}
		private void SessionMsg(string MsgType, string Title, string Msg)
		{
			HttpContext.Session.SetString(Helper.MsgType, MsgType);
			HttpContext.Session.SetString(Helper.Title, Title);
			HttpContext.Session.SetString(Helper.Msg, Msg);
		}
	
		[AllowAnonymous]
		public IActionResult Register(string? Id)
		{
			return View(new RegisterViewModel());
		}

		public async Task<IActionResult> EditeRegister(string? Id)
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
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AllowAnonymous]
		public async Task<IActionResult> Registers1(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				var file = HttpContext.Request.Form.Files;
				if (file.Count() > 0)
				{
					string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
					var fileStream = new FileStream(Path.Combine(@"wwwroot/", Helper.PathSaveImageuser, ImageName), FileMode.Create);
					file[0].CopyTo(fileStream);
					model.NewRegister.ImageUser = ImageName;
				}
				else
				{
					TempData["Message"] = ResourceWeb.VLimageuplode;
					return RedirectToAction("Register", model);


					//model.sUser.ImageUser = model.sUser.ImageUser;
				}
				var user = new ApplicationUser
				{
					Id = model.NewRegister.Id,
					Name = model.NewRegister.Name,
					UserName = model.NewRegister.Email,
					Email = model.NewRegister.Email,
					ActiveUser = model.NewRegister.ActiveUser,
					ImageUser = model.NewRegister.ImageUser,
					PhoneNumber = model.NewRegister.PhoneNumber
				};
				if (user.Id == null)
				{
					//Craete
					user.Id = Guid.NewGuid().ToString();
					var result = await _userManager.CreateAsync(user, model.NewRegister.Password);
					if (result.Succeeded)
					{
						//Succsseded				
						//var myuser = await _userManager.FindByEmailAsync(user.Email);
						var myuser = await _userManager.FindByIdAsync(user.Id);
						var toaw = await _userManager.AddToRoleAsync(myuser, "Basic");
						var loginResulte = await _signInManager.PasswordSignInAsync(user, model.NewRegister.Password, true, true);
						if (toaw.Succeeded)
							return RedirectToAction("Index", "Home", new { area = "" });
						else
							return RedirectToAction("Register");
					}
					else //Not Successeded
						TempData["Message2"] = ResourceWeb.VLEmailOreUserOrPaswo;

					return RedirectToAction("Register", model);
				}
				else
				{
					//Update
					var userUpdate = await _userManager.FindByIdAsync(user.Id);


					userUpdate.Id = user.Id;
					userUpdate.Name = user.Name;
					userUpdate.UserName = user.Email;
					userUpdate.Email = user.Email;
					userUpdate.ActiveUser = user.ActiveUser;
					userUpdate.ImageUser = user.ImageUser;
					var result = await _userManager.UpdateAsync(userUpdate);
					if (result.Succeeded)
					{
						//var oldRole = await _userManager.GetRolesAsync(userUpdate);
						//await _userManager.RemoveFromRolesAsync(userUpdate, oldRole);
						//var AddRole = await _userManager.AddToRoleAsync(userUpdate, model.NewRegister.RoleName);
						////if (AddRole.Succeeded)
						SessionMsg(Helper.Success, Resource.ResourceWeb.lbUpdate, Resource.ResourceWeb.lbNotUpdateMsgUserRole);

					}
					else
					{
						SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotUpdate, Resource.ResourceWeb.lbNotUpdateMsgUserRole);
					}

				}
			}
			return RedirectToAction("regesters");
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AllowAnonymous]
		public async Task<IActionResult> RegistersEdite(ViewmMODeElMASTER model, List<IFormFile> Files, string returnUrl,string? Id)
		{
			if (!ModelState.IsValid)
			{
				var file = HttpContext.Request.Form.Files;
				if (file.Count() > 0)
				{
					string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
					var fileStream = new FileStream(Path.Combine(@"wwwroot/", Helper.PathSaveImageuser, ImageName), FileMode.Create);
					file[0].CopyTo(fileStream);
					model.sUser.ImageUser = ImageName;
				}
				else
				{
					model.sUser.ImageUser = model.sUser.ImageUser;
				}
				var user = new ApplicationUser
				{
					Id = model.sUser.Id,
					Name = model.sUser.Name,
					UserName = model.sUser.Email,
					Email = model.sUser.Email,
					ActiveUser = model.sUser.ActiveUser,
					ImageUser = model.sUser.ImageUser,
					PhoneNumber = model.sUser.PhoneNumber
				};
				var userUpdate = await _userManager.FindByIdAsync(user.Id);
				userUpdate.Id = user.Id;
				userUpdate.Name = user.Name;
				userUpdate.UserName = user.Email;
				userUpdate.Email = user.Email;
				userUpdate.ActiveUser = user.ActiveUser;
				userUpdate.ImageUser = user.ImageUser;
				userUpdate.PhoneNumber = user.PhoneNumber;
				var result = await _userManager.UpdateAsync(userUpdate);
				if (result.Succeeded)

				{
					return RedirectToAction("Registers");
					//var oldRole = await _userManager.GetRolesAsync(userUpdate);
					//await _userManager.RemoveFromRolesAsync(userUpdate, oldRole);
					//var AddRole = await _userManager.AddToRoleAsync(userUpdate, model.ruser.NewRegister.RoleName);
					//if (AddRole.Succeeded)
					//	SessionMsg(Helper.Success, Resource.ResourceWeb.lbUpdate, Resource.ResourceWeb.lbNotUpdateMsgUserRole);
					//else
					//	SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotUpdate, Resource.ResourceWeb.lbNotUpdateMsgUserRole);
				}
				else // Not Successeded
					SessionMsg(Helper.Error, Resource.ResourceWeb.lbNotUpdate, Resource.ResourceWeb.lbNotUpdateMsgUser);
				return RedirectToAction("regesters");
			}
			return RedirectToAction("regesters");
		}
	}

	#endregion
}
