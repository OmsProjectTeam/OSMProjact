﻿using Infarstuructre.BL;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Yara.Areas.ClintAccount.Controllers;

[Area("ClintAccount")]
[Authorize(Roles = "Admin,Customer")]
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

}
