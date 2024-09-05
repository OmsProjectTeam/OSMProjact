using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingPriceAPIController : ControllerBase
    {
        IIShippingPrice iShippingPrice;
        private ApiResponse _response;
        public ShippingPriceAPIController(IIShippingPrice iShippingPrice1)
        {
            iShippingPrice = iShippingPrice1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllShippingPrice/{start}/{end}")]
        public async Task<IActionResult> GitAllShippingPrice(int start, int end)
        {
            try
            {
                var prices = await iShippingPrice.GetAllAsync(start, end);
                if (prices == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = prices;
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

        [HttpPost("GitShippingPriceById/{id}")]
        public async Task<IActionResult> GitShippingPriceById(int id)
        {
            try
            {
                var price = await iShippingPrice.GetByIdAsync(id);
                if (price == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = price;
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
        public async Task<IActionResult> AddShippingPrice(TBShippingPrice model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iShippingPrice.AddAsync(model);

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
        public async Task<IActionResult> EditShippingPrice(int id, [FromBody] TBShippingPrice model)
        {
            try
            {
                var price = await iShippingPrice.GetByIdAsync(id);
                if (price == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                price = model;
                await iShippingPrice.UpdateAsync(price);

                _response.Result = price;
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
        public async Task<ActionResult> DeleteShippingPrice(int id)
        {
            try
            {
                var price = await iShippingPrice.GetByIdAsync(id);
                if (price == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                price.CurrentState = false;
                await iShippingPrice.UpdateAsync(price);

                _response.Result = price;
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
