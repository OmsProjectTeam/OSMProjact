using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.merchantAccount.Controllers
{
    [Area("merchantAccount")]
    [Authorize(Roles = "Admin,Merchant")]
    public class HistoryController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        IIUserInformation iUserInformation;
        private readonly IIOrder iOrder;
        private readonly IIOrderNew iOrderNew;

        public HistoryController(UserManager<ApplicationUser> userManager, IIUser iUser, IIUserInformation iUserInformation1, IIOrder iOrder, IIOrderNew iOrderNew)
        {
            _userManager = userManager;
            iUserInformation = iUserInformation1;
            this.iOrder = iOrder;
            this.iOrderNew = iOrderNew;
        }
        public async Task<IActionResult> MyHistory(string userId)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            var userd = vmodel.sUser = iUserInformation.GetById(userId);

            var user = await _userManager.FindByIdAsync(userId);
            //var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            string phoneNumber = user.PhoneNumber;
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                vmodel.NewOrders = (await iOrderNew.GetOrdersByPhoneAsync(phoneNumber)).ToList();
                vmodel.OldOrders = (await iOrder.GetOrdersByPhoneAsync(phoneNumber)).ToList();
            }

            return View(vmodel);
        }
        public async Task<IActionResult> MyHistoryAr(string userId)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            var userd = vmodel.sUser = iUserInformation.GetById(userId);

            var user = await _userManager.FindByIdAsync(userId);
            //var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            string phoneNumber = user.PhoneNumber;
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                vmodel.NewOrders = (await iOrderNew.GetOrdersByPhoneAsync(phoneNumber)).ToList();
                vmodel.OldOrders = (await iOrder.GetOrdersByPhoneAsync(phoneNumber)).ToList();
            }

            return View(vmodel);
        }
    }
}
