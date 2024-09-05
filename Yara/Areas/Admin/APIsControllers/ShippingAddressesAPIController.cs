using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingAddressesAPIController : ControllerBase
    {
        IIShippingAddress iShippingAddress;
        private ApiResponse _response;
        public ShippingAddressesAPIController(IIShippingAddress iShippingAddress1)
        {
            iShippingAddress = iShippingAddress1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllShippingAddresses/{start}/{end}")]
        public async Task<IActionResult> GitAllShippingAddresses(int start, int end)
        {
            try
            {
                var shippingAddresses = await iShippingAddress.GetAllAsync(start, end);
                if (shippingAddresses == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = shippingAddresses;
                _response.StatusCode = HttpStatusCode.Created;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return Ok(_response);
        }

        [HttpPost("GitAllShippingAddressWithCondition")]
        public async Task<IActionResult> GitAllShippingAddressWithCondition(Expression<Func<TBViewShippingAddress, bool>> condition)
        {
            try
            {
                var shippingAddresses = await iShippingAddress.GetAlWithConditionAsync(condition);
                if (shippingAddresses == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = shippingAddresses;
                _response.StatusCode = HttpStatusCode.Created;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return Ok(_response);
        }

        [HttpPost("GitAllShippingAddressForDataEntry/{user}")]
        public async Task<IActionResult> GitAllShippingAddressForDataEntry(string user)
        {
            try
            {
                var shippingAddresses = await iShippingAddress.GetAllDataentryAsync(user);
                if (shippingAddresses == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = shippingAddresses;
                _response.StatusCode = HttpStatusCode.Created;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }
            return Ok(_response);
        }


        [HttpPost("GitShippingAddressById/{id}")]
        public async Task<IActionResult> GitShippingAddressById(int id)
        {
            try
            {
                var shippingAddress = await iShippingAddress.GetByIdAsync(id);
                if (shippingAddress == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = shippingAddress;
                _response.StatusCode = HttpStatusCode.Created;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }

            return Ok(_response);
        }

        [HttpPost]
        public async Task<IActionResult> AddShippingAddress(TBShippingAddress model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iShippingAddress.saveDataAsync(model);

                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }

            return Ok(_response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditShippingAddress(int id, [FromBody] TBShippingAddress model)
        {
            try
            {
                var shippingAddress = await iShippingAddress.GetByIdAsync(id);
                if (shippingAddress == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                shippingAddress = model;
                await iShippingAddress.UpdateDataAsync(shippingAddress);

                _response.Result = shippingAddress;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }

            return Ok(_response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShippingAddress(int id)
        {
            try
            {
                var shippingAddress = await iShippingAddress.GetByIdAsync(id);
                if (shippingAddress == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                shippingAddress.CurrentState = false;
                await iShippingAddress.UpdateDataAsync(shippingAddress);

                _response.Result = shippingAddress;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }

            return Ok(_response);
        }
    }
}
