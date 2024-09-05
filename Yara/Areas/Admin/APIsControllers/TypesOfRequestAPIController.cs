using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesOfRequestAPIController : ControllerBase
    {
        IITypesOfRequest iTypesOfRequest;
        private ApiResponse _response;
        public TypesOfRequestAPIController(IITypesOfRequest iTypesOfRequest1)
        {
            iTypesOfRequest = iTypesOfRequest1;
            _response = new ApiResponse();
        }


        [HttpPost("GitAllTypesOfRequests/{start}/{end}")]
        public async Task<IActionResult> GitAllTypesOfRequests(int start, int end)
        {
            try
            {
                var requests = await iTypesOfRequest.GetAllAsync(start, end);
                if (requests == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = requests;
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


        [HttpPost("GitTypesOfRequestById/{id}")]
        public async Task<IActionResult> GitTypesOfRequestById(int id)
        {
            try
            {
                var request = await iTypesOfRequest.GetByIdAsync(id);
                if (request == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = request;
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
        public async Task<IActionResult> AddTypesOfRequest(TBTypesOfRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iTypesOfRequest.AddAsync(model);

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
        public async Task<IActionResult> EditTypesOfRequest(int id, [FromBody] TBTypesOfRequest model)
        {
            try
            {
                var request = await iTypesOfRequest.GetByIdAsync(id);
                if (request == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                request = model;
                await iTypesOfRequest.UpdateAsync(request);

                _response.Result = request;
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
        public async Task<ActionResult> DeleteTypesOfRequest(int id)
        {
            try
            {
                var request = await iTypesOfRequest.GetByIdAsync(id);
                if (request == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                request.CurrentState = false;
                await iTypesOfRequest.UpdateAsync(request);

                _response.Result = request;
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
