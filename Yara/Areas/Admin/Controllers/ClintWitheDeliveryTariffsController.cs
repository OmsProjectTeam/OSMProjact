
namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,ApiRoles")]
    public class ClintWitheDeliveryTariffsController : Controller
    {
        MasterDbcontext dbcontext;
        IIClintWitheDeliveryTariffs iClintWitheDeliveryTariffs;
        IICityDeliveryTariffs iCityDeliveryTariffs;
        IICustomer iCustomer;
        IIMerchant iMerchant;
        IIUserInformation iUserInformation;

        public ClintWitheDeliveryTariffsController(MasterDbcontext dbcontext1,IIClintWitheDeliveryTariffs iClintWitheDeliveryTariffs1,IICityDeliveryTariffs iCityDeliveryTariffs1,IICustomer iCustomer1,IIMerchant iMerchant1,IIUserInformation iUserInformation1)
        {
            dbcontext=  dbcontext1;
            iClintWitheDeliveryTariffs  = iClintWitheDeliveryTariffs1;
            iCityDeliveryTariffs = iCityDeliveryTariffs1;
            iCustomer = iCustomer1;
            iMerchant = iMerchant1;
            iUserInformation= iUserInformation1;
        }

        public IActionResult MyClintWitheDeliveryTariffs()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewClintWitheDeliveryTariffs = iClintWitheDeliveryTariffs.GetAll();
            return View(vmodel);
        }

        public IActionResult MyClintWitheDeliveryTariffsAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewClintWitheDeliveryTariffs = iClintWitheDeliveryTariffs.GetAll();
            return View(vmodel);
        }
        public IActionResult AddClintWitheDeliveryTariffs(int? IdClintWitheDeliveryTariffs)

        {
            ViewBag.CityDeliveryTariffs = iCityDeliveryTariffs.GetAll();
            ViewBag.user = iUserInformation.GetAllByNameall();
            
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewClintWitheDeliveryTariffs = iClintWitheDeliveryTariffs.GetAll();
            if (IdClintWitheDeliveryTariffs != null)
            {
                vmodel.ClintWitheDeliveryTariffs = iClintWitheDeliveryTariffs.GetById(Convert.ToInt32(IdClintWitheDeliveryTariffs));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        public IActionResult AddClintWitheDeliveryTariffsAr(int? IdClintWitheDeliveryTariffs)

        {
            ViewBag.CityDeliveryTariffs = iCityDeliveryTariffs.GetAll();
            ViewBag.Customer = iCustomer.GetAll();
            ViewBag.Merchant = iMerchant.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewClintWitheDeliveryTariffs = iClintWitheDeliveryTariffs.GetAll();
            if (IdClintWitheDeliveryTariffs != null)
            {
                vmodel.ClintWitheDeliveryTariffs = iClintWitheDeliveryTariffs.GetById(Convert.ToInt32(IdClintWitheDeliveryTariffs));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBClintWitheDeliveryTariffs slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdClintWitheDeliveryTariffs = model.ClintWitheDeliveryTariffs.IdClintWitheDeliveryTariffs;
                slider.IdCityDeliveryTariffs = model.ClintWitheDeliveryTariffs.IdCityDeliveryTariffs;
                slider.IdUserIntity = model.ClintWitheDeliveryTariffs.IdUserIntity;
                slider.DescriptionClint = model.ClintWitheDeliveryTariffs.DescriptionClint;
                slider.Nouts = model.ClintWitheDeliveryTariffs.Nouts;                          
                slider.DataEntry = model.ClintWitheDeliveryTariffs.DataEntry;
                slider.DateTimeEntry = model.ClintWitheDeliveryTariffs.DateTimeEntry;
                slider.CurrentState = model.ClintWitheDeliveryTariffs.CurrentState;             
                if (slider.IdClintWitheDeliveryTariffs == 0 || slider.IdClintWitheDeliveryTariffs == null)
                {
                    //if (dbcontext.TBClintWitheDeliveryTariffss.Where(a => a.IdCityDeliveryTariffs == slider.IdCityDeliveryTariffs).Where(a => a.IdCustomer == slider.IdCustomer).ToList().Count > 0)
                    //{
                    //    TempData["Customer"] = ResourceWeb.VLCustomerDoplceted;
                    //    return Redirect(returnUrl);
                    //}
                    //if (dbcontext.TBClintWitheDeliveryTariffss.Where(a => a.IdCityDeliveryTariffs == slider.IdCityDeliveryTariffs).Where(a => a.IdMerchant == slider.IdMerchant).ToList().Count > 0)

                    //{
                    //    TempData["Merchant"] = ResourceWeb.VLMerchantDoplceted;
                    //    return Redirect(returnUrl);
                    //}
                    if (dbcontext.TBClintWitheDeliveryTariffss.Where(a => a.DescriptionClint == slider.DescriptionClint).ToList().Count > 0)

                    {
                        TempData["DescriptionClint"] = ResourceWeb.VLDescriptionClintDoplceted;
                        return Redirect(returnUrl);
                    }
                    var reqwest = iClintWitheDeliveryTariffs.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyClintWitheDeliveryTariffs");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iClintWitheDeliveryTariffs.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyClintWitheDeliveryTariffs");
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
		public async Task<IActionResult> SaveAr(ViewmMODeElMASTER model, TBClintWitheDeliveryTariffs slider, List<IFormFile> Files, string returnUrl)
		{
			try
			{
				slider.IdClintWitheDeliveryTariffs = model.ClintWitheDeliveryTariffs.IdClintWitheDeliveryTariffs;
				slider.IdCityDeliveryTariffs = model.ClintWitheDeliveryTariffs.IdCityDeliveryTariffs;
				slider.IdUserIntity = model.ClintWitheDeliveryTariffs.IdUserIntity;
				slider.DescriptionClint = model.ClintWitheDeliveryTariffs.DescriptionClint;
				slider.Nouts = model.ClintWitheDeliveryTariffs.Nouts;
				slider.DataEntry = model.ClintWitheDeliveryTariffs.DataEntry;
				slider.DateTimeEntry = model.ClintWitheDeliveryTariffs.DateTimeEntry;
				slider.CurrentState = model.ClintWitheDeliveryTariffs.CurrentState;
				if (slider.IdClintWitheDeliveryTariffs == 0 || slider.IdClintWitheDeliveryTariffs == null)
				{
					//if (dbcontext.TBClintWitheDeliveryTariffss.Where(a => a.IdCityDeliveryTariffs == slider.IdCityDeliveryTariffs).Where(a => a.IdCustomer == slider.IdCustomer).ToList().Count > 0)
					//{
					//    TempData["Customer"] = ResourceWeb.VLCustomerDoplceted;
					//    return Redirect(returnUrl);
					//}
					//if (dbcontext.TBClintWitheDeliveryTariffss.Where(a => a.IdCityDeliveryTariffs == slider.IdCityDeliveryTariffs).Where(a => a.IdMerchant == slider.IdMerchant).ToList().Count > 0)

					//{
					//    TempData["Merchant"] = ResourceWeb.VLMerchantDoplceted;
					//    return Redirect(returnUrl);
					//}
					if (dbcontext.TBClintWitheDeliveryTariffss.Where(a => a.DescriptionClint == slider.DescriptionClint).ToList().Count > 0)

					{
						TempData["DescriptionClint"] = ResourceWeb.VLDescriptionClintDoplceted;
						return Redirect(returnUrl);
					}
					var reqwest = iClintWitheDeliveryTariffs.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
						return RedirectToAction("MyClintWitheDeliveryTariffsAr");
					}
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}
				else
				{
					var reqestUpdate = iClintWitheDeliveryTariffs.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyClintWitheDeliveryTariffsAr");
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
        public IActionResult DeleteData(int IdClintWitheDeliveryTariffs)
        {
            var reqwistDelete = iClintWitheDeliveryTariffs.deleteData(IdClintWitheDeliveryTariffs);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyClintWitheDeliveryTariffs");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyClintWitheDeliveryTariffs");
            }
        }

		[Authorize(Roles = "Admin")]
		public IActionResult DeleteDataAr(int IdClintWitheDeliveryTariffs)
		{
			var reqwistDelete = iClintWitheDeliveryTariffs.deleteData(IdClintWitheDeliveryTariffs);
			if (reqwistDelete == true)
			{
				TempData["Saved successfully"] = ResourceWebAr.VLdELETESuccessfully;
				return RedirectToAction("MyClintWitheDeliveryTariffsAr");
			}
			else
			{
				TempData["ErrorSave"] = ResourceWebAr.VLErrorDeleteData;
				return RedirectToAction("MyClintWitheDeliveryTariffsAr");
			}
		}
	}
}
