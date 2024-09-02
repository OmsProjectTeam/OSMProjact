using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesExchangeRatesAPIController : ControllerBase
    {
        IICurrenciesExchangeRates iCurrenciesExchangeRates;
        private ApiResponse _response;
        public CurrenciesExchangeRatesAPIController(IICurrenciesExchangeRates iCurrenciesExchangeRates1)
        {
            iCurrenciesExchangeRates = iCurrenciesExchangeRates1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllCurrenciesExchangeRates/{start}/{end}")]
        public async Task<IActionResult> GitAllCurrenciesExchangeRates(int start, int end)
        {
            try
            {
                var exchanges = await iCurrenciesExchangeRates.GetAllAsync(start, end);
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

        [HttpPost("GitAllCurrenciesExchangeRatesWithCondition")]
        public async Task<IActionResult> GitAllCurrenciesExchangeRatesWithCondition(Expression<Func<TBCurrenciesExchangeRates, bool>> condition)
        {
            try
            {
                var exchanges = await iCurrenciesExchangeRates.GetAlWithConditionAsync(condition);
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

        [HttpPost("GitCurrenciesExchangeRateById/{id}")]
        public async Task<IActionResult> GitCurrenciesExchangeRateById(int id)
        {
            try
            {
                var exchange = await iCurrenciesExchangeRates.GetByIdAsync(id);
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
        public async Task<IActionResult> AddCurrenciesExchangeRate(TBCurrenciesExchangeRates model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iCurrenciesExchangeRates.AddAsync(model);

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
        public async Task<IActionResult> EditCurrenciesExchangeRate(int id, [FromBody] TBCurrenciesExchangeRates model)
        {
            try
            {
                var exchange = await iCurrenciesExchangeRates.GetByIdAsync(id);
                if (exchange == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                exchange = model;
                await iCurrenciesExchangeRates.UpdateAsync(exchange);

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
        public async Task<ActionResult> DeleteCurrenciesExchangeRate(int id)
        {
            try
            {
                var exchange = await iCurrenciesExchangeRates.GetByIdAsync(id);
                if (exchange == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                exchange.CurrentState = false;
                await iCurrenciesExchangeRates.UpdateAsync(exchange);

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
