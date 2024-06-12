
namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CityDeliveryTariffsController : Controller
    {
        MasterDbcontext dbcontext;
        IICity iCity;
        IIInformationCompanies iInformationCompanies;
        IICurrenciesExchangeRates iCurrenciesExchangeRates;
        IICityDeliveryTariffs iCityDeliveryTariffs;
        public CityDeliveryTariffsController(MasterDbcontext dbcontext1,IICity iCity1,IIInformationCompanies iInformationCompanies1,IICurrenciesExchangeRates iCurrenciesExchangeRates1,IICityDeliveryTariffs iCityDeliveryTariffs1)
        {
            dbcontext = dbcontext1;
            iCity = iCity1;
            iInformationCompanies= iInformationCompanies1;
            iCurrenciesExchangeRates= iCurrenciesExchangeRates1;
            iCityDeliveryTariffs= iCityDeliveryTariffs1;

        }
        public IActionResult MyCityDeliveryTariffs()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewCityDeliveryTariffs = iCityDeliveryTariffs.GetAll();
            return View(vmodel);
        }
        public IActionResult AddCityDeliveryTariffs(int? IdCityDeliveryTariffs)

        {
            ViewBag.Currenc = iCurrenciesExchangeRates.GetAll();
            ViewBag.City = iCity.GetAll();
            ViewBag.InformationCompanies = iInformationCompanies.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewCityDeliveryTariffs = iCityDeliveryTariffs.GetAll();
            if (IdCityDeliveryTariffs != null)
            {
                vmodel.CityDeliveryTariffs = iCityDeliveryTariffs.GetById(Convert.ToInt32(IdCityDeliveryTariffs));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBCityDeliveryTariffs slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdCityDeliveryTariffs = model.CityDeliveryTariffs.IdCityDeliveryTariffs;
                slider.CityId = model.CityDeliveryTariffs.CityId;
                slider.IdInformationCompanies = model.CityDeliveryTariffs.IdInformationCompanies;
                slider.IdCurrenciesExchangeRates = model.CityDeliveryTariffs.IdCurrenciesExchangeRates;
                slider.TitleShipping = model.CityDeliveryTariffs.TitleShipping;
                slider.CompanyDelivery = model.CityDeliveryTariffs.CompanyDelivery;
                slider.ClintDelivery = model.CityDeliveryTariffs.ClintDelivery;           
                slider.DataEntry = model.CityDeliveryTariffs.DataEntry;
                slider.DateTimeEntry = model.CityDeliveryTariffs.DateTimeEntry;
                slider.CurrentState = model.CityDeliveryTariffs.CurrentState;
                if (slider.IdCityDeliveryTariffs == 0 || slider.IdCityDeliveryTariffs == null)
                {
                    if (dbcontext.TBCityDeliveryTariffss.Where(a => a.TitleShipping == slider.TitleShipping).ToList().Count > 0)
                    {
                        TempData["TitleShipping"] = ResourceWeb.VLTitleShippingoplceted;
                        return RedirectToAction("AddCityDeliveryTariffs", model);
                    }
                    if (dbcontext.TBCityDeliveryTariffss.Where(a => a.CityId == slider.CityId).ToList().Count > 0)
                    {
                        TempData["City"] = ResourceWeb.VLCitydoplceted;
                        return RedirectToAction("AddCityDeliveryTariffs", model);
                    }
                    var reqwest = iCityDeliveryTariffs.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyCityDeliveryTariffs");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iCityDeliveryTariffs.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyCityDeliveryTariffs");
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
        public IActionResult DeleteData(int IdCityDeliveryTariffs)
        {
            var reqwistDelete = iCityDeliveryTariffs.deleteData(IdCityDeliveryTariffs);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyCityDeliveryTariffs");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyCityDeliveryTariffs");
            }
        }
    }
}
