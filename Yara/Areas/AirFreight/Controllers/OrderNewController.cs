﻿using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.AirFreight.Controllers
{
	[Area("AirFreight")]
	[Authorize(Roles = "Admin,AirFreight")]
	public class OrderNewController : Controller
	{
		IIOrderNew iOrderNew;
		IIOrderCase iOrderCase;
		IIOrderStatus iOrderStatus;
		IIClintWitheDeliveryTariffs iClintWitheDeliveryTariffs;
		private readonly UserManager<ApplicationUser> _userManager;
		MasterDbcontext dbcontext;
		IIUserInformation iUserInformation;
		public OrderNewController(IIOrderNew iOrderNew1, IIOrderCase iOrderCase1, IIOrderStatus iOrderStatus1, IIClintWitheDeliveryTariffs iClintWitheDeliveryTariffs1, UserManager<ApplicationUser> userManager, IIUser iUser, MasterDbcontext dbcontext1, IIUserInformation iUserInformation1)
		{
			iOrderNew = iOrderNew1;
			iOrderCase = iOrderCase1;
			iOrderStatus = iOrderStatus1;
			iClintWitheDeliveryTariffs = iClintWitheDeliveryTariffs1;
			dbcontext = dbcontext1;
			iUserInformation= iUserInformation1;
			_userManager=userManager;
		}
		public async Task<IActionResult> MyOrderNew(string userId)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			

			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
				return NotFound();
			vmodel.ListViewOrderNew = iOrderNew.GetAllDataentry(user.UserName);
			//vmodel.ListlicationUser = (IEnumerable<ApplicationUser>)iUserInformation.GetAllByName(name).Take(1);
			//vmodel.ListlicationUser = iUserInformation.GetAllByName(user.UserName).Take(1);
			return View(vmodel);


		}

		public async Task<IActionResult> MyOrderNewAr(string userId)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();


			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
				return NotFound();
			vmodel.ListViewOrderNew = iOrderNew.GetAllDataentry(user.UserName);
			//vmodel.ListlicationUser = (IEnumerable<ApplicationUser>)iUserInformation.GetAllByName(name).Take(1);
			vmodel.ListlicationUser = iUserInformation.GetAllByName(user.UserName).Take(1);
			return View(vmodel);
		}

		public IActionResult AddOrderNew(int? IdOrderNew,string name)
		{
			ViewBag.OrderCase = iOrderCase.GetAll();
			ViewBag.OrderStatus = iOrderStatus.GetAll();
			ViewBag.ClintWith = iClintWitheDeliveryTariffs.GetAll();
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

        public IActionResult AddOrderNewAr(int? IdOrderNew, string name)
        {
            ViewBag.OrderCase = iOrderCase.GetAll();
            ViewBag.OrderStatus = iOrderStatus.GetAll();
            ViewBag.ClintWith = iClintWitheDeliveryTariffs.GetAll();
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
				slider.IdClintWitheDeliveryTariffs = 3;
				slider.IdorderStatus = 1037;
				slider.IdorderCases = 3;
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
				if (slider.IdOrderNew == 0 || slider.IdOrderNew == null)
				{
					if (dbcontext.TBOrderNews.Where(a => a.DescriptionOrder == slider.DescriptionOrder).ToList().Count > 0)
					{
						TempData["DescriptionOrder"] = ResourceWeb.VLDescriptionOrderDoplceted;
						return Redirect(returnUrl);
					}
					var reqwest = iOrderNew.saveData(slider);
					if (reqwest == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLSavedSuccessfully;
                        return RedirectToAction("MyOrderNew", new { name = slider.DataEntry });
                    }
					else
					{
						TempData["ErrorSave"] = ResourceWeb.VLErrorSave;
						return Redirect(returnUrl);
					}
				}
				else
				{
					var reqestUpdate = iOrderNew.UpdateData(slider);
					if (reqestUpdate == true)
					{
						TempData["Saved successfully"] = ResourceWeb.VLUpdatedSuccessfully;
						return RedirectToAction("MyOrderNew");
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
	}
}
