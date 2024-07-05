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

        public IActionResult AddShippingAddress(int? id)
        {
            ViewBag.Company = iInformationCompanies.GetAll();

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewShippingAddress = iShippingAddress.GetAll();
            if (id != null)
            {
                vmodel.ShippingAddress = iShippingAddress.GetById(Convert.ToInt32(id));
                return View(vmodel);
            }
            return View(vmodel);
        }

        public IActionResult AddShippingAddressAr(int? id)
        {
            ViewBag.Company = iInformationCompanies.GetAll();

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewShippingAddress = iShippingAddress.GetAll();
            if (id != null)
            {
                vmodel.ShippingAddress = iShippingAddress.GetById(Convert.ToInt32(id));
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
                slider.Email = model.ShippingAddress.Email;
                slider.Street = model.ShippingAddress.Street;
                slider.Floor = model.ShippingAddress.Floor;
                slider.CurrentState = model.ShippingAddress.CurrentState;
                slider.DateTimeEntry = model.ShippingAddress.DateTimeEntry;
                slider.IdInformationCompany = model.ShippingAddress.IdInformationCompany;
                slider.DateEntry = model.ShippingAddress.DateEntry;
                slider.Building = model.ShippingAddress.Building;
                slider.Active = model.ShippingAddress.Active;
                slider.Description = model.ShippingAddress.Description;
                slider.ShippingAddress = model.ShippingAddress.ShippingAddress;
                slider.Office = model.ShippingAddress.Office;
                slider.Title = model.ShippingAddress.ShippingAddress + " " + model.ShippingAddress.Street + " " + model.ShippingAddress.Building
                                + " " + model.ShippingAddress.Floor + " " + model.ShippingAddress.Office ;
                slider.Moblie = model.ShippingAddress.Moblie;

                if (slider.IdShippingAddress == 0 || slider.IdShippingAddress == null)
                {
                    if (dbcontext.TBTransfers.Where(a => a.ReceiptNo == slider.ShippingAddress).ToList().Count > 0)
                    {
                        TempData["DescriptionClint"] = ResourceWeb.VLDescriptionClintDoplceted;
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
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int id)
        {
            var reqwistDelete = iShippingAddress.deleteData(id);
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
    }
}
