using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Yara.Areas.AirFreight.Controllers
{
	[Area("AirFreight")]
	[Authorize(Roles = "Admin,AirFreight")]
	public class HomeController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		MasterDbcontext dbcontext;
		IIOrderNew iOrderNew;
        public HomeController(UserManager<ApplicationUser> userManager, IIUser iUser,MasterDbcontext dbcontext1,IIOrderNew iOrderNew1)
        {
			_userManager = userManager;
            iOrderNew = iOrderNew1;

        }
		public async Task<IActionResult> Index()
		{
			// إعداد النموذج
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				return NotFound();

			// الحصول على دور المستخدم
			var role = await _userManager.GetRolesAsync(user);

			// إعداد بيانات العرض
			ViewBag.UserName = user.UserName;
			ViewBag.UserId = user.Id;
			ViewBag.UserImage = user.ImageUser;
			ViewBag.Name = user.Name;
			ViewBag.UserRole = role.FirstOrDefault();
			ViewBag.imag = user.ImageUser;



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
