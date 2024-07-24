
using Microsoft.EntityFrameworkCore;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,ApiRoles")]
    public class CityDeliveryTariffsController : Controller
    {
        MasterDbcontext dbcontext;
        IICity iCity;
        IIInformationCompanies iInformationCompanies;
        IICurrenciesExchangeRates iCurrenciesExchangeRates;
        IICityDeliveryTariffs iCityDeliveryTariffs;
        IIArea iArea;
        IITypeSystemDelivery iTypeSystemDelivery;
        public CityDeliveryTariffsController(MasterDbcontext dbcontext1,IICity iCity1,IIInformationCompanies iInformationCompanies1,IICurrenciesExchangeRates iCurrenciesExchangeRates1,IICityDeliveryTariffs iCityDeliveryTariffs1,IIArea iArea1,IITypeSystemDelivery iTypeSystemDelivery1)
        {
            dbcontext = dbcontext1;
            iCity = iCity1;
            iInformationCompanies= iInformationCompanies1;
            iCurrenciesExchangeRates= iCurrenciesExchangeRates1;
            iCityDeliveryTariffs= iCityDeliveryTariffs1;
            iArea = iArea1;
            iTypeSystemDelivery = iTypeSystemDelivery1;

        }
        public IActionResult MyCityDeliveryTariffs()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewCityDeliveryTariffs = iCityDeliveryTariffs.GetAll();
            return View(vmodel);
        }

        public IActionResult MyCityDeliveryTariffsAr()
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
            ViewBag.area = iArea.GetAll();
            ViewBag.TypeSystemDelivery = iTypeSystemDelivery.GetAll();
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

        public IActionResult AddCityDeliveryTariffsAr(int? IdCityDeliveryTariffs)

        {
            ViewBag.Currenc = iCurrenciesExchangeRates.GetAll();
            ViewBag.City = iCity.GetAll();
            ViewBag.InformationCompanies = iInformationCompanies.GetAll();
            ViewBag.area = iArea.GetAll();
            ViewBag.TypeSystemDelivery = iTypeSystemDelivery.GetAll();
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
                slider.AreaId = model.CityDeliveryTariffs.AreaId;
                slider.IdTypeSystemDelivery = model.CityDeliveryTariffs.IdTypeSystemDelivery;
                slider.IdInformationCompanies = model.CityDeliveryTariffs.IdInformationCompanies;
                slider.IdCurrenciesExchangeRates = model.CityDeliveryTariffs.IdCurrenciesExchangeRates;
                slider.TitleShipping = model.CityDeliveryTariffs.TitleShipping;
                slider.CompanyDelivery = model.CityDeliveryTariffs.CompanyDelivery;
                slider.ClintDelivery = model.CityDeliveryTariffs.ClintDelivery;           
                slider.DataEntry = model.CityDeliveryTariffs.DataEntry;
                slider.DateTimeEntry = model.CityDeliveryTariffs.DateTimeEntry;
                slider.CurrentState = model.CityDeliveryTariffs.CurrentState;
                slider.Active = model.CityDeliveryTariffs.Active;
                if (slider.IdCityDeliveryTariffs == 0 || slider.IdCityDeliveryTariffs == null)
                {
                    if (dbcontext.TBCityDeliveryTariffss.Where(a => a.TitleShipping == slider.TitleShipping).ToList().Count > 0)
                    {
                        TempData["TitleShipping"] = ResourceWeb.VLTitleShippingoplceted;
                        return Redirect(returnUrl);
                    }
                    if (dbcontext.TBCityDeliveryTariffss.Where(a => a.CityId == slider.CityId).Where(a => a.TitleShipping == slider.TitleShipping).ToList().Count > 0)
                    {
                        TempData["City"] = ResourceWeb.VLCitydoplceted;
                        return Redirect(returnUrl);
                    }
                    if (dbcontext.TBCityDeliveryTariffss.Where(a => a.AreaId == slider.AreaId).Where(a => a.TitleShipping == slider.TitleShipping).ToList().Count > 0)
                    {
                        TempData["Area"] = ResourceWeb.VLAreadoplceted;
                        return Redirect(returnUrl);
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

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> SaveAr(ViewmMODeElMASTER model, TBCityDeliveryTariffs slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.IdCityDeliveryTariffs = model.CityDeliveryTariffs.IdCityDeliveryTariffs;
				slider.CityId = model.CityDeliveryTariffs.CityId;
				slider.AreaId = model.CityDeliveryTariffs.AreaId;
				slider.IdTypeSystemDelivery = model.CityDeliveryTariffs.IdTypeSystemDelivery;
				slider.IdInformationCompanies = model.CityDeliveryTariffs.IdInformationCompanies;
				slider.IdCurrenciesExchangeRates = model.CityDeliveryTariffs.IdCurrenciesExchangeRates;
				slider.TitleShipping = model.CityDeliveryTariffs.TitleShipping;
				slider.CompanyDelivery = model.CityDeliveryTariffs.CompanyDelivery;
				slider.ClintDelivery = model.CityDeliveryTariffs.ClintDelivery;
				slider.DataEntry = model.CityDeliveryTariffs.DataEntry;
				slider.DateTimeEntry = model.CityDeliveryTariffs.DateTimeEntry;
				slider.CurrentState = model.CityDeliveryTariffs.CurrentState;
				slider.Active = model.CityDeliveryTariffs.Active;
				if (slider.IdCityDeliveryTariffs == 0 || slider.IdCityDeliveryTariffs == null)
				{
					if (dbcontext.TBCityDeliveryTariffss.Where(a => a.TitleShipping == slider.TitleShipping).ToList().Count > 0)
					{
						TempData["TitleShipping"] = ResourceWeb.VLTitleShippingoplceted;
						return Redirect(returnUrl);
					}
					if (dbcontext.TBCityDeliveryTariffss.Where(a => a.CityId == slider.CityId).Where(a => a.TitleShipping == slider.TitleShipping).ToList().Count > 0)
					{
						TempData["City"] = ResourceWeb.VLCitydoplceted;
						return Redirect(returnUrl);
					}
					if (dbcontext.TBCityDeliveryTariffss.Where(a => a.AreaId == slider.AreaId).Where(a => a.TitleShipping == slider.TitleShipping).ToList().Count > 0)
					{
						TempData["Area"] = ResourceWeb.VLAreadoplceted;
						return Redirect(returnUrl);
					}
					var reqwest = iCityDeliveryTariffs.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyCityDeliveryTariffsAr");
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
						return RedirectToAction("MyCityDeliveryTariffsAr");
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

		[Authorize(Roles = "Admin")]
		public IActionResult DeleteDataAr(int IdCityDeliveryTariffs)
		{
			var reqwistDelete = iCityDeliveryTariffs.deleteData(IdCityDeliveryTariffs);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWebAr.VLdELETESuccessfully;
				return RedirectToAction("MyCityDeliveryTariffsAr");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWebAr.VLErrorDeleteData;
				return RedirectToAction("MyCityDeliveryTariffsAr");
			}
		}


		public JsonResult GetAreasByCity(int cityId)
        {
            var areas = dbcontext.ViewAreas.Where(a => a.city_id == cityId).Select(a => new { a.id, a.Description }).ToList();
            return Json(areas);
        }
    }
}
