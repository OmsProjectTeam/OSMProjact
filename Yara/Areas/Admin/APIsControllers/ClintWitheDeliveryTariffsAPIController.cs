using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClintWitheDeliveryTariffsAPIController : ControllerBase
    {
        IIClintWitheDeliveryTariffs iClintWitheDeliveryTariffs;
        private ApiResponse _response;
        public ClintWitheDeliveryTariffsAPIController(IIClintWitheDeliveryTariffs iClintWitheDeliveryTariffs1)
        {
            iClintWitheDeliveryTariffs = iClintWitheDeliveryTariffs1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllClintWitheDeliveryTariffs/{start}/{end}")]
        public async Task<IActionResult> GitAllClintWitheDeliveryTariffs(int start, int end)
        {
            try
            {
                var clintWitheDeliveryTariff = await iClintWitheDeliveryTariffs.GetAllAsync(start, end);
                if (clintWitheDeliveryTariff == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = clintWitheDeliveryTariff;
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

        [HttpPost("GitAllClintWitheDeliveryTariffsWithCondition")]
        public async Task<IActionResult> GitAllClintWitheDeliveryTariffsWithCondition(Expression<Func<TBViewClintWitheDeliveryTariffs, bool>> condition)
        {
            try
            {
                var clintWitheDeliveryTariff = await iClintWitheDeliveryTariffs.GetAlWithConditionAsync(condition);
                if (clintWitheDeliveryTariff == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = clintWitheDeliveryTariff;
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

        [HttpPost("GitClintWitheDeliveryTariffById/{id}")]
        public async Task<IActionResult> GitClintWitheDeliveryTariffById(int id)
        {
            try
            {
                var clintWitheDeliveryTariff = await iClintWitheDeliveryTariffs.GetByIdAsync(id);
                if (clintWitheDeliveryTariff == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = clintWitheDeliveryTariff;
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
        public async Task<IActionResult> AddClintWitheDeliveryTariff(TBClintWitheDeliveryTariffs model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iClintWitheDeliveryTariffs.AddAsync(model);

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
        public async Task<IActionResult> EditClintWitheDeliveryTariff(int id, [FromBody] TBClintWitheDeliveryTariffs model)
        {
            try
            {
                var clintWitheDeliveryTariff = await iClintWitheDeliveryTariffs.GetByIdAsync(id);
                if (clintWitheDeliveryTariff == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                clintWitheDeliveryTariff = model;
                await iClintWitheDeliveryTariffs.UpdateAsync(clintWitheDeliveryTariff);

                _response.Result = clintWitheDeliveryTariff;
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
        public async Task<ActionResult> DeleteClintWitheDeliveryTariff(int id)
        {
            try
            {
                var clintWitheDeliveryTariff = await iClintWitheDeliveryTariffs.GetByIdAsync(id);
                if (clintWitheDeliveryTariff == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                clintWitheDeliveryTariff.CurrentState = false;
                await iClintWitheDeliveryTariffs.UpdateAsync(clintWitheDeliveryTariff);

                _response.Result = clintWitheDeliveryTariff;
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
