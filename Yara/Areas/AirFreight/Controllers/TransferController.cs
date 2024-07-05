using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.AirFreight.Controllers;

[Area("AirFreight")]
[Authorize(Roles = "Admin,AirFreight")]
public class TransferController : Controller
{
	IITransfer iTransfer;
	IIOrderNew iOrderNew;
	IICurrenciesExchangeRates exchangeRates;
	MasterDbcontext dbcontext;
	UserManager<ApplicationUser> userManager;
	public TransferController(IIOrderNew iOrderNew, IITransfer iTransfer, IICurrenciesExchangeRates exchangeRates, MasterDbcontext dbcontext, UserManager<ApplicationUser> userManager)
	{
		this.iOrderNew = iOrderNew;
		this.iTransfer = iTransfer;
		this.exchangeRates = exchangeRates;
		this.dbcontext = dbcontext;
		this.userManager = userManager;
	}

	public async Task<IActionResult> MyTransfer()
	{
		ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
		var user = vmodel.sUser = await userManager.GetUserAsync(User);
		vmodel.ListViewTransfer = iTransfer.GetAllDataentry(user.UserName);
		return View(vmodel);
	}

	public async Task<IActionResult> MyTransferAr()
	{
		ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
		var user = vmodel.sUser = await userManager.GetUserAsync(User);
		vmodel.ListViewTransfer = iTransfer.GetAllDataentry(user.UserName);
		return View(vmodel);
	}

	public async Task<IActionResult> AddTransfer(int? IdProfit)
	{
		ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();

		ViewBag.Currency = exchangeRates.GetAll();
		ViewBag.Order = iOrderNew.GetAll();
		var user = vmodel.sUser = await userManager.GetUserAsync(User);


		vmodel.ListViewTransfer = iTransfer.GetAllDataentry(user.UserName);
		if (IdProfit != null)
		{
			vmodel.Transfer = iTransfer.GetById(Convert.ToInt32(IdProfit));
			return View(vmodel);
		}
		else
		{
			return View(vmodel);
		}
	}

	public async Task<IActionResult> AddTransferAr(int? IdProfit)
	{
		ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();

		ViewBag.Currency = exchangeRates.GetAll();
		ViewBag.Order = iOrderNew.GetAll();
		var user = vmodel.sUser = await userManager.GetUserAsync(User);


		vmodel.ListViewTransfer = iTransfer.GetAllDataentry(user.UserName);
		if (IdProfit != null)
		{
			vmodel.Transfer = iTransfer.GetById(Convert.ToInt32(IdProfit));
			return View(vmodel);
		}
		else
		{
			return View(vmodel);
		}
	}

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Save(ViewmMODeElMASTER model, TBTransfer slider, List<IFormFile> Files, string returnUrl)
    {
        try
        {
            slider.ReceiptNo = model.Transfer.ReceiptNo;
            slider.ReceiptStatment = model.Transfer.ReceiptStatment;
            slider.IdCurrency = model.Transfer.IdCurrency;
            slider.CurrentState = model.Transfer.CurrentState;
            slider.DateTimeEntry = model.Transfer.DateTimeEntry;
            slider.IdOrderNew = model.Transfer.IdOrderNew;
            slider.DataEntry = model.Transfer.DataEntry;
            slider.ExchangeAmount = model.Transfer.ExchangeAmount;
            slider.TransferAmount = model.Transfer.TransferAmount;
            slider.ReceiptNo = model.Transfer.ReceiptNo;
            slider.CurrentState = model.Transfer.CurrentState;
            var file = HttpContext.Request.Form.Files;
            if (slider.IdTransfer == 0 || slider.IdTransfer == null)
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
                if (dbcontext.TBTransfers.Where(a => a.ReceiptNo == slider.ReceiptNo).ToList().Count > 0)
                {
                    TempData["DescriptionClint"] = ResourceWeb.VLDescriptionClintDoplceted;
                    return Redirect(returnUrl);
                }
                var reqwest = iTransfer.saveData(slider);
                if (reqwest == true)
                {
                    TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                    return RedirectToAction("MyTransfer");
                }
                else
                {
                    TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
                    return Redirect(returnUrl);
                }
            }
            else
            {
                var reqestUpdate = iTransfer.UpdateData(slider);
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
    [Authorize(Roles = "Admin")]
	public IActionResult DeleteData(int id)
	{
		var reqwistDelete = iTransfer.deleteData(id);
		if (reqwistDelete == true)
		{
			TempData["Saved successfully"] = ResourceWeb.VLdELETESuccessfully;
			return RedirectToAction("MyTransfer");
		}
		else
		{
			TempData["ErrorSave"] = ResourceWeb.VLErrorDeleteData;
			return RedirectToAction("MyTransfer");
		}
	}
}
