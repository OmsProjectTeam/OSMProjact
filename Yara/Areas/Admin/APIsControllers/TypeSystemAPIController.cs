using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeSystemAPIController : ControllerBase
    {
        IITypeSystem iTypeSystem;
        private ApiResponse _response;
        public TypeSystemAPIController(IITypeSystem iTypeSystem1)
        {
            iTypeSystem = iTypeSystem1;
            _response = new ApiResponse();
        }


        [HttpPost("GitAllTypeSystem/{start}/{end}")]
        public async Task<IActionResult> GitAllTypeSystem(int start, int end)
        {
            try
            {
                var systems = await iTypeSystem.GetAllAsync(start, end);
                if (systems == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = systems;
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


        [HttpPost("GitTypeSystemById/{id}")]
        public async Task<IActionResult> GitTypeSystemById(int id)
        {
            try
            {
                var system = await iTypeSystem.GetByIdAsync(id);
                if (system == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = system;
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
        public async Task<IActionResult> AddTypeSystem(TBTypeSystem model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iTypeSystem.AddAsync(model);

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
        public async Task<IActionResult> EditTypeSystem(int id, [FromBody] TBTypeSystem model)
        {
            try
            {
                var system = await iTypeSystem.GetByIdAsync(id);
                if (system == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                system = model;
                await iTypeSystem.UpdateAsync(system);

                _response.Result = system;
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
        public async Task<ActionResult> DeleteTypeSystem(int id)
        {
            try
            {
                var system = await iTypeSystem.GetByIdAsync(id);
                if (system == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                system.CurrentState = false;
                await iTypeSystem.UpdateAsync(system);

                _response.Result = system;
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
