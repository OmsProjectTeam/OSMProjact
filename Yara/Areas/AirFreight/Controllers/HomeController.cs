using Infarstuructre.BL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Yara.Areas.AirFreight.Controllers
{
	[Area("AirFreight")]
	[Authorize(Roles = "Admin,AirFreight")]
	public class HomeController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		MasterDbcontext dbcontext;
		IIOrderNew iOrderNew;
		IIUserInformation iUserInformation;
		IIPaidings iPaidings;
		IITransfer iTransfer;
        public HomeController(UserManager<ApplicationUser> userManager, IIUser iUser, MasterDbcontext dbcontext1, IIOrderNew iOrderNew1, IIUserInformation iUserInformation1, IIPaidings iPaidings,IITransfer iTransfer1)
        {
            _userManager = userManager;
            iOrderNew = iOrderNew1;
            iUserInformation = iUserInformation1;
            this.iPaidings = iPaidings;
            iTransfer= iTransfer1;
        }
        public async Task<IActionResult> Index(string userId)
		{
			
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			//vmodel.ListlicationUser = iUserInformation.GetAllByName(user.UserName).Take(1);
			var userd=vmodel.sUser = iUserInformation.GetById(userId);
            var user = await _userManager.GetUserAsync(User);
			if (user == null)
				return NotFound();
			// الحصول على دور المستخدم
			var role = await _userManager.GetRolesAsync(user);

			ViewBag.UserRole = role.FirstOrDefault();


			// جلب البيانات وإعداد النموذج
			vmodel.ListViewOrderNew = iOrderNew.GetAllDataentry(user.UserName);

			
			var filteredOrders = vmodel.ListViewOrderNew.Where(c => c.DataEntry == user.UserName).ToList();
			ViewBag.Favorit = filteredOrders.Sum(c => c.CostPrice);
			ViewBag.price = filteredOrders.Sum(c => c.Price);
			ViewBag.ExchangedPrice = filteredOrders.Sum(c => c.ExchangedPrice);
			ViewBag.total = ViewBag.price - ViewBag.Favorit;

            vmodel.ListViewPaings = iPaidings.GetAllDataentry(user.UserName);

           var tran = vmodel.ListViewPaings.ToList();
			ViewBag.paidings = tran.Sum(p => p.ResivedMony);





			vmodel.ListViewTransfer = iTransfer.GetAllDataentry(user.UserName);

           var pay = vmodel.ListViewTransfer.ToList();
			ViewBag.Trans = pay.Sum(p => p.TransferAmount);


			//vmodel.ListViewOrder = iOrder.GetAllDataentry(user.PhoneNumber).Take(10);

			// إرسال النموذج إلى العرض
			return View(vmodel);
		}

		public async Task<IActionResult> IndexAr(string userId)
		{

			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			//vmodel.ListlicationUser = iUserInformation.GetAllByName(user.UserName).Take(1);
			var userd = vmodel.sUser = iUserInformation.GetById(userId);

			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				return NotFound();
			// الحصول على دور المستخدم
			//var role = await _userManager.GetRolesAsync(user);

			//ViewBag.UserRole = role.FirstOrDefault();






			// جلب البيانات وإعداد النموذج
			vmodel.ListViewOrderNew = iOrderNew.GetAllDataentry(user.UserName);

			var filteredOrders = vmodel.ListViewOrderNew.Where(c => c.DataEntry == user.UserName).ToList();
			ViewBag.Favorit = filteredOrders.Sum(c => c.CostPrice);
			ViewBag.price = filteredOrders.Sum(c => c.Price);
			ViewBag.total = ViewBag.price - ViewBag.Favorit;
			ViewBag.paidings = ViewBag.price - ViewBag.total;
			// إرسال النموذج إلى العرض
			return View(vmodel);
		}


	}
}
