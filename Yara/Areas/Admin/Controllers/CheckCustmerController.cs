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
            // Search for the phone number in ViewShippingAddresseClint
            var phoneNo = await _context.ViewShippingAddresseClint
                                     .FirstOrDefaultAsync(u => u.PhoneNumber == PhoneNumber);

            if (phoneNo != null)
            {
                return Json(new
                {
                    Success = true,
                    Name = phoneNo.Name,
                    Description = phoneNo.Description
                });
            }
            return Json(null);
        }
    }
}
