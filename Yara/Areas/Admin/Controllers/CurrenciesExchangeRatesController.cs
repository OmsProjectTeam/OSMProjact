using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CurrenciesExchangeRatesController : Controller
    {
        MasterDbcontext dbcontext;
        IICurrenciesExchangeRates iCurrenciesExchangeRates;
        public CurrenciesExchangeRatesController(MasterDbcontext dbcontext1, IICurrenciesExchangeRates iCurrenciesExchangeRates1)
        {
            dbcontext = dbcontext1;
            iCurrenciesExchangeRates = iCurrenciesExchangeRates1;
        }
        public IActionResult MyCurrenciesExchangeRates()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCurrenciesExchangeRates = iCurrenciesExchangeRates.GetAll();
            return View(vmodel);
        }
        public IActionResult AddCurrenciesExchangeRates(int? IdCurrenciesExchangeRates)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCurrenciesExchangeRates = iCurrenciesExchangeRates.GetAll();
            if (IdCurrenciesExchangeRates != null)
            {
                vmodel.CurrenciesExchangeRates = iCurrenciesExchangeRates.GetById(Convert.ToInt32(IdCurrenciesExchangeRates));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBCurrenciesExchangeRates slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdCurrenciesExchangeRates = model.CurrenciesExchangeRates.IdCurrenciesExchangeRates;

                slider.Country = model.CurrenciesExchangeRates.Country;
              
                slider.code = model.CurrenciesExchangeRates.code;
           
                slider.Active = model.CurrenciesExchangeRates.Active;
                slider.DataEntry = model.CurrenciesExchangeRates.DataEntry;
                slider.DateTimeEntry = model.CurrenciesExchangeRates.DateTimeEntry;
                slider.CurrentState = model.CurrenciesExchangeRates.CurrentState;
                if (slider.IdCurrenciesExchangeRates == 0 || slider.IdCurrenciesExchangeRates == null)
                {
                    if (dbcontext.TBCurrenciesExchangeRatess.Where(a => a.Country == slider.Country).ToList().Count > 0)
                    {
                        TempData["Country"] = ResourceWeb.VLCountryDoplceted;
                        return RedirectToAction("AddCurrenciesExchangeRates", model);
                    }

                    var reqwest = iCurrenciesExchangeRates.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyCurrenciesExchangeRates");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iCurrenciesExchangeRates.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyCurrenciesExchangeRates");
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
        public IActionResult DeleteData(int IdCurrenciesExchangeRates)
        {
            var reqwistDelete = iCurrenciesExchangeRates.deleteData(IdCurrenciesExchangeRates);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyCurrenciesExchangeRates");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyCurrenciesExchangeRates");

            }
            // تمرير التاسكات  من الادارة 
            // استخدام نظام أجايا وجيرا 


        }
    }
}
