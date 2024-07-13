using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Yara.Areas.merchantAccount.Controllers
{
    [Area("merchantAccount")]
    [Authorize(Roles = "Admin,Merchant")]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        IIUserInformation iUserInformation;
		private readonly IIOrder iOrder;
		private readonly IIOrderNew iOrderNew;
		public HomeController(UserManager<ApplicationUser> userManager, IIUser iUser, IIUserInformation iUserInformation1, IIOrder iOrder, IIOrderNew iOrderNew)
        {
            _userManager = userManager;
            iUserInformation = iUserInformation1;
			this.iOrder = iOrder;
			this.iOrderNew = iOrderNew;
		}
        public async Task<IActionResult> Index(string userId)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            var userd = vmodel.sUser = iUserInformation.GetById(userId);

            var user = await _userManager.FindByIdAsync(userId);
            //var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            string phoneNumber = user.PhoneNumber;
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return View();
            }
            var newOrders = await iOrderNew.GetOrdersByPhoneAsync(phoneNumber);
			var oldOrders = await iOrder.GetOrdersByPhoneAsync(phoneNumber);

			ViewBag.NewOrders = newOrders;
			ViewBag.OldOrders = oldOrders;
            ViewBag.PhoneNumber = phoneNumber;

            return View(vmodel);
        }

		public async Task<IActionResult> IndexAr()
		{
			//var user = await _userManager.GetUserAsync(User);
			//if (user == null)
			//    return NotFound();

			//var role = await _userManager.GetRolesAsync(user);

			//ViewBag.UserName = user.UserName;
			//ViewBag.UserId = user.Id;
			//ViewBag.UserImage = user.ImageUser;
			//ViewBag.Name = user.Name;
			//ViewBag.UserRole = role[0];
			return View();
		}

		//[HttpPost("GetOrdersByPhone/{phoneNumber}")]
		//public async Task<ActionResult<IEnumerable<TBViewOrderNew>>> GetNewOrdersByPhone(string phoneNumber)
		//{
		//		var orders = await iOrderNew.GetOrdersByPhoneAsync(phoneNumber);
				
		//		return Ok(orders);
		//}
		//public async Task<ActionResult<IEnumerable<TBViewOrder>>> GetOldOrdersByPhone(string phoneNumber)
		//{
		//	var orders = await iOrder.GetOrdersByPhoneAsync(phoneNumber);

		//	return Ok(orders);
		//}
	}
}
