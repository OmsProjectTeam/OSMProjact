﻿using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.Controllers
{


    [Area("Admin")]
    [Authorize(Roles = "Admin,ApiRoles")]

    public class PaidingsController : Controller
    {
        IIPaidings iPaidings;
        MasterDbcontext dbcontext;
        IIOrderNew iOrderNew;
        public PaidingsController(IIPaidings iPaidings1,MasterDbcontext dbcontext1,IIOrderNew iOrderNew1)
        {
            iPaidings = iPaidings1;
            dbcontext = dbcontext1;
            iOrderNew = iOrderNew1;
        }

        public IActionResult MyPaiding()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewPaings = iPaidings.GetAll();
            return View(vmodel);
        }

        public IActionResult MyPaidingAr()
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewPaings = iPaidings.GetAll();
            return View(vmodel);
        }



        public IActionResult AddPaidingsImage(int? IdPaings)
        {
            ViewBag.Order = iOrderNew.GetAll();


            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewPaings = iPaidings.GetAll();
            if (IdPaings != null)
            {
                vmodel.Paing = iPaidings.GetById(Convert.ToInt32(IdPaings));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        public IActionResult AddPaidingsArImageAr(int? IdPaings)
        {
            ViewBag.Order = iOrderNew.GetAll();


            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewPaings = iPaidings.GetAll();
            if (IdPaings != null)
            {
                vmodel.Paing = iPaidings.GetById(Convert.ToInt32(IdPaings));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }


        public IActionResult AddPaidings(int? IdPaings)
        {
            ViewBag.Order = iOrderNew.GetAll();


            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewPaings = iPaidings.GetAll();
            if (IdPaings != null)
            {
                vmodel.Paing = iPaidings.GetById(Convert.ToInt32(IdPaings));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }

        public IActionResult AddPaidingsAr(int? IdPaings)
        {
            ViewBag.Order = iOrderNew.GetAll();


            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewPaings = iPaidings.GetAll();
            if (IdPaings != null)
            {
                vmodel.Paing = iPaidings.GetById(Convert.ToInt32(IdPaings));
                return View(vmodel);
            }
            else
            {
                return View(vmodel);
            }
        }









        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBPaing slider, List<IFormFile> Files, string returnUrl)
        {
            try
            {
                slider.IdPaings = model.Paing.IdPaings;
                slider.IdOrderNew = model.Paing.IdOrderNew;
                slider.ResivedMony = model.Paing.ResivedMony;
                slider.Photo = model.Paing.Photo;
                slider.ReceiptNo = model.Paing.ReceiptNo;
                slider.ReceiptStatment = model.Paing.ReceiptStatment;
                slider.ReceiptDate = model.Paing.ReceiptDate;             
                slider.DataEntry = model.Paing.DataEntry;
                slider.DateTimeEntry = model.Paing.DateTimeEntry;
                slider.CurrentState = model.Paing.CurrentState;               
                slider.Photo = model.Paing.Photo;           
                var file = HttpContext.Request.Form.Files;
                if (slider.IdPaings == 0 || slider.IdPaings == null)
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
                    if (dbcontext.TBPaings.Where(a => a.ReceiptNo == slider.ReceiptNo).ToList().Count > 0)
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);

                        TempData["ReceiptNo"] = ResourceWeb.VLReceiptNoDoplceted;
                        return Redirect(returnUrl);
                    }

                    var reqwest = iPaidings.saveData(slider);
                    if (reqwest == true)
                    {
                        TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyPaiding");
                    }
                    else
                    {
                        var PhotoNAme = slider.Photo;
                        var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
                        TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    //var reqweistDeletPoto = iPaidings.DELETPHOTO(slider.IdInformationCompanies);

                    if (file.Count() == 0)

                    {
                        slider.Photo = model.Paing.Photo;
                        //TempData["Message"] = ResourceWeb.VLimageuplode;
                        var reqestUpdate2 = iPaidings.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MyPaiding");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            //var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }
                    else
                    {
                        var reqweistDeletPoto = iPaidings.DELETPHOTO(slider.IdPaings);
                        var reqestUpdate2 = iPaidings.UpdateData(slider);
                        if (reqestUpdate2 == true)
                        {
                            TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                            return RedirectToAction("MyPaiding");
                        }
                        else
                        {
                            var PhotoNAme = slider.Photo;
                            var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
                            TempData["ErrorSave"] = ResourceWeb.VLErrorUpdate;
                            return Redirect(returnUrl);
                        }
                    }

                    //var reqestUpdate = iPaidings.UpdateData(slider);
                    //if (reqestUpdate == true)
                    //{
                    //	TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
                    //	return RedirectToAction("MyPaidingAr");
                    //}
                    //else
                    //{
                    //	var PhotoNAme = slider.Photo;
                    //	var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
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
                    //var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
                else
                {
                    var PhotoNAme = slider.Photo;
                    var delet = iPaidings.DELETPHOTOWethError(PhotoNAme);
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteData(int IdPaings)
        {
            var reqwistDelete = iPaidings.deleteData(IdPaings);
            if (reqwistDelete == true)
            {
                TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
                return RedirectToAction("MyPaiding");
            }
            else
            {
                TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
                return RedirectToAction("MyPaiding");
            }
        }

      
    }
}
