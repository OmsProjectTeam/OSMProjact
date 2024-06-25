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
			ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				return NotFound();

			var role = await _userManager.GetRolesAsync(user);

			ViewBag.UserName = user.UserName;
			ViewBag.UserId = user.Id;
			ViewBag.UserImage = user.ImageUser;
			ViewBag.Name = user.Name;

			ViewBag.UserRole = role[0];
			return View(user);

			ViewBag.UserRole = role.FirstOrDefault();

			var ssum = vmodel.ListViewOrderNew = iOrderNew.GetAllDataentry(user.UserName);






			var filteredOrders = ssum.Where(c => c.DataEntry == user.UserName).ToList();
			var CostPrice=ViewBag.Favorit = filteredOrders.Sum(c => c.CostPrice);
			var prise=ViewBag.price = filteredOrders.Sum(c => c.Price);
			ViewBag.total = prise - CostPrice;
			return View(vmodel);

		}

	}
}
