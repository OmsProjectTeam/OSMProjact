﻿

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,ApiRoles")]
    public class OrderNewController : Controller
    {
        IIOrderNew iOrderNew;
        IIOrderCase iOrderCase;
        IIOrderStatus iOrderStatus;
        IIClintWitheDeliveryTariffs iClintWitheDeliveryTariffs;
        MasterDbcontext dbcontext;
        IIShippingPrice iShippingPrice;
        public OrderNewController(IIOrderNew iOrderNew1, IIOrderCase iOrderCase1, IIOrderStatus iOrderStatus1, IIClintWitheDeliveryTariffs iClintWitheDeliveryTariffs1,MasterDbcontext dbcontext1,IIShippingPrice iShippingPrice1)
        {
            iOrderNew = iOrderNew1;
            iOrderCase = iOrderCase1;
            iOrderStatus = iOrderStatus1;
            iClintWitheDeliveryTariffs = iClintWitheDeliveryTariffs1;
            dbcontext = dbcontext1;
            iShippingPrice= iShippingPrice1;
        }
        public IActionResult MyOrderNew()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrderNew = iOrderNew.GetAll();
            return View(vmodel);
        }

        public IActionResult MyOrderNewAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrderNew = iOrderNew.GetAll();
            return View(vmodel);
        }
        public IActionResult AddOrderNew(int? IdOrderNew)
        {
            ViewBag.OrderCase = iOrderCase.GetAll();
            ViewBag.OrderStatus = iOrderStatus.GetAll();
            ViewBag.ClintWith = iClintWitheDeliveryTariffs.GetAll();
            ViewBag.ShippingPrice = iShippingPrice.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrderNew = iOrderNew.GetAll();
            if (IdOrderNew != null)
            {
                vmodel.OrderNew = iOrderNew.GetById(Convert.ToInt32(IdOrderNew));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        public IActionResult AddOrderNewAr(int? IdOrderNew)
        {
            ViewBag.OrderCase = iOrderCase.GetAll();
            ViewBag.OrderStatus = iOrderStatus.GetAll();
            ViewBag.ClintWith = iClintWitheDeliveryTariffs.GetAll();
            ViewBag.ShippingPrice = iShippingPrice.GetAll();
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewOrderNew = iOrderNew.GetAll();
            if (IdOrderNew != null)
            {
                vmodel.OrderNew = iOrderNew.GetById(Convert.ToInt32(IdOrderNew));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBOrderNew slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdOrderNew = model.OrderNew.IdOrderNew;
                slider.IdClintWitheDeliveryTariffs = model.OrderNew.IdClintWitheDeliveryTariffs;
                slider.IdInformationCompanies = model.OrderNew.IdInformationCompanies;
                slider.IdorderStatus = model.OrderNew.IdorderStatus;
                slider.IdorderCases = model.OrderNew.IdorderCases;
                slider.OrderDate = model.OrderNew.OrderDate;
                slider.DescriptionOrder = model.OrderNew.DescriptionOrder;
                slider.Weight = model.OrderNew.Weight;
                slider.CostPrice = model.OrderNew.CostPrice;
                slider.Price = model.OrderNew.Price;
                slider.Addres = model.OrderNew.Addres;
                slider.Nouts = model.OrderNew.Nouts;                         
                slider.DataEntry = model.OrderNew.DataEntry;
                slider.DateTimeEntry = model.OrderNew.DateTimeEntry;
                slider.CurrentState = model.OrderNew.CurrentState;
                var file = HttpContext.Request.Form.Files;
                if (slider.IdOrderNew == 0 || slider.IdOrderNew == null)
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
                    //if (dbcontext.TBInformationCompaniess.Where(a => a.CompanyName == slider.CompanyName).ToList().Count > 0)
                    //{
                    //    var PhotoNAme = slider.Photo;
                    //    var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);

                    //    TempData["CompanyName"] = ResourceWeb.VLCompanyNameDoplceted;
                    //    return RedirectToAction("AddEditInformationCompanies", model);
                    //}

                    var reqwest = iOrderNew.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MYInformationCompanies");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iOrderNew.DELETPHOTO(slider.IdInformationCompanies);

                    if (file.Count() == 0)

                    {
                        slider.Photo = model.OrderNew.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iOrderNew.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYInformationCompanies");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iOrderNew.DELETPHOTO(slider.IdInformationCompanies);
                        var reqestUpdate2 = iOrderNew.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MYInformationCompanies");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }

                    //var reqestUpdate = iOrderNew.UpdateData(slider);
                    //if (reqestUpdate == true)
                    //{
                    //	TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                    //	return RedirectToAction("MYInformationCompanies");
                    //}
                    //else
                    //{
                    //	var PhotoNAme = slider.Photo;
                    //	var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
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
                    //var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iOrderNew.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
                }
            }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdOrderNew)
        {
            var reqwistDelete = iOrderNew.deleteData(IdOrderNew);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyOrderNew");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyOrderNew");
            }
        }

        [HttpGet]
        public IActionResult GetPrices(int selectedCompanyId, float weight)
        {
            var prices = iShippingPrice.GetAll()
                .FirstOrDefault(x => x.IdInformationCompanies == selectedCompanyId);

            if (prices != null)
            {
                if (weight <= 10)
                {
                    return Json(new { costPrice = prices.CoPricePerkgUnder10, price = prices.CoPricePerkgAbove10 });
                }
                else
                {
                    return Json(new { costPrice = prices.ClintPricePerkgUnder10, price = prices.ClintPricePerkgAbove10 });
                }
            }

            return Json(null);
        }

    }
}