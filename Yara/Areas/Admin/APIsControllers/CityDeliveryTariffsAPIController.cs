using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityDeliveryTariffsAPIController : ControllerBase
    {
        IICityDeliveryTariffs iCityDeliveryTariffs;
        private ApiResponse _response;
        public CityDeliveryTariffsAPIController(IICityDeliveryTariffs iCityDeliveryTariffs1)
        {
            iCityDeliveryTariffs = iCityDeliveryTariffs1;
            _response = new ApiResponse();
        }


        [HttpPost("GitAllCitiesDeliveryTariffs/{start}/{end}")]
        public async Task<IActionResult> GitAllCitiesDeliveryTariffs(int start, int end)
        {
            try
            {
                var city = await iCityDeliveryTariffs.GetAllAsync(start, end);
                if (city == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = city;
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


        [HttpPost("GitCityDeliveryTariffById/{id}")]
        public async Task<IActionResult> GitCityDeliveryTariffById(int id)
        {
            try
            {
                var city = await iCityDeliveryTariffs.GetByIdAsync(id);
                if (city == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = city;
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
        public async Task<IActionResult> AddCityDeliveryTariff(TBCityDeliveryTariffs model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iCityDeliveryTariffs.AddAsync(model);

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
        public async Task<IActionResult> EditCityDeliveryTariff(int id, [FromBody] TBCityDeliveryTariffs model)
        {
            try
            {
                var city = await iCityDeliveryTariffs.GetByIdAsync(id);
                if (city == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                city = model;
                await iCityDeliveryTariffs.UpdateAsync(city);

                _response.Result = city;
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
        public async Task<ActionResult> DeleteCityDeliveryTariff(int id)
        {
            try
            {
                var city = await iCityDeliveryTariffs.GetByIdAsync(id);
                if (city == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                city.CurrentState = false;
                await iCityDeliveryTariffs.UpdateAsync(city);

                _response.Result = city;
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
