
namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        IICustomer iCustomer;
        IIInformationCompanies iInformationCompanies;
        IICity iCity;
        IIArea iArea;
        MasterDbcontext dbcontext;
        public CustomerController(IICustomer iCustomer1, IIInformationCompanies iInformationCompanies1, IICity iCity1, IIArea iArea1,MasterDbcontext dbcontext1)
        {
            dbcontext=dbcontext1;
            iCustomer =iCustomer1;
            iInformationCompanies =iInformationCompanies1;
            iCity =iCity1;
            iArea =iArea1;
        }
        public IActionResult MyCustomer()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewCustomers = iCustomer.GetAll();
            return View(vmodel);
        }
        public IActionResult AddCustomer(int? id)

        {
            ViewBag.City = iCity.GetAll();
            ViewBag.Area = iArea.GetAll();
            ViewBag.InformationCompanies = iInformationCompanies.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewCustomers = iCustomer.GetAll();
            if (id != null)
            {
                vmodel.Customer = iCustomer.GetById(Convert.ToInt32(id));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, Customer slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.Id = model.Customer.Id;
                slider.CustName = model.Customer.CustName;
                slider.CustMob = model.Customer.CustMob;
                slider.CustMob2 = model.Customer.CustMob2;
                slider.CustCity = model.Customer.CustCity;
                slider.CustArea = model.Customer.CustArea;
                slider.CustLandmark = model.Customer.CustLandmark;
                slider.InsertDt = model.Customer.InsertDt;
                slider.CustStatus = model.Customer.CustStatus;

                slider.Gisurl = model.Customer.Gisurl;
                slider.Hexcode = model.Customer.Hexcode;
                slider.Lat = model.Customer.Lat;
                slider.Lon = model.Customer.Lon;
                slider.Fbid = model.Customer.Fbid;
                slider.FullPackage = model.Customer.FullPackage;
                slider.CustProfile = model.Customer.CustProfile;
                slider.IdInformationCompanies = model.Customer.IdInformationCompanies;
                slider.DataEntry = model.Customer.DataEntry;
                slider.DateTimeEntry = model.Customer.DateTimeEntry;             
                slider.Active = model.Customer.Active;
                slider.DataEntry = model.Customer.DataEntry;
                slider.DateTimeEntry = model.Customer.DateTimeEntry;
                slider.CurrentState = model.Customer.CurrentState;
                if (slider.Id == 0 || slider.Id == null)
                {
                    if (dbcontext.customers.Where(a => a.CustName == slider.CustName).ToList().Count > 0)
                    {
                        TempData["CustName"] = ResourceWeb.VLCustNamedoplceted;
                        return RedirectToAction("AddCustomer", model);
                    }
                    if (dbcontext.customers.Where(a => a.CustMob == slider.CustMob).ToList().Count > 0)
                    {
                        TempData["CustMob"] = ResourceWeb.VLCustMobdoplceted;
                        return RedirectToAction("AddCustomer", model);
                    }
                    if (dbcontext.customers.Where(a => a.CustMob2 == slider.CustMob2).ToList().Count > 0)
                    {
                        TempData["CustMob2"] = ResourceWeb.VLCustMob2doplceted;
                        return RedirectToAction("AddCustomer", model);
                    }
                    var reqwest = iCustomer.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyCustomer");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iCustomer.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyCustomer");
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
        public IActionResult DeleteData(int id)
        {
            var reqwistDelete = iCustomer.deleteData(id);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyCustomer");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyCustomer");
            }
        }
    }
}
