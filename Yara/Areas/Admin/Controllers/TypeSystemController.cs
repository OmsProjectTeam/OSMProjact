using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TypeSystemController : Controller
    {
        MasterDbcontext dbcontext;
        IITypeSystem iTypeSystem;
        public TypeSystemController(MasterDbcontext dbcontext1,IITypeSystem iTypeSystem1)
        {
            dbcontext = dbcontext1;
            iTypeSystem= iTypeSystem1;
        }
        public IActionResult MyTypeSystem()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTypeSystem = iTypeSystem.GetAll();
            return View(vmodel);
        }
        public IActionResult AddTypeSystem(int? IdTypeSystem)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTypeSystem = iTypeSystem.GetAll();
            if (IdTypeSystem != null)
            {
                vmodel.TypeSystem = iTypeSystem.GetById(Convert.ToInt32(IdTypeSystem));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBTypeSystem slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdTypeSystem = model.TypeSystem.IdTypeSystem;
                slider.TypeSystem = model.TypeSystem.TypeSystem;
                slider.Active = model.TypeSystem.Active;
                slider.DataEntry = model.TypeSystem.DataEntry;
                slider.DateTimeEntry = model.TypeSystem.DateTimeEntry;
                slider.CurrentState = model.TypeSystem.CurrentState;
                if (slider.IdTypeSystem == 0 || slider.IdTypeSystem == null)
                {
                    if (dbcontext.TBTypeSystems.Where(a => a.TypeSystem == slider.TypeSystem).ToList().Count > 0)
                    {
                        TempData["TypeSystem"] = ResourceWeb.VLTypeSystemDoplceted;
                        return RedirectToAction("AddTypeSystem", model);
                    }

                    var reqwest = iTypeSystem.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyTypeSystem");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iTypeSystem.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyTypeSystem");
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
        public IActionResult DeleteData(int IdTypeSystem)
        {
            var reqwistDelete = iTypeSystem.deleteData(IdTypeSystem);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyTypeSystem");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyTypeSystem");

            }
            // تمرير التاسكات  من الادارة 
            // استخدام نظام أجايا وجيرا 


        }
    }
}
