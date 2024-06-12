using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]

	public class TypesCompaniesController : Controller
	{
		MasterDbcontext dbcontext;
		IITypesCompanies iTypesCompanies;
		public TypesCompaniesController(MasterDbcontext dbcontext1,IITypesCompanies iTypesCompanies1)
        {
			dbcontext=dbcontext1;
			iTypesCompanies=iTypesCompanies1;
		}
		public IActionResult MyTypesCompanies()
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListTypesCompanies = iTypesCompanies.GetAll();
			return View(vmodel);
		}
		public IActionResult AddTypesCompanies(int? IdTypesCompanies)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListTypesCompanies = iTypesCompanies.GetAll();
			if (IdTypesCompanies != null)
			{
				vmodel.TypesCompanies = iTypesCompanies.GetById(Convert.ToInt32(IdTypesCompanies));
				return View(vmodel);
			}
			else
			{
				return View(vmodel);
			}
		}
		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBTypesCompanies slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.IdTypesCompanies = model.TypesCompanies.IdTypesCompanies;
				slider.TypesCompanies = model.TypesCompanies.TypesCompanies;				
				slider.DataEntry = model.TypesCompanies.DataEntry;
				slider.DateTimeEntry = model.TypesCompanies.DateTimeEntry;
				slider.CurrentState = model.TypesCompanies.CurrentState;
				if (slider.IdTypesCompanies == 0 || slider.IdTypesCompanies == null)
				{
					if (dbcontext.TBTypesCompaniess.Where(a => a.TypesCompanies == slider.TypesCompanies).ToList().Count > 0)
					{
						TempData["TypesCompanies"] = ResourceWeb.VLTypesCompaniesDoplceted;
						return RedirectToAction("AddTypesCompanies", model);
					}
				
					var reqwest = iTypesCompanies.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyTypesCompanies");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}
				else
				{
					var reqestUpdate = iTypesCompanies.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyTypesCompanies");
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
		public IActionResult DeleteData(int IdTypesCompanies)
		{
			var reqwistDelete = iTypesCompanies.deleteData(IdTypesCompanies);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
				return RedirectToAction("MyTypesCompanies");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
				return RedirectToAction("MyTypesCompanies");

			}
			// تمرير التاسكات  من الادارة 
			// استخدام نظام أجايا وجيرا 


		}
	}
}
