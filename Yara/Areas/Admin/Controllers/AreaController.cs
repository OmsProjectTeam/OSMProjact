﻿
using Domin.Entity;
using Infarstuructre.BL;
using Microsoft.AspNetCore.Identity;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AreaController : Controller
    {
        MasterDbcontext dbcontext;
        IICity iCity;
        IIArea iArea;
        IIUserInformation iUserInformation;
        UserManager<ApplicationUser> _userManager;
		public AreaController(MasterDbcontext dbcontext1,IICity iCity1,IIArea iArea1, IIUserInformation iUserInformation1, UserManager<ApplicationUser> userManager)
        {
            dbcontext=dbcontext1;
            iCity=iCity1;
            iArea=iArea1;
			iUserInformation=iUserInformation1;

		}
        public async Task<IActionResult> MyArea()
        {
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
	
			vmodel.ListViewAreas = iArea.GetAll();
            return View(vmodel);
        }

        public async Task<IActionResult> MyAreaAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();

            vmodel.ListViewAreas = iArea.GetAll();
            return View(vmodel);
        }
        public IActionResult AddArea(int? Id)

        {
            ////
            ViewBag.City = iCity.GetAll();
       
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewAreas = iArea.GetAll();
            if (Id != null)
            {
                vmodel.Area = iArea.GetById(Convert.ToInt32(Id));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        public IActionResult AddAreaAr(int? Id)

        {
            ////
            ViewBag.City = iCity.GetAll();

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewAreas = iArea.GetAll();
            if (Id != null)
            {
                vmodel.Area = iArea.GetById(Convert.ToInt32(Id));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, Area slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.Id = model.Area.Id;
                slider.Description = model.Area.Description;
                slider.CityId = model.Area.CityId;
                slider.Sector = model.Area.Sector;
                slider.Zone = model.Area.Zone;
                slider.Spec = model.Area.Spec;
                slider.DataEntry = model.Area.DataEntry;
                slider.DateTimeEntry = model.Area.DateTimeEntry;
                slider.CurrentState = model.Area.CurrentState;
                if (slider.Id == 0 || slider.Id == null)
                {
                    if (dbcontext.areas.Where(a => a.Description == slider.Description).ToList().Count > 0)
                    {
                        TempData["Description"] = ResourceWeb.VLDescriptionareadoplceted;
                        return RedirectToAction("AddArea", model);
                    }
                    var reqwest = iArea.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyArea");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iArea.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyArea");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return Redirect(returnUrl);
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return Redirect(returnUrl);
            }
        }

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> SaveAr(ViewmMODeElMASTER model, Area slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.Id = model.Area.Id;
				slider.Description = model.Area.Description;
				slider.CityId = model.Area.CityId;
				slider.Sector = model.Area.Sector;
				slider.Zone = model.Area.Zone;
				slider.Spec = model.Area.Spec;
				slider.DataEntry = model.Area.DataEntry;
				slider.DateTimeEntry = model.Area.DateTimeEntry;
				slider.CurrentState = model.Area.CurrentState;
				if (slider.Id == 0 || slider.Id == null)
				{
					if (dbcontext.areas.Where(a => a.Description == slider.Description).ToList().Count > 0)
					{
						TempData["Description"] = ResourceWeb.VLDescriptionareadoplceted;
						return RedirectToAction("AddAreaAr", model);
					}
					var reqwest = iArea.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyAreaAr");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}
				else
				{
					var reqestUpdate = iArea.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyAreaAr");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
						return Redirect(returnUrl);
					}
				}
			}
			catch
			{
				TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
				return Redirect(returnUrl);
			}
		}
		[Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int Id)
        {
            var reqwistDelete = iArea.deleteData(Id);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyArea");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyArea");
            }
        }

		[Authorize(Roles = "Admin")]
		public IActionResult DeleteDataAr(int Id)
		{
			var reqwistDelete = iArea.deleteData(Id);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWebAr.VLdELETESuccessfully;
				return RedirectToAction("MyAreaAr");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWebAr.VLErrorDeleteData;
				return RedirectToAction("MyAreaAr");
			}
		}
	}
}
