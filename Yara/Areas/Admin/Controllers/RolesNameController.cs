using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RolesNameController : Controller
    {
        MasterDbcontext dbcontext;
        IIRolesName iRolesName;
        public RolesNameController(MasterDbcontext dbcontex1,IIRolesName iRolesName1)
        {
            dbcontext= dbcontex1;
            iRolesName = iRolesName1;
        }
        public IActionResult MyRolesName()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListRolesName = iRolesName.GetAll();
            return View(vmodel);
        }

        public IActionResult MyRolesNameAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListRolesName = iRolesName.GetAll();
            return View(vmodel);
        }
        public IActionResult AddRolesName(int? Id)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListRolesName = iRolesName.GetAll();
            if (Id != null)
            {
                vmodel.RolesName = iRolesName.GetById(Convert.ToInt32(Id));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        public IActionResult AddRolesNameAr(int? Id)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListRolesName = iRolesName.GetAll();
            if (Id != null)
            {
                vmodel.RolesName = iRolesName.GetById(Convert.ToInt32(Id));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, RolesName slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.Id = model.RolesName.Id;
                slider.RoleName = model.RolesName.RoleName;         
                slider.DataEntry = model.RolesName.DataEntry;
                slider.DateTimeEntry = model.RolesName.DateTimeEntry;
                slider.CurrentState = model.RolesName.CurrentState;

                if (slider.Id == 0 || slider.Id == null)
                {
                    if (dbcontext.RolesNames.Where(a => a.RoleName == slider.RoleName).ToList().Count > 0)
                    {
                        TempData["RoleName"] = ResourceWeb.VLRoleNameDoplceted;
                        return RedirectToAction("AddRolesName", model);
                    }

                    var reqwest = iRolesName.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyRolesName");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iRolesName.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyRolesName");
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
		public async Task<IActionResult> SaveAr(ViewmMODeElMASTER model, RolesName slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.Id = model.RolesName.Id;
				slider.RoleName = model.RolesName.RoleName;
				slider.DataEntry = model.RolesName.DataEntry;
				slider.DateTimeEntry = model.RolesName.DateTimeEntry;
				slider.CurrentState = model.RolesName.CurrentState;

				if (slider.Id == 0 || slider.Id == null)
				{
					if (dbcontext.RolesNames.Where(a => a.RoleName == slider.RoleName).ToList().Count > 0)
					{
						TempData["RoleName"] = ResourceWeb.VLRoleNameDoplceted;
						return RedirectToAction("AddRolesNameAr", model);
					}

					var reqwest = iRolesName.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyRolesNameAr");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}
				else
				{
					var reqestUpdate = iRolesName.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyRolesNameAr");
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
            var reqwistDelete = iRolesName.deleteData(Id);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyRolesName");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyRolesName");

            }
            // تمرير التاسكات  من الادارة 
            // استخدام نظام أجايا وجيرا 


        }

		[Authorize(Roles = "Admin")]
		public IActionResult DeleteDataAr(int Id)
		{
			var reqwistDelete = iRolesName.deleteData(Id);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWebAr.VLdELETESuccessfully;
				return RedirectToAction("MyRolesNameAr");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWebAr.VLErrorDeleteData;
				return RedirectToAction("MyRolesNameAr");

			}
			// تمرير التاسكات  من الادارة 
			// استخدام نظام أجايا وجيرا 


		}
	}
}
