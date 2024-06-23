
namespace Yara.Areas.merchantAccount.Controllers
{
	[Area("merchantAccount")]
	[Authorize(Roles = "Admin,Merchant")]
	public class ProfileController : Controller
	{
		IIMerchant iMerchant;
        public ProfileController(IIMerchant iMerchant1)
		{
            iMerchant = iMerchant1;

        }
		public IActionResult MyProfile(int id)
		{
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            vmodel.ListViewMerchant = iMerchant.GetAllv(id);
            return View();
		}
	}
}
