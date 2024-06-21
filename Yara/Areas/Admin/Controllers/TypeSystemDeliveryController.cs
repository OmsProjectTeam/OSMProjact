
namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,ApiRoles")]
    public class TypeSystemDeliveryController : Controller
    {
        MasterDbcontext dbcontext;
        IITypeSystemDelivery iTypeSystemDelivery;
        public TypeSystemDeliveryController(MasterDbcontext dbcontext1,IITypeSystemDelivery iTypeSystemDelivery1)
        {
            dbcontext = dbcontext1;
            iTypeSystemDelivery= iTypeSystemDelivery1;
        }
        public IActionResult MyTypeSystemDelivery()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTypeSystemDelivery = iTypeSystemDelivery.GetAll();
            return View(vmodel);
        }
        public IActionResult AddTypeSystemDelivery(int? IdTypeSystemDelivery)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListTypeSystemDelivery = iTypeSystemDelivery.GetAll();
            if (IdTypeSystemDelivery != null)
            {
                vmodel.TypeSystemDelivery = iTypeSystemDelivery.GetById(Convert.ToInt32(IdTypeSystemDelivery));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBTypeSystemDelivery slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdTypeSystemDelivery = model.TypeSystemDelivery.IdTypeSystemDelivery;
                slider.TypeSystemDelivery = model.TypeSystemDelivery.TypeSystemDelivery;
                slider.DataEntry = model.TypeSystemDelivery.DataEntry;
                slider.DateTimeEntry = model.TypeSystemDelivery.DateTimeEntry;
                slider.CurrentState = model.TypeSystemDelivery.CurrentState;
                if (slider.IdTypeSystemDelivery == 0 || slider.IdTypeSystemDelivery == null)
                {
                    if (dbcontext.TBTypeSystemDeliverys.Where(a => a.TypeSystemDelivery == slider.TypeSystemDelivery).ToList().Count > 0)
                    {
                        TempData["TypeSystemDelivery"] = ResourceWeb.VLTypeSystemDeliveryDoplceted;
                        return Redirect(returnUrl);
                    }

                    var reqwest = iTypeSystemDelivery.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyTypeSystemDelivery");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iTypeSystemDelivery.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyTypeSystemDelivery");
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
        public IActionResult DeleteData(int IdTypeSystemDelivery)
        {
            var reqwistDelete = iTypeSystemDelivery.deleteData(IdTypeSystemDelivery);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyTypeSystemDelivery");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyTypeSystemDelivery");

            }
            // تمرير التاسكات  من الادارة 
            // استخدام نظام أجايا وجيرا 


        }
    }
}
