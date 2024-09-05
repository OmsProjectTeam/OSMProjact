namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ShippingAddresseClintController : Controller
    {
        IIUserInformation iUserInformation;
        IICity iCity;
        IIArea iArea;
        IIShippingPrice iShippingPrice;
        IICurrenciesExchangeRates iCurrenciesExchangeRates;
        IITypeSystemDelivery iTypeSystemDelivery;
        IICityDeliveryTariffs iCityDeliveryTariffs;
        IIShippingAddresseClint iShippingAddresseClint;
        public ShippingAddresseClintController(IIUserInformation iUserInformation1, IICity iCity1, IIArea iArea1, IIShippingPrice iShippingPrice1, IICurrenciesExchangeRates iCurrenciesExchangeRates1, IITypeSystemDelivery iTypeSystemDelivery1,IICityDeliveryTariffs iCityDeliveryTariffs1,IIShippingAddresseClint iShippingAddresseClint1)
        {
            iUserInformation= iUserInformation1;
            iCity= iCity1;
            iArea = iArea1;
            iShippingPrice = iShippingPrice1;
            iCurrenciesExchangeRates = iCurrenciesExchangeRates1;
            iTypeSystemDelivery = iTypeSystemDelivery1;
            iCityDeliveryTariffs = iCityDeliveryTariffs1;
            iShippingAddresseClint = iShippingAddresseClint1;
        }
        public IActionResult MyShippingAddresseClint()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewShippingAddresseClint = iShippingAddresseClint.GetAll();
            return View(vmodel);
        }
        public IActionResult MyShippingAddresseClintAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewShippingAddresseClint = iShippingAddresseClint.GetAll();
            return View(vmodel);
        }
        public IActionResult AddShippingAddresseClint(int? IdShippingAddresseClint)
        {
            ViewBag.City = iCity.GetAll();
            ViewBag.Area = iArea.GetAll();
            ViewBag.ShippingPrice = iShippingPrice.GetAll();
            ViewBag.Currenc= iCurrenciesExchangeRates.GetAll();
            ViewBag.TypeSystemDelivery = iTypeSystemDelivery.GetAll();
            ViewBag.CityDeliveryTariffs = iCityDeliveryTariffs.GetAll();
            ViewBag.user = iUserInformation.GetAllByNameall();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewShippingAddresseClint = iShippingAddresseClint.GetAll();
            if (IdShippingAddresseClint != null)
            {
                vmodel.ShippingAddresseClint = iShippingAddresseClint.GetById(Convert.ToInt32(IdShippingAddresseClint));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddShippingAddresseClintAr(int? IdShippingAddresseClint)

        {
            ViewBag.City = iCity.GetAll();
            ViewBag.Area = iArea.GetAll();
            ViewBag.ShippingPrice = iShippingPrice.GetAll();
            ViewBag.Currenc = iCurrenciesExchangeRates.GetAll();
            ViewBag.TypeSystemDelivery = iTypeSystemDelivery.GetAll();
            ViewBag.CityDeliveryTariffs = iCityDeliveryTariffs.GetAll();
            ViewBag.user = iUserInformation.GetAllByNameall();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewShippingAddresseClint = iShippingAddresseClint.GetAll();


            if (IdShippingAddresseClint != null)
            {
                vmodel.ShippingAddresseClint = iShippingAddresseClint.GetById(Convert.ToInt32(IdShippingAddresseClint));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBShippingAddresseClint slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdShippingAddresseClint = model.ShippingAddresseClint.IdShippingAddresseClint;
                slider.IdUser = model.ShippingAddresseClint.IdUser;
                slider.IdCity = model.ShippingAddresseClint.IdCity;
                slider.IdArea = model.ShippingAddresseClint.IdArea;
                slider.IdShippingPrices = model.ShippingAddresseClint.IdShippingPrices;
                slider.IdCurrenciesExchangeRates = model.ShippingAddresseClint.IdCurrenciesExchangeRates;
                slider.NearestLandmark = model.ShippingAddresseClint.NearestLandmark;
                slider.ClintPricePerkgUnder10 = model.ShippingAddresseClint.ClintPricePerkgUnder10;
                slider.ClintPricePerkgAbove10 = model.ShippingAddresseClint.ClintPricePerkgAbove10;
                slider.IdTypeSystemDelivery = model.ShippingAddresseClint.IdTypeSystemDelivery;
                slider.IdCityDeliveryTariffs = model.ShippingAddresseClint.IdCityDeliveryTariffs;
              
                slider.DeliveryPriceClint = model.ShippingAddresseClint.DeliveryPriceClint;
                slider.Description = model.ShippingAddresseClint.Description;
                slider.Active = model.ShippingAddresseClint.Active;                  
                slider.DataEntry = model.ShippingAddresseClint.DataEntry;
                slider.DateTimeEntry = model.ShippingAddresseClint.DateTimeEntry;
                slider.CurrentState = model.ShippingAddresseClint.CurrentState;
                if (slider.IdShippingAddresseClint == 0 || slider.IdShippingAddresseClint == null)
                {                                 
                    var reqwest = iShippingAddresseClint.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyShippingAddresseClint");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddShippingAddresseClint");
                    }
                }
                else
                {
                    var reqestUpdate = iShippingAddresseClint.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyShippingAddresseClint");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("AddShippingAddresseClint");
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return RedirectToAction("AddShippingAddresseClint");
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> SaveAr(ViewmMODeElMASTER model, TBShippingAddresseClint slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdShippingAddresseClint = model.ShippingAddresseClint.IdShippingAddresseClint;
                slider.IdUser = model.ShippingAddresseClint.IdUser;
                slider.IdCity = model.ShippingAddresseClint.IdCity;
                slider.IdArea = model.ShippingAddresseClint.IdArea;
                slider.IdShippingPrices = model.ShippingAddresseClint.IdShippingPrices;
                slider.IdCurrenciesExchangeRates = model.ShippingAddresseClint.IdCurrenciesExchangeRates;
                slider.NearestLandmark = model.ShippingAddresseClint.NearestLandmark;
                slider.ClintPricePerkgUnder10 = model.ShippingAddresseClint.ClintPricePerkgUnder10;
                slider.ClintPricePerkgAbove10 = model.ShippingAddresseClint.ClintPricePerkgAbove10;
                slider.IdTypeSystemDelivery = model.ShippingAddresseClint.IdTypeSystemDelivery;
                slider.IdCityDeliveryTariffs = model.ShippingAddresseClint.IdCityDeliveryTariffs;
             
                slider.DeliveryPriceClint = model.ShippingAddresseClint.DeliveryPriceClint;
                slider.Description = model.ShippingAddresseClint.Description;
                slider.Active = model.ShippingAddresseClint.Active;
                slider.DataEntry = model.ShippingAddresseClint.DataEntry;
                slider.DateTimeEntry = model.ShippingAddresseClint.DateTimeEntry;
                slider.CurrentState = model.ShippingAddresseClint.CurrentState;
                if (slider.IdShippingAddresseClint == 0 || slider.IdShippingAddresseClint == null)
                {
                    var reqwest = iShippingAddresseClint.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyShippingAddresseClintAr");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddShippingAddresseClintAr");
                    }
                }
                else
                {
                    var reqestUpdate = iShippingAddresseClint.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyShippingAddresseClintAr");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("AddShippingAddresseClintAr");
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return RedirectToAction("AddShippingAddresseClintAr");
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdShippingAddresseClint)
        {
            var reqwistDelete = iShippingAddresseClint.deleteData(IdShippingAddresseClint);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyShippingAddresseClint");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyShippingAddresseClint");
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteDataAr(int IdShippingAddresseClint)
        {
            var reqwistDelete = iShippingAddresseClint.deleteData(IdShippingAddresseClint);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWebAr.VLdELETESuccessfully;
                return RedirectToAction("MyShippingAddresseClintAr");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWebAr.VLErrorDeleteData;
                return RedirectToAction("MyShippingAddresseClintAr");
            }
        }
        public JsonResult GetAreasByCity(int cityId)
        {
            var areas = iArea.GetAllByCityId(cityId); // Fetching areas by city ID
            return Json(areas.Select(a => new { id = a.id, description = a.Description }));
        }

        [HttpGet]
        public JsonResult GetShippingPricesByNikeName(int shippingPriceId)
        {
            var shippingPrice = iShippingPrice.GetById(shippingPriceId);
            if (shippingPrice != null)
            {
                return Json(new
                {
                    CoPricePerkgUnder10 = shippingPrice.CoPricePerkgUnder10,
                    CoPricePerkgAbove10 = shippingPrice.CoPricePerkgAbove10
                });
            }
            return Json(null);
        }
        public JsonResult GetDeliveryDetailsByTypeSystem(int typeSystemId)
        {
            var deliveryTariffs = iCityDeliveryTariffs.GetById(typeSystemId);
            if (deliveryTariffs != null)
            {
                return Json(new
                {
                    DeliveryPriceClint = deliveryTariffs.ClintDelivery,
                    CompanyPricing = deliveryTariffs.CompanyDelivery // Assuming you have this field
                });
            }
            return Json(null);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> SaveModal(ViewmMODeElMASTER model, TBShippingAddresseClint slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdShippingAddresseClint = model.ShippingAddresseClint.IdShippingAddresseClint;
                slider.IdUser = model.ShippingAddresseClint.IdUser;
                slider.IdCity = model.ShippingAddresseClint.IdCity;
                slider.IdArea = model.ShippingAddresseClint.IdArea;
                slider.IdShippingPrices = model.ShippingAddresseClint.IdShippingPrices;
                slider.IdCurrenciesExchangeRates = model.ShippingAddresseClint.IdCurrenciesExchangeRates;
                slider.NearestLandmark = model.ShippingAddresseClint.NearestLandmark;
                slider.ClintPricePerkgUnder10 = model.ShippingAddresseClint.ClintPricePerkgUnder10;
                slider.ClintPricePerkgAbove10 = model.ShippingAddresseClint.ClintPricePerkgAbove10;
                slider.IdTypeSystemDelivery = model.ShippingAddresseClint.IdTypeSystemDelivery;
                slider.IdCityDeliveryTariffs = model.ShippingAddresseClint.IdCityDeliveryTariffs;

                slider.DeliveryPriceClint = model.ShippingAddresseClint.DeliveryPriceClint;
                slider.Description = model.ShippingAddresseClint.Description;
                slider.Active = model.ShippingAddresseClint.Active;
                slider.DataEntry = model.ShippingAddresseClint.DataEntry;
                slider.DateTimeEntry = model.ShippingAddresseClint.DateTimeEntry;
                slider.CurrentState = model.ShippingAddresseClint.CurrentState;
                if (slider.IdShippingAddresseClint == 0 || slider.IdShippingAddresseClint == null)
                {
                    var reqwest = iShippingAddresseClint.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyCheckCustmer");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return RedirectToAction("AddShippingAddresseClint");
                    }
                }
                else
                {
                    var reqestUpdate = iShippingAddresseClint.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyCheckCustmer");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                        return RedirectToAction("AddShippingAddresseClint");
                    }
                }
            }
            catch
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                return RedirectToAction("AddShippingAddresseClint");
            }
        }

    }
}
