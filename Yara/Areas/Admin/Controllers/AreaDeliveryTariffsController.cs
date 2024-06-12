using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AreaDeliveryTariffsController : Controller
    {
        MasterDbcontext dbcontext;
        IIArea iArea;
        IIAreaDeliveryTariffs iAreaDeliveryTariffs;
        IICurrenciesExchangeRates iCurrenciesExchangeRates;
        IIInformationCompanies iInformationCompanies;

        public AreaDeliveryTariffsController(MasterDbcontext dbcontext1, IIArea iArea1,IIAreaDeliveryTariffs iAreaDeliveryTariffs1,IICurrenciesExchangeRates iCurrenciesExchangeRates1,IIInformationCompanies iInformationCompanies1)
        {
            dbcontext = dbcontext1;
            iArea= iArea1;
            iAreaDeliveryTariffs=   iAreaDeliveryTariffs1;
            iCurrenciesExchangeRates= iCurrenciesExchangeRates1;
            iInformationCompanies= iInformationCompanies1;
        }
        public IActionResult MyAreaDeliveryTariffs()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewAreaDeliveryTariffs = iAreaDeliveryTariffs.GetAll();
            return View(vmodel);
        }
        public IActionResult AddAreaDeliveryTariffs(int? IdAreaDeliveryTariffs)

        {
            ViewBag.Currenc = iCurrenciesExchangeRates.GetAll();
            ViewBag.Area = iArea.GetAll();
            ViewBag.InformationCompanies = iInformationCompanies.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewAreaDeliveryTariffs = iAreaDeliveryTariffs.GetAll();
            if (IdAreaDeliveryTariffs != null)
            {
                vmodel.AreaDeliveryTariffs = iAreaDeliveryTariffs.GetById(Convert.ToInt32(IdAreaDeliveryTariffs));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBAreaDeliveryTariffs slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdAreaDeliveryTariffs = model.AreaDeliveryTariffs.IdAreaDeliveryTariffs;
                slider.AreaId = model.AreaDeliveryTariffs.AreaId;
                slider.IdInformationCompanies = model.AreaDeliveryTariffs.IdInformationCompanies;
                slider.IdCurrenciesExchangeRates = model.AreaDeliveryTariffs.IdCurrenciesExchangeRates;
                slider.TitleShipping = model.AreaDeliveryTariffs.TitleShipping;
                slider.CompanyDelivery = model.AreaDeliveryTariffs.CompanyDelivery;
                slider.ClintDelivery = model.AreaDeliveryTariffs.ClintDelivery;
                slider.DataEntry = model.AreaDeliveryTariffs.DataEntry;
                slider.DateTimeEntry = model.AreaDeliveryTariffs.DateTimeEntry;
                slider.CurrentState = model.AreaDeliveryTariffs.CurrentState;
                if (slider.IdAreaDeliveryTariffs == 0 || slider.IdAreaDeliveryTariffs == null)
                {
                    if (dbcontext.TBAreaDeliveryTariffss.Where(a => a.TitleShipping == slider.TitleShipping).ToList().Count > 0)
                    {
                        TempData["TitleShipping"] = ResourceWeb.VLTitleShippingoplceted;
                        return RedirectToAction("AddAreaDeliveryTariffs", model);
                    }
                    if (dbcontext.TBAreaDeliveryTariffss.Where(a => a.AreaId == slider.AreaId).ToList().Count > 0)
                    {
                        TempData["City"] = ResourceWeb.VLCitydoplceted;
                        return RedirectToAction("AddAreaDeliveryTariffs", model);
                    }
                    var reqwest = iAreaDeliveryTariffs.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyAreaDeliveryTariffs");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iAreaDeliveryTariffs.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyAreaDeliveryTariffs");
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
        public IActionResult DeleteData(int IdAreaDeliveryTariffs)
        {
            var reqwistDelete = iAreaDeliveryTariffs.deleteData(IdAreaDeliveryTariffs);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyAreaDeliveryTariffs");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyAreaDeliveryTariffs");
            }
        }
    }
}
