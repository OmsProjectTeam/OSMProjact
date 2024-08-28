    using Microsoft.EntityFrameworkCore;

    namespace Yara.Areas.Admin.Controllers
    {
        [Area("Admin")]
        [Authorize(Roles = "Admin")]
        public class CheckCustmerController : Controller
        {
            MasterDbcontext _context;

            IIUserInformation iUserInformation;
            IICity iCity;
            IIArea iArea;
            IIShippingPrice iShippingPrice;
            IICurrenciesExchangeRates iCurrenciesExchangeRates;
            IITypeSystemDelivery iTypeSystemDelivery;
            IICityDeliveryTariffs iCityDeliveryTariffs;
            IIShippingAddresseClint iShippingAddresseClint;
            public CheckCustmerController(MasterDbcontext dbcontext1, IIUserInformation iUserInformation1, IICity iCity1, IIArea iArea1, IIShippingPrice iShippingPrice1, IICurrenciesExchangeRates iCurrenciesExchangeRates1, IITypeSystemDelivery iTypeSystemDelivery1, IICityDeliveryTariffs iCityDeliveryTariffs1, IIShippingAddresseClint iShippingAddresseClint1)
            {
                _context= dbcontext1;
                iUserInformation = iUserInformation1;
                iCity = iCity1;
                iArea = iArea1;
                iShippingPrice = iShippingPrice1;
                iCurrenciesExchangeRates = iCurrenciesExchangeRates1;
                iTypeSystemDelivery = iTypeSystemDelivery1;
                iCityDeliveryTariffs = iCityDeliveryTariffs1;
                iShippingAddresseClint = iShippingAddresseClint1;
            }
            public IActionResult MyCheckCustmer()
            {
                ViewBag.City = iCity.GetAll();
                ViewBag.Area = iArea.GetAll();
                ViewBag.ShippingPrice = iShippingPrice.GetAll();
                ViewBag.Currenc = iCurrenciesExchangeRates.GetAll();
                ViewBag.TypeSystemDelivery = iTypeSystemDelivery.GetAll();
                ViewBag.CityDeliveryTariffs = iCityDeliveryTariffs.GetAll();
                ViewBag.user = iUserInformation.GetAllByNameall();

                return View();
            }
        //[HttpPost]
        //public async Task<IActionResult> GitPhouneNumber(string PhoneNumber)
        //{
        //    // Search for the phone number in ViewShippingAddresseClint
        //    var phoneNo = await _context.ViewShippingAddresseClint
        //                             .FirstOrDefaultAsync(u => u.PhoneNumber == PhoneNumber);

        //    if (phoneNo != null)
        //    {
        //        // Store the data in TempData for later use
        //        TempData["ClientName"] = phoneNo.Name;
        //        TempData["ClientDescription"] = phoneNo.Description;

        //        return Json(new
        //        {
        //            Success = true,
        //            Name = phoneNo.Name,
        //            Description = phoneNo.Description
        //        });
        //    }
        //    return Json(null);
        //}

        [HttpPost]
        public async Task<IActionResult> GitPhouneNumber(string PhoneNumber)
        {
            // Search for the phone number in ViewShippingAddresseClint
            var phoneNo = await _context.ViewShippingAddresseClint
                                         .FirstOrDefaultAsync(u => u.PhoneNumber == PhoneNumber);

            if (phoneNo != null)
            {
                // Store the data in TempData for later use
                TempData["ClientName"] = phoneNo.Name;
                ViewBag.name= phoneNo.Name;
                TempData["ClientDescription"] = phoneNo.Description;
                TempData["ClientDescription"] = phoneNo.Description;
                TempData["ClientDescription"] = phoneNo.Description;
                TempData["ClientDescription"] = phoneNo.Description;
                TempData["ClientDescription"] = phoneNo.Description;
                TempData["ClientDescription"] = phoneNo.Description;
                TempData["ClientDescription"] = phoneNo.Description;
                TempData["ClientDescription"] = phoneNo.Description;
                TempData["ClientDescription"] = phoneNo.Description;
                TempData["ClientDescription"] = phoneNo.Description;
                TempData["ClientDescription"] = phoneNo.Description;
                TempData["ClientDescription"] = phoneNo.Description;
                TempData["ClientDescription"] = phoneNo.Description;
                TempData["ClientDescription"] = phoneNo.Description;

                return Json(new
                {
                    Success = true,
                    Name = phoneNo.Name,
                    Description = phoneNo.Description
                });
            }
            else
            {
                // func check data custmer 
                // register py phne nmber in bac ground 
                //then open nwe address  model 
            }
            return Json(null);
        }

    }
}
