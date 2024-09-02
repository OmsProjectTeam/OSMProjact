using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesOfMessageAPIController : ControllerBase
    {
        IITypesOfMessage iTypesOfMessage;
        private ApiResponse _response;
        public TypesOfMessageAPIController(IITypesOfMessage iTypesOfMessage1)
        {
            iTypesOfMessage = iTypesOfMessage1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllTypesOfMessage/{start}/{end}")]
        public async Task<IActionResult> GitAllTypesOfMessage(int start, int end)
        {
            try
            {
                var TypesOfMessage = await iTypesOfMessage.GetAllAsync(start, end);
                if (TypesOfMessage == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = TypesOfMessage;
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


        [HttpPost("GitTypesOfMessageById/{id}")]
        public async Task<IActionResult> GitTypesOfMessageById(int id)
        {
            try
            {
                var TypesOfMessage = await iTypesOfMessage.GetByIdAsync(id);
                if (TypesOfMessage == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = TypesOfMessage;
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
        public async Task<IActionResult> AddTypesOfMessage(TBTypesOfMessage model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iTypesOfMessage.AddAsync(model);

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
        public async Task<IActionResult> EditTypesOfMessage(int id, [FromBody] TBTypesOfMessage model)
        {
            try
            {
                var TypesOfMessage = await iTypesOfMessage.GetByIdAsync(id);
                if (TypesOfMessage == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                TypesOfMessage = model;
                await iTypesOfMessage.UpdateAsync(TypesOfMessage);

                _response.Result = TypesOfMessage;
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
        public async Task<ActionResult> DeleteTypesOfMessage(int id)
        {
            try
            {
                var TypesOfMessage = await iTypesOfMessage.GetByIdAsync(id);
                if (TypesOfMessage == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                TypesOfMessage.CurrentState = false;
                await iTypesOfMessage.UpdateAsync(TypesOfMessage);

                _response.Result = TypesOfMessage;
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
