

using Microsoft.EntityFrameworkCore;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TransactionController : Controller
    {
        IICurrenciesExchangeRates iCurrenciesTransactions;
        IITransaction iTransaction;
        IIExchangeRate iExchangeRate;
        IIUser iUser;
        public TransactionController(IICurrenciesExchangeRates iCurrenciesTransactions1,IITransaction iTransaction1, IIExchangeRate iExchangeRate1,IIUser iUser1)
        {
            iCurrenciesTransactions = iCurrenciesTransactions1;
            iTransaction=iTransaction1;
            iExchangeRate = iExchangeRate1;
            iUser = iUser1;
        }
        public IActionResult MyTransaction()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewTransaction = iTransaction.GetAll();
            return View(vmodel);
        }
        public IActionResult AddTransaction(int? IdTransaction)

        {

            ViewBag.Currenc = iCurrenciesTransactions.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewTransaction = iTransaction.GetAll();
            if (IdTransaction != null)
            {
                vmodel.Transaction = iTransaction.GetById(Convert.ToInt32(IdTransaction));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBTransaction slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdTransaction = model.Transaction.IdTransaction;

                slider.FromCurrencyID = model.Transaction.FromCurrencyID;
                slider.ToCurrencyID = model.Transaction.ToCurrencyID;
                slider.Amount = model.Transaction.Amount;
                slider.ConvertedAmount = model.Transaction.ConvertedAmount;
                slider.ExchangeRate = model.Transaction.ExchangeRate;
                slider.DataEntry = model.Transaction.DataEntry;
                slider.DateTimeEntry = model.Transaction.DateTimeEntry;
                slider.CurrentState = model.Transaction.CurrentState;
                if (slider.IdTransaction == 0 || slider.IdTransaction == null)
                {                  
                    var reqwest = iTransaction.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyTransaction");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iTransaction.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyTransaction");
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
        public IActionResult DeleteData(int IdTransaction)
        {
            var reqwistDelete = iTransaction.deleteData(IdTransaction);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyTransaction");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyTransaction");

            }
      


        }

        [HttpGet]
        public IActionResult GetExchangeRate(int fromCurrencyId, int toCurrencyId)
        {
            // Fetch the exchange rate from the database
            var exchangeRate = iExchangeRate.GetAll()
                              .FirstOrDefault(e => e.IdCurrenciesExchangeRates == fromCurrencyId && e.ToIdCurrenciesExchangeRates == toCurrencyId)?
                              .Rate;

            if (exchangeRate != null)
            {
                return Json(exchangeRate);
            }
            return Json("N/A");
        }
    }
}
