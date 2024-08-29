using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Yara.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CheckCustmerController : Controller
    {
        MasterDbcontext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        IIUserInformation iUserInformation;
        IICity iCity;
        IIArea iArea;
        IIShippingPrice iShippingPrice;
        IICurrenciesExchangeRates iCurrenciesExchangeRates;
        IITypeSystemDelivery iTypeSystemDelivery;
        IICityDeliveryTariffs iCityDeliveryTariffs;
        IIShippingAddresseClint iShippingAddresseClint;
        public CheckCustmerController(MasterDbcontext dbcontext1, IIUserInformation iUserInformation1, IICity iCity1, IIArea iArea1, IIShippingPrice iShippingPrice1, IICurrenciesExchangeRates iCurrenciesExchangeRates1, IITypeSystemDelivery iTypeSystemDelivery1, IICityDeliveryTariffs iCityDeliveryTariffs1, IIShippingAddresseClint iShippingAddresseClint1, UserManager<ApplicationUser> userManager)
        {
            _context = dbcontext1;
            iUserInformation = iUserInformation1;
            iCity = iCity1;
            iArea = iArea1;
            iShippingPrice = iShippingPrice1;
            iCurrenciesExchangeRates = iCurrenciesExchangeRates1;
            iTypeSystemDelivery = iTypeSystemDelivery1;
            iCityDeliveryTariffs = iCityDeliveryTariffs1;
            iShippingAddresseClint = iShippingAddresseClint1;
            _userManager = userManager;
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

        //[HttpPost]
        //public async Task<IActionResult> GitPhouneNumber(string PhoneNumber)
        //{
        //    // Search for the phone number in ViewShippingAddresseClint
        //    var phoneNo = await _context.ViewShippingAddresseClint
        //                                 .FirstOrDefaultAsync(u => u.PhoneNumber == PhoneNumber);

        //    if (phoneNo != null)
        //    {
        //        // Store the data in TempData for later use


        //        return Json(new
        //        {
        //            Success = true,
        //            Name = phoneNo.Name,
        //            Description = phoneNo.Description,
        //            City = phoneNo.CityName,
        //            Area = phoneNo.AreaName,
        //            Address = phoneNo.AreaName,
        //            NikeName = phoneNo.NikeNAme,
        //        });
        //    }
        //    // Step 2: If not found, search the AspNetUsers table
        //    var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == PhoneNumber);

        //    if (user != null)
        //    {
        //        return Json(new
        //        {
        //            Success = true,
        //            Name = user.Name,
        //            Email = user.Email,
        //            UserName = user.UserName,
        //            PhoneNumber = user.PhoneNumber
        //        });
        //    }

        //    // Step 3: If not found in both tables, create a new user
        //    string email = $"{PhoneNumber}@{PhoneNumber}";
        //    string username = PhoneNumber;
        //    string fullName = PhoneNumber;
        //    string password = PhoneNumber.Length >= 5 ? PhoneNumber.Substring(PhoneNumber.Length - 5) : PhoneNumber;

        //    var newUser = new ApplicationUser
        //    {
        //        UserName = username,
        //        Email = email,
        //        Name = fullName,
        //        PhoneNumber = PhoneNumber,
        //        ImageUser = "default-image-path.jpg"
        //    };
        //    try
        //    {
        //        var result = await _userManager.CreateAsync(newUser, password);
        //        if (result.Succeeded)
        //        {
        //            // Return success with new user info
        //            return Json(new
        //            {
        //                Success = true,
        //                Name = newUser.Name,
        //                Email = newUser.Email,
        //                UserName = newUser.UserName,
        //                PhoneNumber = newUser.PhoneNumber,
        //                Message = "New customer registered successfully!"
        //            });
        //        }
        //        else
        //        {
        //            // Capture and return specific errors
        //            string errorMessage = string.Join("; ", result.Errors.Select(e => e.Description));
        //            return Json(new
        //            {
        //                Success = false,
        //                Message = $"User creation failed: {errorMessage}"
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle any unexpected errors
        //        return Json(new
        //        {
        //            Success = false,
        //            Message = $"An error occurred while registering the new user: {ex.Message}"
        //        });
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> GitPhouneNumber(string PhoneNumber)
        {
            // Search for the phone number in ViewShippingAddresseClint
            var phoneNo = await _context.ViewShippingAddresseClint
                                         .FirstOrDefaultAsync(u => u.PhoneNumber == PhoneNumber);

            if (phoneNo != null)
            {
                // Return the existing data from ViewShippingAddresseClint
                return Json(new
                {
                    Success = true,
                    Name = phoneNo.Name,
                    Description = phoneNo.Description,
                    City = phoneNo.CityName,
                    Area = phoneNo.AreaName,
                    LandMark = phoneNo.NearestLandmark,
                    //Address = phoneNo.AreaName,
                    NikeName = phoneNo.NikeNAme,
                    CustPriceOver10 = phoneNo.ClintPricePerkgUnder10,
                    CustPriceUnder10 = phoneNo.ClintPricePerkgAbove10,
                    System = phoneNo.IdTypeSystemDelivery,
                    Currency = phoneNo.CurrencyName,
                    CityDeliveryTariff = phoneNo.IdCityDeliveryTariffs,
                    DealingStatus = phoneNo.CurrentState,

                });
            }

            // Search the AspNetUsers table for the phone number
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == PhoneNumber);

            if (user != null)
            {
                // Check if other data is already available
                bool isDataComplete = !string.IsNullOrEmpty(user.Email) &&
                                      !string.IsNullOrEmpty(user.UserName) &&
                                      !string.IsNullOrEmpty(user.Name);

                if (isDataComplete)
                {
                    // Data is complete, return the existing user data
                    return Json(new
                    {
                        Success = true,
                        Name = user.Name,
                        Email = user.Email,
                        UserName = user.UserName,
                        PhoneNumber = user.PhoneNumber,
                        Message = "Existing user data retrieved."
                    });
                }
                else
                {
                    // Data is not complete, update the user with missing data
                    user.Email = user.Email ?? $"{PhoneNumber}@{PhoneNumber}";
                    user.UserName = user.UserName ?? PhoneNumber;
                    user.Name = user.Name ?? PhoneNumber;
                    user.ImageUser = user.ImageUser ?? "default-image-path.jpg";

                    var updateResult = await _userManager.UpdateAsync(user);
                    if (updateResult.Succeeded)
                    {
                        // Return the updated user data
                        return Json(new
                        {
                            Success = true,
                            Name = user.Name,
                            Email = user.Email,
                            UserName = user.UserName,
                            PhoneNumber = user.PhoneNumber,
                            Message = "Existing user data updated and retrieved."
                        });
                    }
                    else
                    {
                        // Return error if updating the user failed
                        string updateErrorMessage = string.Join("; ", updateResult.Errors.Select(e => e.Description));
                        return Json(new
                        {
                            Success = false,
                            Message = $"Failed to update existing user: {updateErrorMessage}"
                        });
                    }
                }
            }

            // If the phone number was not found in both tables, create a new user
            string email = $"{PhoneNumber}@{PhoneNumber}";
            string username = PhoneNumber;
            string fullName = PhoneNumber;
            string password = PhoneNumber.Length >= 5 ? PhoneNumber.Substring(PhoneNumber.Length - 5) : PhoneNumber;

            var newUser = new ApplicationUser
            {
                UserName = username,
                Email = email,
                Name = fullName,
                PhoneNumber = PhoneNumber,
                ImageUser = "default-image-path.jpg"
            };

            try
            {
                var createResult = await _userManager.CreateAsync(newUser, password);
                if (createResult.Succeeded)
                {
                    // Assign the default role (e.g., Customer) to the new user
                    await _userManager.AddToRoleAsync(newUser, "Customer");

                    // Return success with new user info
                    return Json(new
                    {
                        Success = true,
                        Name = newUser.Name,
                        Email = newUser.Email,
                        UserName = newUser.UserName,
                        PhoneNumber = newUser.PhoneNumber,
                        Message = "New customer registered successfully!"
                    });
                }
                else
                {
                    // Capture and return specific errors during user creation
                    string createErrorMessage = string.Join("; ", createResult.Errors.Select(e => e.Description));
                    return Json(new
                    {
                        Success = false,
                        Message = $"User creation failed: {createErrorMessage}"
                    });
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors during the process
                return Json(new
                {
                    Success = false,
                    Message = $"An error occurred while registering the new user: {ex.Message}"
                });
            }
        }
    }
}
