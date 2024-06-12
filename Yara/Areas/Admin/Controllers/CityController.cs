using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        MasterDbcontext dbcontext;
        IICity iCity;
        public CityController(MasterDbcontext dbcontext1,IICity iCity1)
        {
            dbcontext = dbcontext1;
            iCity = iCity1;
        }
        public IActionResult MyCity()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCity = iCity.GetAll();
            return View(vmodel);
        }
        public IActionResult AddCity(int? Id)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListCity = iCity.GetAll();
            if (Id != null)
            {
                vmodel.City = iCity.GetById(Convert.ToInt32(Id));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, City slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.Id = model.City.Id;
                slider.Description = model.City.Description;
                slider.IsNorth = model.City.IsNorth;

                slider.DataEntry = model.City.DataEntry;
                slider.DateTimeEntry = model.City.DateTimeEntry;
                slider.CurrentState = model.City.CurrentState;

                if (slider.Id == 0 || slider.Id == null)
                {
                    if (dbcontext.cities.Where(a => a.Description == slider.Description).ToList().Count > 0)
                    {
                        TempData["Description"] = ResourceWeb.VLDescriptionDoplceted;
                        return RedirectToAction("AddCity", model);
                    }

                    var reqwest = iCity.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyCity");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iCity.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyCity");
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
        public IActionResult DeleteData(int Id)
        {
            var reqwistDelete = iCity.deleteData(Id);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyCity");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyCity");

            }
            // تمرير التاسكات  من الادارة 
            // استخدام نظام أجايا وجيرا 


        }
    }
}
