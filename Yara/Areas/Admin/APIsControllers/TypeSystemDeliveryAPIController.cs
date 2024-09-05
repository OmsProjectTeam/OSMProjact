using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeSystemDeliveryAPIController : ControllerBase
    {
        IITypeSystemDelivery iTypeSystemDelivery;
        private ApiResponse _response;

        public TypeSystemDeliveryAPIController(IITypeSystemDelivery iTypeSystemDelivery1)
        {
            iTypeSystemDelivery = iTypeSystemDelivery1;
            _response = new ApiResponse();
        }


        [HttpPost("GitAllTypeSystemDelivery/{start}/{end}")]
        public async Task<IActionResult> GitAllTypeSystemDelivery(int start, int end)
        {
            try
            {
                var systemDeliveries = await iTypeSystemDelivery.GetAllAsync(start, end);
                if (systemDeliveries == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = systemDeliveries;
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

        [HttpPost("GitTypeSystemDeliveryById/{id}")]
        public async Task<IActionResult> GitTypeSystemDeliveryById(int id)
        {
            try
            {
                var systemDelivery = await iTypeSystemDelivery.GetByIdAsync(id);
                if (systemDelivery == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = systemDelivery;
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
        public async Task<IActionResult> AddTypeSystemDelivery(TBTypeSystemDelivery model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iTypeSystemDelivery.AddAsync(model);

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
        public async Task<IActionResult> EditTypeSystemDelivery(int id, [FromBody] TBTypeSystemDelivery model)
        {
            try
            {
                var systemDelivery = await iTypeSystemDelivery.GetByIdAsync(id);
                if (systemDelivery == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                systemDelivery = model;
                await iTypeSystemDelivery.UpdateAsync(systemDelivery);

                _response.Result = systemDelivery;
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
        public async Task<ActionResult> DeleteTypeSystemDelivery(int id)
        {
            try
            {
                var systemDelivery = await iTypeSystemDelivery.GetByIdAsync(id);
                if (systemDelivery == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                systemDelivery.CurrentState = false;
                await iTypeSystemDelivery.UpdateAsync(systemDelivery);

                _response.Result = systemDelivery;
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
