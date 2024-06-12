
namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class InformationCompaniesController : Controller
    {
        MasterDbcontext dbcontext;
        IIInformationCompanies iInformationCompanies;
        IITypesCompanies iTypesCompanies;
        public InformationCompaniesController(MasterDbcontext dbcontext1,IIInformationCompanies iInformationCompanies1,IITypesCompanies iTypesCompanies1)
        {
            dbcontext = dbcontext1;
            iInformationCompanies = iInformationCompanies1;
            iTypesCompanies = iTypesCompanies1;
        }
        public IActionResult MYInformationCompanies()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewInformationCompanies = iInformationCompanies.GetAll();
            return View(vmodel);
        }
        public IActionResult AddEditInformationCompanies(int? IdInformationCompanies)
        {
            ViewBag.Categorie = iTypesCompanies.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewInformationCompanies = iInformationCompanies.GetAll();
            if (IdInformationCompanies != null)
            {
                vmodel.InformationCompanies = iInformationCompanies.GetById(Convert.ToInt32(IdInformationCompanies));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        public IActionResult AddEditInformationCompaniesImage(int? IdInformationCompanies)
        {
            ViewBag.Categorie = iTypesCompanies.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewInformationCompanies = iInformationCompanies.GetAll();
            if (IdInformationCompanies != null)
            {
                vmodel.InformationCompanies = iInformationCompanies.GetById(Convert.ToInt32(IdInformationCompanies));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBInformationCompanies slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdInformationCompanies = model.InformationCompanies.IdInformationCompanies;
                slider.IdTypesCompanies = model.InformationCompanies.IdTypesCompanies;
                slider.CompanyName = model.InformationCompanies.CompanyName;
                slider.PhoneCompany = model.InformationCompanies.PhoneCompany;
                slider.PhoneCompanySecand = model.InformationCompanies.PhoneCompanySecand;
                slider.EmailCompany = model.InformationCompanies.EmailCompany;
                slider.AddresCompany = model.InformationCompanies.AddresCompany;
                slider.Photo = model.InformationCompanies.Photo;
                slider.CompanyURl = model.InformationCompanies.CompanyURl;
                slider.CompanyDescription = model.InformationCompanies.CompanyDescription;
                slider.Active = model.InformationCompanies.Active;        
                slider.DateTimeEntry = model.InformationCompanies.DateTimeEntry;
                slider.DataEntry = model.InformationCompanies.DataEntry;
                slider.CurrentState = model.InformationCompanies.CurrentState;
                slider.NikeNAme = model.InformationCompanies.NikeNAme;
                var file = HttpContext.Request.Form.Files;
             
                if (slider.IdInformationCompanies == 0 || slider.IdInformationCompanies == null)
                {
                    if (file.Count() > 0)
                    {
                        string Photo = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                        var fileStream = new FileStream(Path.Combine(@"wwwroot/Images/Home", Photo), FileMode.Create);
                        file[0].CopyTo(fileStream);
                        slider.Photo = Photo;
                        fileStream.Close();
                    }
                    else
                    {
                        TempData["Message"] = ResourceWeb.VLimageuplode;
                        return Redirect(returnUrl);
                    }
                    if (dbcontext.TBInformationCompaniess.Where(a => a.CompanyName == slider.CompanyName).ToList().Count > 0)
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iInformationCompanies.DELETPHOTOWethError(PhotoNAme);

                        TempData["CompanyName"] = ResourceWeb.VLCompanyNameDoplceted;
                        return RedirectToAction("AddEditInformationCompanies", model);
                    }
                  
                    var reqwest = iInformationCompanies.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYInformationCompanies");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iInformationCompanies.DELETPHOTOWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iInformationCompanies.DELETPHOTO(slider.IdInformationCompanies);

                    if (file.Count() == 0)

                    {
                        slider.Photo = model.InformationCompanies.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iInformationCompanies.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYInformationCompanies");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iInformationCompanies.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iInformationCompanies.DELETPHOTO(slider.IdInformationCompanies);
                        var reqestUpdate2 = iInformationCompanies.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYInformationCompanies");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iInformationCompanies.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }

                    //var reqestUpdate = iInformationCompanies.UpdateData(slider);
                    //if (reqestUpdate == true)
                    //{
                    //	TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                    //	return RedirectToAction("MYInformationCompanies");
                    //}
                    //else
                    //{
                    //	var PhotoNAme = slider.Photo;
                    //	var delet = iInformationCompanies.DELETPHOTOWethError(PhotoNAme);
                    //	TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                    //	return Redirect(returnUrl);
                    //}

                }
            }
            catch
            {
                var file = HttpContext.Request.Form.Files;
                if (file.Count() == 0)

                {
                    //var PhotoNAme = slider.Photo;
                    //var delet = iInformationCompanies.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iInformationCompanies.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }

            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdInformationCompanies)
        {
            var reqwistDelete = iInformationCompanies.deleteData(IdInformationCompanies);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MYInformationCompanies");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MYInformationCompanies");
            }
        }
    }
}
