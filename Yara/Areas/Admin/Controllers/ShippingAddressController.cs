using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ShippingAddressController : Controller
    {

        IIShippingAddress iShippingAddress;
        IIInformationCompanies iInformationCompanies;
        MasterDbcontext dbcontext;
        public ShippingAddressController(IIShippingAddress iShippingAddress, IIInformationCompanies iInformationCompanies, MasterDbcontext dbcontext)
        {
            this.iShippingAddress = iShippingAddress;
            this.iInformationCompanies = iInformationCompanies;
            this.dbcontext = dbcontext;
        }

        public IActionResult MyShippingAddress()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewShippingAddress = iShippingAddress.GetAll();
            return View(vmodel);
        }

        public IActionResult MyShippingAddressAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewShippingAddress = iShippingAddress.GetAll();
            return View(vmodel);
        }

        public IActionResult AddShippingAddress(int? IdShippingAddress)
        {
            ViewBag.Company = iInformationCompanies.GetAll();

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewShippingAddress = iShippingAddress.GetAll();
            if (IdShippingAddress != null)
            {
                vmodel.ShippingAddress = iShippingAddress.GetById(Convert.ToInt32(IdShippingAddress));
                return View(vmodel);
            }
            return View(vmodel);
        }

        public IActionResult AddShippingAddressAr(int? IdShippingAddress)
        {
            ViewBag.Company = iInformationCompanies.GetAll();

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewShippingAddress = iShippingAddress.GetAll();
            if (IdShippingAddress != null)
            {
                vmodel.ShippingAddress = iShippingAddress.GetById(Convert.ToInt32(IdShippingAddress));
                return View(vmodel);
            }
            return View(vmodel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBShippingAddress slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdShippingAddress = model.ShippingAddress.IdShippingAddress;
                slider.IdInformationCompany = model.ShippingAddress.IdInformationCompany;
                slider.Email = model.ShippingAddress.Email;
                slider.ShippingAddress = model.ShippingAddress.ShippingAddress;
                slider.Floor = model.ShippingAddress.Floor;
                slider.Building = model.ShippingAddress.Building;
                slider.Street = model.ShippingAddress.Street;
                slider.Office = model.ShippingAddress.Office;
                slider.Title = model.ShippingAddress.ShippingAddress + " " + model.ShippingAddress.Street + " " + model.ShippingAddress.Building
                             + " " + model.ShippingAddress.Floor + " " + model.ShippingAddress.Office;
                slider.Description = model.ShippingAddress.Description;
                slider.Moblie = model.ShippingAddress.Moblie;
                slider.CurrentState = model.ShippingAddress.CurrentState;
                slider.DateTimeEntry = model.ShippingAddress.DateTimeEntry;
                slider.DateEntry = model.ShippingAddress.DateEntry;
                slider.Active = model.ShippingAddress.Active;            
                if (slider.IdShippingAddress == 0 || slider.IdShippingAddress == null)
                {
                    if (dbcontext.TBShippingAddresses.Where(a => a.Email == slider.Email).ToList().Count > 0)
                    {
                        TempData["Email"] = ResourceWeb.VLEmailDoplceted;
                        return Redirect(returnUrl);
                    }
                    var reqwest = iShippingAddress.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyShippingAddress");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iShippingAddress.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyShippingAddress");
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
		public async Task<IActionResult> SaveAr(ViewmMODeElMASTER model, TBShippingAddress slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.IdShippingAddress = model.ShippingAddress.IdShippingAddress;
				slider.IdInformationCompany = model.ShippingAddress.IdInformationCompany;
				slider.Email = model.ShippingAddress.Email;
				slider.ShippingAddress = model.ShippingAddress.ShippingAddress;
				slider.Floor = model.ShippingAddress.Floor;
				slider.Building = model.ShippingAddress.Building;
				slider.Street = model.ShippingAddress.Street;
				slider.Office = model.ShippingAddress.Office;
				slider.Title = model.ShippingAddress.ShippingAddress + " " + model.ShippingAddress.Street + " " + model.ShippingAddress.Building
							 + " " + model.ShippingAddress.Floor + " " + model.ShippingAddress.Office;
				slider.Description = model.ShippingAddress.Description;
				slider.Moblie = model.ShippingAddress.Moblie;
				slider.CurrentState = model.ShippingAddress.CurrentState;
				slider.DateTimeEntry = model.ShippingAddress.DateTimeEntry;
				slider.DateEntry = model.ShippingAddress.DateEntry;
				slider.Active = model.ShippingAddress.Active;
				if (slider.IdShippingAddress == 0 || slider.IdShippingAddress == null)
				{
					if (dbcontext.TBShippingAddresses.Where(a => a.Email == slider.Email).ToList().Count > 0)
					{
						TempData["Email"] = ResourceWeb.VLEmailDoplceted;
						return Redirect(returnUrl);
					}
					var reqwest = iShippingAddress.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyShippingAddressAr");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}
				else
				{
					var reqestUpdate = iShippingAddress.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyShippingAddressAr");
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
        public IActionResult DeleteData(int IdShippingAddress)
        {
            var reqwistDelete = iShippingAddress.deleteData(IdShippingAddress);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyShippingAddress");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyShippingAddress");
            }
        }

		[Authorize(Roles = "Admin")]
		public IActionResult DeleteDataAr(int IdShippingAddress)
		{
			var reqwistDelete = iShippingAddress.deleteData(IdShippingAddress);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
				return RedirectToAction("MyShippingAddressAr");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
				return RedirectToAction("MyShippingAddressAr");
			}
		}
	}
}
