


using Domin.Entity;
using Infarstuructre.BL;
using LamarModa.Api.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using static Domin.Entity.Helper;

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
        private readonly ITokenService _tokenService;
        private readonly MasterDbcontext _context;
        IIRolsInformation iRolsInformation;
        IIUserInformation iUserInformation;
        IIUser iUser;
        #endregion

        #region Constructor
        public AccountsController(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, MasterDbcontext context, IIRolsInformation iRolsInformation1, IIUserInformation iUserInformation1, ITokenService tokenService, IIUser iUser1)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            iRolsInformation = iRolsInformation1;
            iUserInformation = iUserInformation1;
            _tokenService = tokenService;
            _context = context;
            iUser = iUser1;

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

        [Authorize(Roles = "Admin,User")]
        public IActionResult RolesAr()
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

        public IActionResult AddEditRolesAr(string? Id)
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





            var model = new ViewmMODeElMASTER
            {

                NewRegister = new NewRegister(),
                Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList(),
                Users = _context.VwUsers.OrderBy(x => x.Role).Where(a => a.ActiveUser == true).ToList() //_userManager.Users.OrderBy(x=>x.Name).ToList()
            };
            return View(model);
        }

        public IActionResult RegistersAr()
        {


            //ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            //vmodel.ListVwUser = iUserInformation.GetAll();
            //return View(vmodel);





            var model = new ViewmMODeElMASTER
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
                    ActiveUser = true,
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

        [AllowAnonymous]
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

        [Authorize(Roles = "Admin,User")]
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



        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword1(ViewmMODeElMASTER model1, RegisterViewModel? model)
        {
            var user = await _userManager.FindByIdAsync(model1.sUser.Id);
            if (user != null)
            {
                await _userManager.RemovePasswordAsync(user);
                var AddNewPassword = await _userManager.AddPasswordAsync(user, model1.SChangePassword.NewPassword);
                var roles = await _userManager.GetRolesAsync(user);
                if (AddNewPassword.Succeeded)
                {
                    if (roles.Contains("Customer"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "ClintAccount", userId = user.Id });
                    }
                    if (roles.Contains("AirFreight"))
                    {

                        return RedirectToAction("Index", "Home", new { area = "AirFreight", userId = user.Id });
                    }
                    if (roles.Contains("Merchant"))
                    {
                        // Redirect to merchant area with user ID
                        return RedirectToAction("Index", "Home", new { area = "merchantAccount", userId = user.Id });
                    }
                    if (roles.Contains("Admin"))
                    {
                        // Redirect to merchant area with user ID
                        return RedirectToAction("Index", "Home", new { area = "Admin", userId = user.Id });
                    }
                    return RedirectToAction(nameof(Registers));
                }
                else
                    return RedirectToAction("Index", "Home", new { area = "", userId = user.Id });
            }

            return RedirectToAction(nameof(Registers));

        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult LoginAr(string returnUrl)
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
                ApplicationUser user = await _userManager.FindByEmailAsync(model.Eamil);
                var Result = await _signInManager.PasswordSignInAsync(model.Eamil,
                    model.Password, model.RememberMy, false);
                if (Result.Succeeded)
                {
                    bool x = user.IsOnline;
                    user.IsOnline = true;
                    await _userManager.UpdateAsync(user);
                    await _context.SaveChangesAsync();
                    var roles = await _userManager.GetRolesAsync(user);
                    var token = _tokenService.GenerateToken(user, roles);

                    // Check if user has the role "Merchant"
                    if (roles.Contains("Merchant"))
                    {
                        // Redirect to merchant area with user ID
                        return RedirectToAction("Index", "Home", new { area = "merchantAccount", userId = user.Id, token = token });
                    }
                    // Check if user has the role "Customer"
                    if (roles.Contains("Customer"))
                    {
                        // Redirect to merchant area with user ID
                        return RedirectToAction("Index", "Home", new { area = "ClintAccount", userId = user.Id, token = token });
                    }// Check if user has the role "Admin"
                    if (roles.Contains("Admin"))
                    {
                        // Redirect to merchant area with user ID
                        return RedirectToAction("Index", "Home", new { area = "Admin", userId = user.Id, token = token });
                    }// Check if user has the role "Admin"
                    if (roles.Contains("AirFreight"))
                    {
                        // Redirect to AirFreight area with user ID
                        return RedirectToAction("Index", "Home", new { area = "AirFreight", userId = user.Id, token = token });
                    }
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        // Token Here
                        return RedirectToAction("Index", "Home", new { area = "", token = token });
                    }
                    else
                    {
                        return Redirect($"{returnUrl}?token={token}");
                    }
                }

                else
                    ViewBag.ErrorLogin = false;

            }
            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Logout1()
        {
            var user = await _userManager.GetUserAsync(User);
            bool x = user.IsOnline;
            user.IsOnline = false;
            await _userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();
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

        [AllowAnonymous]
        public IActionResult RegisterCustomer(string? Id)
        {
            return View(new RegisterViewModel());
        }

        [AllowAnonymous]
        public IActionResult RegisterMerchant(string? Id)
        {
            return View(new RegisterViewModel());
        }
        [AllowAnonymous]
        public IActionResult RegisterAirFreight(string? Id)
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
                    ActiveUser = true,
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
        public async Task<IActionResult> RegistersCustomer(RegisterViewModel model)
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
                    PhoneNumber = model.NewRegister.PhoneNumber,
                    Name = model.NewRegister.Name,
                    UserName = model.NewRegister.PhoneNumber + "@" + model.NewRegister.PhoneNumber ,
                    Email = model.NewRegister.PhoneNumber + "@" + model.NewRegister.PhoneNumber ,
                    ActiveUser = true,
                    ImageUser = model.NewRegister.ImageUser

                };
                if (user.Id == null)
                {
                    var password = model.NewRegister.Password = model.NewRegister.PhoneNumber.Length >= 5
                        ? model.NewRegister.PhoneNumber.Substring(model.NewRegister.PhoneNumber.Length - 5)
                          : model.NewRegister.PhoneNumber;
                    //Craete
                    user.Id = Guid.NewGuid().ToString();
                    var result = await _userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        //Succsseded				
                        //var myuser = await _userManager.FindByEmailAsync(user.Email);
                        var myuser = await _userManager.FindByIdAsync(user.Id);
                        var toaw = await _userManager.AddToRoleAsync(myuser, "Customer");
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
        public async Task<IActionResult> RegistersMerchant(RegisterViewModel model)
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
                    ActiveUser = true,
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
                        var toaw = await _userManager.AddToRoleAsync(myuser, "Merchant");
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
        public async Task<IActionResult> RegistersAirFreight(RegisterViewModel model)
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
                    ActiveUser = true,
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
                        var toaw = await _userManager.AddToRoleAsync(myuser, "AirFreight");
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
        public async Task<IActionResult> RegistersEdite(ViewmMODeElMASTER model, List<IFormFile> Files, string returnUrl, string? Id)
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

                var roles = await _userManager.GetRolesAsync(userUpdate);
                if (result.Succeeded)

                {
                    if (roles.Contains("Customer"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "ClintAccount", userId = user.Id });
                    }
                    if (roles.Contains("Merchant"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "merchantAccount", userId = user.Id });
                    }
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


        [AllowAnonymous]
        public async Task<IActionResult> RegistersUserTable(RegisterViewModel model)
        {
            // إذا كان النموذج غير صالح، نعرض رسالة خطأ ونعيد التوجيه إلى صفحة التسجيل.
            // إذا أردت التحقق من صحة النموذج، قم بإلغاء التعليق على الأسطر التالية:
            // if (!ModelState.IsValid)
            // {
            //     TempData["Message"] = ResourceWeb.VLimageuplode;
            //     return RedirectToAction("Register", model);
            // }

            // استرجاع جميع المستخدمين من جدول TBViewUsers.
            var usersafe = iUser.GetAll();

            foreach (var usersife in usersafe)
            {
                try
                {
                    // التحقق مما إذا كان اسم المستخدم موجودًا بالفعل في AspNetUsers.
                    var existingUser = await _userManager.FindByNameAsync(usersife.username);
                    if (existingUser != null)
                    {
                        // إذا كان اسم المستخدم موجودًا، نتجاوز هذا المستخدم وننتقل إلى التالي.
                        TempData["Message"] = $"Username {usersife.username} already exists. Skipping.";
                        continue;
                    }

                    var user = new ApplicationUser
                    {
                        Id = usersife.id.ToString(),
                        Name = usersife.cust_name,
                        UserName = usersife.username + "@cu.com",
                        Email = usersife.username + "@cu.com",
                        ActiveUser = true,
                        ImageUser = usersife.PhotoUser,
                        PhoneNumber = usersife.cust_mob
                    };

                    // إذا لم يكن لدى المستخدم معرف، نقوم بإنشاء معرف جديد.

                    user.Id = Guid.NewGuid().ToString();


                    // إنشاء المستخدم في جدول AspNetUsers.
                    var result = await _userManager.CreateAsync(user, usersife.userpwd);
                    if (result.Succeeded)
                    {
                        // إذا تم إنشاء المستخدم بنجاح، نقوم بإضافة دوره وتسجيل دخوله.
                        var myuser = await _userManager.FindByIdAsync(user.Id);
                        var toaw = await _userManager.AddToRoleAsync(myuser, "Customer");
                        var loginResult = await _signInManager.PasswordSignInAsync(user.UserName, usersife.userpwd, true, true);

                        if (toaw.Succeeded)
                        {
                            // حذف المستخدم من جدول User بعد إضافته إلى AspNetUsers.
                            var userToDelete = _context.Users.SingleOrDefault(u => u.Id == usersife.id.ToString());
                            if (userToDelete != null)
                            {
                                _context.Users.Remove(userToDelete);
                                await _context.SaveChangesAsync();
                            }
                        }
                        else
                        {
                            TempData["Message"] = "Failed to add role for user " + usersife.username;
                            continue; // تجاوز المستخدم التالي إذا فشل إضافة الدور.
                        }
                    }
                    else
                    {
                        // إذا فشل إنشاء المستخدم، نتخطى هذا المستخدم وننتقل إلى التالي.
                        TempData["Message2"] = "Failed to create user " + usersife.username + ": " + ResourceWeb.VLEmailOreUserOrPaswo;
                        continue; // تجاوز المستخدم التالي إذا فشل إنشاء المستخدم.
                    }
                }
                catch (Exception ex)
                {
                    // معالجة الأخطاء وعرض رسالة مفيدة.
                    TempData["Message2"] = $"An error occurred while processing user {usersife.username}: {ex.Message}";
                    continue; // تجاوز المستخدم التالي في حالة حدوث خطأ.
                }
            }

            // إعادة التوجيه إلى الصفحة بعد الانتهاء من معالجة جميع المستخدمين.
            return RedirectToAction("RegistersUserTable");
        }




        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserByPhoneNumber(string phoneNumber)




        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return BadRequest("Phone number is required.");
            }

            //var user = await _userManager.Users
            //							 .Where(u => u.PhoneNumber == phoneNumber)
            //							 .FirstOrDefaultAsync();


            var user = await _context.customers.Where(u => u.CustMob == phoneNumber).FirstOrDefaultAsync();



            if (user == null)
            {
                return NotFound();
            }

            var userData = new
            {
                //Email = user.Email,
                //UserName = user.UserName,
                Name = user.CustName,
                //Password = user.PasswordHash,
            };

            return Json(userData);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserByPhoneNumberMer(string phoneNumber)




        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return BadRequest("Phone number is required.");
            }

            //var user = await _userManager.Users
            //							 .Where(u => u.PhoneNumber == phoneNumber)
            //							 .FirstOrDefaultAsync();


            var user = await _context.Merchants
                                         .Where(u => u.MerchantMob == phoneNumber)
                                         .FirstOrDefaultAsync();



            if (user == null)
            {
                return NotFound();
            }

            var userData = new
            {
                //Email = user.Email,
                //UserName = user.UserName,
                Name = user.MerchantName,
                //Password = user.PasswordHash,
            };

            return Json(userData);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> AddEditRolesUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles.ToList();

            var model = new ViewmMODeElMASTER
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles1 = roles.Select(r => new SelectListItem
                {
                    Value = r.Id,
                    Text = r.Name,
                    Selected = userRoles.Contains(r.Name)
                }).ToList()
            };

            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditRolesUser(ViewmMODeElMASTER model)
        {
            if (ModelState.IsValid)
            {
                var roles = _roleManager.Roles.ToList();
                model.Roles1 = roles.Select(r => new SelectListItem
                {
                    Value = r.Id,
                    Text = r.Name,
                    Selected = r.Id == model.SelectedRoleId
                }).ToList();
                return View("AddEditRolesUser", model);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var selectedRole = await _roleManager.FindByIdAsync(model.SelectedRoleId);

            if (selectedRole == null)
            {
                ModelState.AddModelError(string.Empty, "Role not found");
                var roles = _roleManager.Roles.ToList();
                model.Roles1 = roles.Select(r => new SelectListItem
                {
                    Value = r.Id,
                    Text = r.Name,
                    Selected = r.Id == model.SelectedRoleId
                }).ToList();
                return View("AddEditRolesUser", model);
            }

            var removeResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Failed to remove user roles");
                var roles = _roleManager.Roles.ToList();
                model.Roles1 = roles.Select(r => new SelectListItem
                {
                    Value = r.Id,
                    Text = r.Name,
                    Selected = r.Id == model.SelectedRoleId
                }).ToList();
                return View("AddEditRolesUser", model);
            }

            var addResult = await _userManager.AddToRoleAsync(user, selectedRole.Name);
            if (!addResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Failed to add user to the new role");
                var roles = _roleManager.Roles.ToList();
                model.Roles1 = roles.Select(r => new SelectListItem
                {
                    Value = r.Id,
                    Text = r.Name,
                    Selected = r.Id == model.SelectedRoleId
                }).ToList();
                return View("AddEditRolesUser", model);
            }

            return RedirectToAction("Registers"); // Assuming you have an Index action in UserController
        }

    }
}




#endregion

