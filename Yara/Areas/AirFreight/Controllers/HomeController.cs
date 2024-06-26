using Infarstuructre.BL;
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
		public HomeController(UserManager<ApplicationUser> userManager, IIUser iUser,MasterDbcontext dbcontext1,IIOrderNew iOrderNew1,IIUserInformation iUserInformation1)
        {
			_userManager = userManager;
            iOrderNew = iOrderNew1;
			iUserInformation= iUserInformation1;


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
			//var role = await _userManager.GetRolesAsync(user);

			//ViewBag.UserRole = role.FirstOrDefault();






			// جلب البيانات وإعداد النموذج
			vmodel.ListViewOrderNew = iOrderNew.GetAllDataentry(user.UserName);

			var filteredOrders = vmodel.ListViewOrderNew.Where(c => c.DataEntry == user.UserName).ToList();
			ViewBag.Favorit = filteredOrders.Sum(c => c.CostPrice);
			ViewBag.price = filteredOrders.Sum(c => c.Price);
			ViewBag.total = ViewBag.price - ViewBag.Favorit;
			// إرسال النموذج إلى العرض
			return View(vmodel);
		}


	}
}
