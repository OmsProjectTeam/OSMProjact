using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ExchangeRateController : Controller
    {
        MasterDbcontext dbcontext;
        IICurrenciesExchangeRates iCurrenciesExchangeRates;
        IIExchangeRate iExchangeRate;


        public ExchangeRateController(MasterDbcontext dbcontext1,IICurrenciesExchangeRates iCurrenciesExchangeRates1,IIExchangeRate iExchangeRate1)
        {
            dbcontext=dbcontext1;
            iCurrenciesExchangeRates =iCurrenciesExchangeRates1;
            iExchangeRate=iExchangeRate1;
        }
        public IActionResult MyExchangeRate()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewExchangeRate = iExchangeRate.GetAll();
            return View(vmodel);
        }
        public IActionResult AddExchangeRate(int? IdExchangeRate)

        {

            ViewBag.Currenc = iCurrenciesExchangeRates.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewExchangeRate = iExchangeRate.GetAll();
            if (IdExchangeRate != null)
            {
                vmodel.ExchangeRate = iExchangeRate.GetById(Convert.ToInt32(IdExchangeRate));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBExchangeRate slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdExchangeRate = model.ExchangeRate.IdExchangeRate;
                slider.IdCurrenciesExchangeRates = model.ExchangeRate.IdCurrenciesExchangeRates;
                slider.ToIdCurrenciesExchangeRates = model.ExchangeRate.ToIdCurrenciesExchangeRates;
                slider.Rate = model.ExchangeRate.Rate;
                slider.DataEntry = model.ExchangeRate.DataEntry;
                slider.DateTimeEntry = model.ExchangeRate.DateTimeEntry;
                slider.CurrentState = model.ExchangeRate.CurrentState;
                if (slider.IdExchangeRate == 0 || slider.IdExchangeRate == null)
                {
                    if (dbcontext.TBExchangeRates.Where(a => a.IdCurrenciesExchangeRates == slider.IdCurrenciesExchangeRates).Where(a => a.ToIdCurrenciesExchangeRates == slider.ToIdCurrenciesExchangeRates).ToList().Count > 0)
                    {
                        TempData["ExchangeRate"] = ResourceWeb.VLExchangeRateDoplceted;
                        return RedirectToAction("AddExchangeRate", model);
                    }

                    var reqwest = iExchangeRate.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyExchangeRate");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iExchangeRate.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyExchangeRate");
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
        public IActionResult DeleteData(int IdExchangeRate)
        {
            var reqwistDelete = iExchangeRate.deleteData(IdExchangeRate);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyExchangeRate");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyExchangeRate");

            }
            // تمرير التاسكات  من الادارة 
            // استخدام نظام أجايا وجيرا 


        }
    }
}
