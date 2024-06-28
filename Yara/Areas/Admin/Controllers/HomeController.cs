

using Infarstuructre.BL;
using Microsoft.AspNetCore.Authorization;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class HomeController : Controller
    {
		private readonly UserManager<ApplicationUser> _userManager;
		MasterDbcontext dbcontext;
		IIOrderNew iOrderNew;
		IIUserInformation iUserInformation;
		public HomeController(UserManager<ApplicationUser> userManager, IIUser iUser, MasterDbcontext dbcontext1, IIOrderNew iOrderNew1, IIUserInformation iUserInformation1)
        {
			_userManager = userManager;
			iOrderNew = iOrderNew1;
			iUserInformation= iUserInformation1;
		}





		public async Task<IActionResult> Index(string userId)
		{
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			//vmodel.ListlicationUser = iUserInformation.GetAllByName(user.UserName).Take(1);
			var userd = vmodel.sUser = iUserInformation.GetById(userId);

			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				return NotFound();
			// الحصول على دور المستخدم
			var role = await _userManager.GetRolesAsync(user);

			ViewBag.UserRole = role.FirstOrDefault();

			// جلب البيانات وإعداد النموذج
			vmodel.ListViewOrderNew = iOrderNew.GetAll();
			var filteredOrders = vmodel.ListViewOrderNew=iOrderNew.GetAll();
			ViewBag.Favorit = filteredOrders.Sum(c => c.CostPrice);
			ViewBag.price = filteredOrders.Sum(c => c.Price);
			ViewBag.total = ViewBag.price - ViewBag.Favorit;
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
			var role = await _userManager.GetRolesAsync(user);

			ViewBag.UserRole = role.FirstOrDefault();

			// جلب البيانات وإعداد النموذج
			vmodel.ListViewOrderNew = iOrderNew.GetAll();
			var filteredOrders = vmodel.ListViewOrderNew = iOrderNew.GetAll();
			ViewBag.Favorit = filteredOrders.Sum(c => c.CostPrice);
			ViewBag.price = filteredOrders.Sum(c => c.Price);
			ViewBag.total = ViewBag.price - ViewBag.Favorit;
			// إرسال النموذج إلى العرض
			return View(vmodel);
		}
		[AllowAnonymous]
		public IActionResult Denied()
        {
            return View();
        }
    }
}
