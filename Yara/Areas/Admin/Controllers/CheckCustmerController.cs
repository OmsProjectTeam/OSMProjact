using Microsoft.EntityFrameworkCore;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CheckCustmerController : Controller
    {
        MasterDbcontext _context;
        public CheckCustmerController(MasterDbcontext dbcontext1)
        {
            _context= dbcontext1;
        }
        public IActionResult MyCheckCustmer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GitPhouneNumber(string PhoneNumber)
        {
            // البحث عن رقم الهاتف في جدول VwUsers
            var user = await _context.VwUsers.FirstOrDefaultAsync(u => u.PhoneNumber == PhoneNumber);

            if (user != null)
            {
                TempData["FAQ"] = "العميل متوفر سيتم توجيهك لصفحة تثبيت العنوان ";
                return RedirectToAction("MyCheckCustmer" );
            }

            // البحث عن رقم الهاتف في جدول customers
            var customer = await _context.customers.FirstOrDefaultAsync(c => c.CustMob == PhoneNumber || c.CustMob2 == PhoneNumber);

            if (customer != null)
            {
                // إذا تم العثور على العميل، عرض صفحة التفاصيل
                return View("CustomerDetailsView", customer);
            }

            // إذا لم يتم العثور على الرقم في أي من الجداول، عرض نموذج التسجيل
            return View("RegisterView");
        }
    }
}
