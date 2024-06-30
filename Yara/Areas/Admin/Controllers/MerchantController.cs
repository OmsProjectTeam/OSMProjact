
namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MerchantController : Controller
    {
        MasterDbcontext dbcontext;
        IICustomer iCustomer;
        IIArea iArea;
        IIInformationCompanies iInformationCompanies;
        IIMerchant iMerchant;
        public MerchantController(MasterDbcontext dbcontext1, IICustomer iCustomer1,IIArea iArea1,IIInformationCompanies iInformationCompanies1,IIMerchant iMerchant1)
        {
            //////////////
            dbcontext=dbcontext1;
            iCustomer= iCustomer1;
            iArea= iArea1;
            iInformationCompanies= iInformationCompanies1;
            iMerchant = iMerchant1;
        }
        public IActionResult MyMerchant()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewMerchant = iMerchant.GetAll();
            return View(vmodel);
        }

        public IActionResult MyMerchantAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewMerchant = iMerchant.GetAll();
            return View(vmodel);
        }
        public IActionResult AddMerchant(int? IdShipping)

        {
            ///////////////
            ViewBag.Customer = iCustomer.GetAll();
            ViewBag.Area = iArea.GetAll();
            ViewBag.InformationCompanies = iInformationCompanies.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewMerchant = iMerchant.GetAll();
            if (IdShipping != null)
            {
                vmodel.Merchant = iMerchant.GetById(Convert.ToInt32(IdShipping));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        public IActionResult AddMerchantAr(int? IdShipping)

        {
            ///////////////
            ViewBag.Customer = iCustomer.GetAll();
            ViewBag.Area = iArea.GetAll();
            ViewBag.InformationCompanies = iInformationCompanies.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewMerchant = iMerchant.GetAll();
            if (IdShipping != null)
            {
                vmodel.Merchant = iMerchant.GetById(Convert.ToInt32(IdShipping));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, Merchant slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {

                slider.Id = model.Merchant.Id;
                slider.MerchantName = model.Merchant.MerchantName;
                slider.MerchantMob = model.Merchant.MerchantMob;
                slider.SmsAlert = model.Merchant.SmsAlert;
                slider.UsDelivery = model.Merchant.UsDelivery;
                slider.IsPublic = model.Merchant.IsPublic;
                slider.CityId = model.Merchant.CityId;
                slider.Bgw = model.Merchant.Bgw;
                slider.Cities = model.Merchant.Cities;
                slider.Hidden = model.Merchant.Hidden;
                slider.CustomerId = model.Merchant.CustomerId;
                slider.Outskirts = model.Merchant.Outskirts;
                slider.Branch = model.Merchant.Branch;
                slider.Sorting = model.Merchant.Sorting;
                slider.Credit = model.Merchant.Credit;
                slider.Bypass = model.Merchant.Bypass;
                slider.UserId = model.Merchant.UserId;
                slider.IdInformationCompanies = model.Merchant.IdInformationCompanies;                                                                       
                slider.Active = model.Merchant.Active;
                slider.DataEntry = model.Merchant.DataEntry;
                slider.DateTimeEntry = model.Merchant.DateTimeEntry;
                slider.CurrentState = model.Merchant.CurrentState;
                if (slider.Id == 0 || slider.Id == null)
                {
                    if (dbcontext.Merchants.Where(a => a.MerchantName == slider.MerchantName).ToList().Count > 0)
                    {
                        TempData["MerchantName"] = ResourceWeb.VLMerchantNameDoplceted;
                        return RedirectToAction("AddMerchant", model);
                    }
                    if (dbcontext.Merchants.Where(a => a.MerchantMob == slider.MerchantMob).ToList().Count > 0)
                    {
                        TempData["MerchantMob"] = ResourceWeb.VLMerchantMobDoplceted;
                        return RedirectToAction("AddMerchant", model);
                    }
                    var reqwest = iMerchant.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyMerchant");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iMerchant.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyMerchant");
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
            var reqwistDelete = iMerchant.deleteData(IdShipping);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyMerchant");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyMerchant");
            }
        }
    }
}
