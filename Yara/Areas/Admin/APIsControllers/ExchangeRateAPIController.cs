using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateAPIController : ControllerBase
    {
        IIExchangeRate iExchangeRate;
        private ApiResponse _response;
        public ExchangeRateAPIController(IIExchangeRate iExchangeRate1)
        {
            iExchangeRate = iExchangeRate1;
            _response = new ApiResponse();
        }


        [HttpPost("GitAllExchangeRates/{start}/{end}")]
        public async Task<IActionResult> GitAllExchangeRates(int start, int end)
        {
            try
            {
                var exchanges = await iExchangeRate.GetAllAsync(start, end);
                if (exchanges == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = exchanges;
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

        [HttpPost("GitExchangeRateById/{id}")]
        public async Task<IActionResult> GitExchangeRateById(int id)
        {
            try
            {
                var exchange = await iExchangeRate.GetByIdAsync(id);
                if (exchange == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = exchange;
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
        public async Task<IActionResult> AddExchangeRate(TBExchangeRate model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iExchangeRate.AddAsync(model);

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
        public async Task<IActionResult> EditExchangeRate(int id, [FromBody] TBExchangeRate model)
        {
            try
            {
                var exchange = await iExchangeRate.GetByIdAsync(id);
                if (exchange == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                exchange = model;
                await iExchangeRate.UpdateAsync(exchange);

                _response.Result = exchange;
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
        public async Task<ActionResult> DeleteExchangeRate(int id)
        {
            try
            {
                var exchange = await iExchangeRate.GetByIdAsync(id);
                if (exchange == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                exchange.CurrentState = false;
                await iExchangeRate.UpdateAsync(exchange);

                _response.Result = exchange;
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
