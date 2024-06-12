
namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ShippingPriceController : Controller
    {
        MasterDbcontext dbcontext;
        IITypeSystem iTypeSystem;
        IICurrenciesExchangeRates iCurrenciesExchangeRates;
        IIInformationCompanies iInformationCompanies;
        IIShippingPrice iShippingPrice;
        public ShippingPriceController(MasterDbcontext dbcontext1, IITypeSystem iTypeSystem1,IICurrenciesExchangeRates iCurrenciesExchangeRates1,IIInformationCompanies iInformationCompanies1,IIShippingPrice iShippingPrice1)
        {
            dbcontext=dbcontext1;
            iTypeSystem=iTypeSystem1;
            iCurrenciesExchangeRates =iCurrenciesExchangeRates1;
            iInformationCompanies =iInformationCompanies1;
            iShippingPrice=iShippingPrice1;
        }
        public IActionResult MyShippingPrice()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewShippingPrices = iShippingPrice.GetAll();
            return View(vmodel);
        }
        public IActionResult AddShippingPrice(int? IdShipping)

        {
            ViewBag.Currenc = iCurrenciesExchangeRates.GetAll();
            ViewBag.TypeSystem = iTypeSystem.GetAll();
            ViewBag.InformationCompanies = iInformationCompanies.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewShippingPrices = iShippingPrice.GetAll();
            if (IdShipping != null)
            {
                vmodel.ShippingPrice = iShippingPrice.GetById(Convert.ToInt32(IdShipping));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBShippingPrice slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdShipping = model.ShippingPrice.IdShipping;
                slider.IdTypeSystem = model.ShippingPrice.IdTypeSystem;
                slider.IdInformationCompanies = model.ShippingPrice.IdInformationCompanies;
                slider.IdCurrenciesExchangeRates = model.ShippingPrice.IdCurrenciesExchangeRates;
                slider.TitleShipping = model.ShippingPrice.TitleShipping;
                slider.CoPricePerkgUnder10 = model.ShippingPrice.CoPricePerkgUnder10;
                slider.CoPricePerkgAbove10 = model.ShippingPrice.CoPricePerkgAbove10;
                slider.ClintPricePerkgUnder10 = model.ShippingPrice.ClintPricePerkgUnder10;
                slider.ClintPricePerkgAbove10 = model.ShippingPrice.ClintPricePerkgAbove10;
                slider.Active = model.ShippingPrice.Active;
                slider.DataEntry = model.ShippingPrice.DataEntry;
                slider.DateTimeEntry = model.ShippingPrice.DateTimeEntry;
                slider.CurrentState = model.ShippingPrice.CurrentState;
                if (slider.IdShipping == 0 || slider.IdShipping == null)
                {
                    if (dbcontext.TBShippingPrices.Where(a => a.TitleShipping == slider.TitleShipping).ToList().Count > 0)
                    {
                        TempData["TitleShipping"] = ResourceWeb.VLTitleShippingoplceted;
                        return RedirectToAction("AddShippingPrice", model);
                    }
                    var reqwest = iShippingPrice.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyShippingPrice");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iShippingPrice.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyShippingPrice");
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
        public IActionResult DeleteData(int IdShipping)
        {
            var reqwistDelete = iShippingPrice.deleteData(IdShipping);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyShippingPrice");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyShippingPrice");
            }
        }
    }
}
