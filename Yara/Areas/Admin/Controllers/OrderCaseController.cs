

namespace Yara.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class OrderCaseController : Controller
	{
		MasterDbcontext dbcontext;
		IIOrderCase iOrderCase;
		public OrderCaseController(MasterDbcontext dbcontext1,IIOrderCase iOrderCase1)
        {
			dbcontext = dbcontext1;
			iOrderCase = iOrderCase1;

		}
		public IActionResult MyOrderCase()
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListOrderCase = iOrderCase.GetAll();
			return View(vmodel);
		}
		public IActionResult AddOrderCase(int? Id)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			vmodel.ListOrderCase = iOrderCase.GetAll();
			if (Id != null)
			{
				vmodel.OrderCase = iOrderCase.GetById(Convert.ToInt32(Id));
				return View(vmodel);
			}
			else
			{
				return View(vmodel);
			}
		}
		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Save(ViewmMODeElMASTER model, OrderCase slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.Id = model.OrderCase.Id;
				slider.Description = model.OrderCase.Description;
				slider.DataEntry = model.OrderCase.DataEntry;
				slider.DateTimeEntry = model.OrderCase.DateTimeEntry;
				slider.CurrentState = model.OrderCase.CurrentState;
				if (slider.Id == 0 || slider.Id == null)
				{
					if (dbcontext.cities.Where(a => a.Description == slider.Description).ToList().Count > 0)
					{
						TempData["Description"] = ResourceWeb.VLDescriptionDoplceted;
						return RedirectToAction("AddOrderCase", model);
					}
					var reqwest = iOrderCase.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyOrderCase");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}
				else
				{
					var reqestUpdate = iOrderCase.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyOrderCase");
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
			var reqwistDelete = iOrderCase.deleteData(Id);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
				return RedirectToAction("MyOrderCase");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
				return RedirectToAction("MyOrderCase");

			}
			// تمرير التاسكات  من الادارة 
			// استخدام نظام أجايا وجيرا 


		}
	}
}
