

using Infarstuructre.BL;
using Microsoft.EntityFrameworkCore;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CustomerMessagesController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IITypesOfMessage iTypesOfMessage;
        IICustomerMessages iCustomerMessages;
        IIUserInformation iUserInformation;
        public CustomerMessagesController(UserManager<ApplicationUser> userManager,IITypesOfMessage iTypesOfMessage1,IICustomerMessages iCustomerMessages1, IIUserInformation iUserInformation1)
        {
            _userManager = userManager;
            iTypesOfMessage = iTypesOfMessage1;
            iCustomerMessages = iCustomerMessages1;
            iUserInformation = iUserInformation1;
        }

        public IActionResult MyCustomerMessages()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewCustomerMessages = iCustomerMessages.GetAll();
            return View(vmodel);
        }

        public IActionResult MyCustomerMessagesAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewCustomerMessages = iCustomerMessages.GetAll();
            return View(vmodel);
        }

        public IActionResult AddCustomerMessages(int? IdCustomerMessages)
        {
            ViewBag.TypesOfMessage = iTypesOfMessage.GetAll();
            ViewBag.user = iUserInformation.GetAllByNameall();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewCustomerMessages = iCustomerMessages.GetAll();
            if (IdCustomerMessages != null)
            {
                vmodel.CustomerMessages = iCustomerMessages.GetById(Convert.ToInt32(IdCustomerMessages));
                return View(vmodel);
            }
            return View(vmodel);
        }

        public IActionResult AddCustomerMessagesAr(int? IdCustomerMessages)
        {
            ViewBag.TypesOfMessage = iTypesOfMessage.GetAll();
            ViewBag.user = iUserInformation.GetAllByNameall();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewCustomerMessages = iCustomerMessages.GetAll();
            if (IdCustomerMessages != null)
            {
                vmodel.CustomerMessages = iCustomerMessages.GetById(Convert.ToInt32(IdCustomerMessages));
                return View(vmodel);
            }
            return View(vmodel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBCustomerMessages slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdCustomerMessages = model.CustomerMessages.IdCustomerMessages;
                slider.IdTypesOfMessage = model.CustomerMessages.IdTypesOfMessage;
                slider.IdUser = model.CustomerMessages.IdUser;
                slider.Title = model.CustomerMessages.Title;
                slider.MessageDescription = model.CustomerMessages.MessageDescription;
                slider.DataEntry = model.CustomerMessages.DataEntry;
                slider.DateTimeEntry = model.CustomerMessages.DateTimeEntry;
                slider.CurrentState = model.CustomerMessages.CurrentState;     
                if (slider.IdCustomerMessages == 0 || slider.IdCustomerMessages == null)
                {
                  
                    var reqwest = iCustomerMessages.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyCustomerMessages");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iCustomerMessages.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyCustomerMessages");
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
        public async Task<IActionResult> SaveAr(ViewmMODeElMASTER model, TBCustomerMessages slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdCustomerMessages = model.CustomerMessages.IdCustomerMessages;
                slider.IdTypesOfMessage = model.CustomerMessages.IdTypesOfMessage;
                slider.IdUser = model.CustomerMessages.IdUser;
                slider.Title = model.CustomerMessages.Title;
                slider.MessageDescription = model.CustomerMessages.MessageDescription;
                slider.DataEntry = model.CustomerMessages.DataEntry;
                slider.DateTimeEntry = model.CustomerMessages.DateTimeEntry;
                slider.CurrentState = model.CustomerMessages.CurrentState;
                if (slider.IdCustomerMessages == 0 || slider.IdCustomerMessages == null)
                {
                
                    var reqwest = iCustomerMessages.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyCustomerMessagesAr");
                    }
                    else
                    {
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    var reqestUpdate = iCustomerMessages.UpdateData(slider);
                    if (reqestUpdate == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                        return RedirectToAction("MyCustomerMessagesAr");
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
        public IActionResult DeleteData(int IdCustomerMessages)
        {
            var reqwistDelete = iCustomerMessages.deleteData(IdCustomerMessages);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyCustomerMessages");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyCustomerMessages");
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteDataAr(int IdCustomerMessages)
        {
            var reqwistDelete = iCustomerMessages.deleteData(IdCustomerMessages);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWebAr.VLdELETESuccessfully;
                return RedirectToAction("MyCustomerMessagesAr");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWebAr.VLErrorDeleteData;
                return RedirectToAction("MyCustomerMessagesAr");
            }
        }
    }
}
