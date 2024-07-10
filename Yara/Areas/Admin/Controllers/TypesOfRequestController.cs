

namespace Yara.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class TypesOfRequestController : Controller
	{
		MasterDbcontext dbcontext;
		IITypesOfRequest iTypesOfRequest;

		public TypesOfRequestController(MasterDbcontext dbcontext1,IITypesOfRequest iTypesOfRequest1)
        {
            dbcontext= dbcontext1;
			iTypesOfRequest= iTypesOfRequest1;

		}
		public IActionResult MyTypesOfRequest()
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListTypesOfRequest = iTypesOfRequest.GetAll();
			return View(vmodel);
		}

		public IActionResult MyTypesOfRequestAr()
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListTypesOfRequest = iTypesOfRequest.GetAll();
			return View(vmodel);
		}
		public IActionResult AddTypesOfRequest(int? IdTypesOfRequest)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListTypesOfRequest = iTypesOfRequest.GetAll();
			if (IdTypesOfRequest != null)
			{
				vmodel.TypesOfRequest = iTypesOfRequest.GetById(Convert.ToInt32(IdTypesOfRequest));
				return View(vmodel);
			}
			else
			{
				return View(vmodel);
			}
		}

		public IActionResult AddTypesOfRequestAr(int? IdTypesOfRequest)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListTypesOfRequest = iTypesOfRequest.GetAll();
			if (IdTypesOfRequest != null)
			{
				vmodel.TypesOfRequest = iTypesOfRequest.GetById(Convert.ToInt32(IdTypesOfRequest));
				return View(vmodel);
			}
			else
			{
				return View(vmodel);
			}
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBTypesOfRequest slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.IdTypesOfRequest = model.TypesOfRequest.IdTypesOfRequest;
				slider.TypesOfRequest = model.TypesOfRequest.TypesOfRequest;
				slider.Active = model.TypesOfRequest.Active;
				slider.DataEntry = model.TypesOfRequest.DataEntry;
				slider.DateTimeEntry = model.TypesOfRequest.DateTimeEntry;
				slider.CurrentState = model.TypesOfRequest.CurrentState;
				if (slider.IdTypesOfRequest == 0 || slider.IdTypesOfRequest == null)
				{
					if (dbcontext.TBTypesOfRequests.Where(a => a.TypesOfRequest == slider.TypesOfRequest).ToList().Count > 0)
					{
						TempData["TypesOfRequest"] = ResourceWeb.VLTypesOfRequestDoplceted;
						return RedirectToAction("AddTypesOfRequest", model);
					}

					var reqwest = iTypesOfRequest.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyTypesOfRequest");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}
				else
				{
					var reqestUpdate = iTypesOfRequest.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyTypesOfRequest");
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
		public async Task<IActionResult> SaveAr(ViewmMODeElMASTER model, TBTypesOfRequest slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.IdTypesOfRequest = model.TypesOfRequest.IdTypesOfRequest;
				slider.TypesOfRequest = model.TypesOfRequest.TypesOfRequest;
				slider.Active = model.TypesOfRequest.Active;
				slider.DataEntry = model.TypesOfRequest.DataEntry;
				slider.DateTimeEntry = model.TypesOfRequest.DateTimeEntry;
				slider.CurrentState = model.TypesOfRequest.CurrentState;
				if (slider.IdTypesOfRequest == 0 || slider.IdTypesOfRequest == null)
				{
					if (dbcontext.TBTypesOfRequests.Where(a => a.TypesOfRequest == slider.TypesOfRequest).ToList().Count > 0)
					{
						TempData["TypesOfRequest"] = ResourceWebAr.VLTypesOfRequestDoplceted;
						return RedirectToAction("AddTypesOfRequestAr", model);
					}

					var reqwest = iTypesOfRequest.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyTypesOfRequestAr");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}
				else
				{
					var reqestUpdate = iTypesOfRequest.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyTypesOfRequestAr");
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
		public IActionResult DeleteData(int IdTypesOfRequest)
		{
			var reqwistDelete = iTypesOfRequest.deleteData(IdTypesOfRequest);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
				return RedirectToAction("MyTypesOfRequest");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
				return RedirectToAction("MyTypesOfRequest");

			}
			// تمرير التاسكات  من الادارة 
			// استخدام نظام أجايا وجيرا 


		}

		[Authorize(Roles = "Admin")]
		public IActionResult DeleteDataAr(int IdTypesOfRequest)
		{
			var reqwistDelete = iTypesOfRequest.deleteData(IdTypesOfRequest);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
				return RedirectToAction("MyTypesOfRequestAr");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
				return RedirectToAction("MyTypesOfRequestAr");

			}
			// تمرير التاسكات  من الادارة 
			// استخدام نظام أجايا وجيرا 


		}
	}
}
