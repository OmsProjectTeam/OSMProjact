using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderStatusController : Controller
    {
        MasterDbcontext dbcontext;
        IIOrderStatus iOrderStatus;
        IIRolesName iRolesName;
        public OrderStatusController(MasterDbcontext dbcontext1,IIOrderStatus iOrderStatus1,IIRolesName iRolesName1)
        {
            dbcontext=dbcontext1;
            iOrderStatus=iOrderStatus1;
            iRolesName=iRolesName1;
        }
        public IActionResult MyOrderStatus()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrderStatus = iOrderStatus.GetAll();
            return View(vmodel);
        }

        public IActionResult MyOrderStatusAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrderStatus = iOrderStatus.GetAll();
            return View(vmodel);
        }
        public IActionResult AddOrderStatus(int? Id)

        {
            ViewBag.RolesName = iRolesName.GetAll();
      
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrderStatus = iOrderStatus.GetAll();
            if (Id != null)
            {
                vmodel.OrderStatus = iOrderStatus.GetById(Convert.ToInt32(Id));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        public IActionResult AddOrderStatusAr(int? Id)

        {
            ViewBag.RolesName = iRolesName.GetAll();

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrderStatus = iOrderStatus.GetAll();
            if (Id != null)
            {
                vmodel.OrderStatus = iOrderStatus.GetById(Convert.ToInt32(Id));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, OrderStatus slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.Id = model.OrderStatus.Id;
                slider.Description = model.OrderStatus.Description;
                slider.Role = model.OrderStatus.Role;
                slider.DataEntry = model.OrderStatus.DataEntry;
                slider.DateTimeEntry = model.OrderStatus.DateTimeEntry;
                slider.CurrentState = model.OrderStatus.CurrentState;
                if (slider.Id == 0 || slider.Id == null)
                {
                    if (dbcontext.order_status.Where(a => a.Description == slider.Description).ToList().Count > 0)
                    {
                        TempData["Description"] = ResourceWeb.VLDescriptiondplceted;
                        return RedirectToAction("AddOrderStatus", model);
                    }
                 
                    var reqwest = iOrderStatus.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyOrderStatus");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iOrderStatus.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyOrderStatus");
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
		public async Task<IActionResult> SaveAr(ViewmMODeElMASTER model, OrderStatus slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.Id = model.OrderStatus.Id;
				slider.Description = model.OrderStatus.Description;
				slider.Role = model.OrderStatus.Role;
				slider.DataEntry = model.OrderStatus.DataEntry;
				slider.DateTimeEntry = model.OrderStatus.DateTimeEntry;
				slider.CurrentState = model.OrderStatus.CurrentState;
				if (slider.Id == 0 || slider.Id == null)
				{
					if (dbcontext.order_status.Where(a => a.Description == slider.Description).ToList().Count > 0)
					{
						TempData["Description"] = ResourceWeb.VLDescriptiondplceted;
						return RedirectToAction("AddOrderStatusAr", model);
					}

					var reqwest = iOrderStatus.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyOrderStatusAr");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}
				else
				{
					var reqestUpdate = iOrderStatus.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyOrderStatusAr");
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
            var reqwistDelete = iOrderStatus.deleteData(Id);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyOrderStatus");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyOrderStatus");
            }
        }

		[Authorize(Roles = "Admin")]
		public IActionResult DeleteDataAr(int Id)
		{
			var reqwistDelete = iOrderStatus.deleteData(Id);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
				return RedirectToAction("MyOrderStatusAr");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
				return RedirectToAction("MyOrderStatusAr");
			}
		}

	}
}
