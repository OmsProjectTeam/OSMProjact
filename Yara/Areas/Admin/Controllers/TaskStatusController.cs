


namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TaskStatusController : Controller
    {
        MasterDbcontext dbcontext;
        IITaskStatus iTaskStatus;
        public TaskStatusController(MasterDbcontext dbcontext1,IITaskStatus iTaskStatus1)
        {
            dbcontext=dbcontext1;
            iTaskStatus =iTaskStatus1; 
        }
        public IActionResult MyTaskStatus()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaskStatus = iTaskStatus.GetAll();
            return View(vmodel);
        }

        public IActionResult MyTaskStatusAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaskStatus = iTaskStatus.GetAll();
            return View(vmodel);
        }
        public IActionResult AddTaskStatus(int? Id)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaskStatus = iTaskStatus.GetAll();
            if (Id != null)
            {
                vmodel.TaskStatus = iTaskStatus.GetById(Convert.ToInt32(Id));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        public IActionResult AddTaskStatusAr(int? Id)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTaskStatus = iTaskStatus.GetAll();
            if (Id != null)
            {
                vmodel.TaskStatus = iTaskStatus.GetById(Convert.ToInt32(Id));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TaskStatus slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.Id = model.TaskStatus.Id;
                slider.Description = model.TaskStatus.Description;           
                slider.DataEntry = model.TaskStatus.DataEntry;
                slider.DateTimeEntry = model.TaskStatus.DateTimeEntry;
                slider.CurrentState = model.TaskStatus.CurrentState;
                if (slider.Id == 0 || slider.Id == null)
                {
                    if (dbcontext.task_status.Where(a => a.Description == slider.Description).ToList().Count > 0)
                    {
                        TempData["Description"] = ResourceWeb.VLDescriptionDoplceted;
                        return RedirectToAction("AddTaskStatus", model);
                    }
                    var reqwest = iTaskStatus.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyTaskStatus");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iTaskStatus.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyTaskStatus");
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
		public async Task<IActionResult> SaveAr(ViewmMODeElMASTER model, TaskStatus slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.Id = model.TaskStatus.Id;
				slider.Description = model.TaskStatus.Description;
				slider.DataEntry = model.TaskStatus.DataEntry;
				slider.DateTimeEntry = model.TaskStatus.DateTimeEntry;
				slider.CurrentState = model.TaskStatus.CurrentState;
				if (slider.Id == 0 || slider.Id == null)
				{
					if (dbcontext.task_status.Where(a => a.Description == slider.Description).ToList().Count > 0)
					{
						TempData["Description"] = ResourceWeb.VLDescriptionDoplceted;
						return RedirectToAction("AddTaskStatusAr", model);
					}
					var reqwest = iTaskStatus.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyTaskStatusAr");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}
				else
				{
					var reqestUpdate = iTaskStatus.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyTaskStatusAr");
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
            var reqwistDelete = iTaskStatus.deleteData(Id);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyTaskStatus");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyTaskStatus");

            }
            // تمرير التاسكات  من الادارة 
            // استخدام نظام أجايا وجيرا 
        }

		[Authorize(Roles = "Admin")]
		public IActionResult DeleteDataAr(int Id)
		{
			var reqwistDelete = iTaskStatus.deleteData(Id);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWebAr.VLdELETESuccessfully;
				return RedirectToAction("MyTaskStatusAr");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWebAr.VLErrorDeleteData;
				return RedirectToAction("MyTaskStatusAr");

			}
			// تمرير التاسكات  من الادارة 
			// استخدام نظام أجايا وجيرا 
		}
	}
}
