using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketTypeAPIController : ControllerBase
    {
        IISupportTicketType iSupportTicketType;
        private ApiResponse _response;
        public SupportTicketTypeAPIController(IISupportTicketType iSupportTicketType1)
        {
            iSupportTicketType = iSupportTicketType1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllSupportTicketType/{start}/{end}")]
        public async Task<IActionResult> GitAllSupportTicketType(int start, int end)
        {
            try
            {
                var types = await iSupportTicketType.GetAllAsync(start, end);
                if (types == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = types;
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

        [HttpPost("GitSupportTicketTypeById/{id}")]
        public async Task<IActionResult> GitSupportTicketTypeById(int id)
        {
            try
            {
                var type = await iSupportTicketType.GetByIdAsync(id);
                if (type == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = type;
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
        public async Task<IActionResult> AddSupportTicketType(TBSupportTicketType model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iSupportTicketType.AddAsync(model);

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
        public async Task<IActionResult> EditSupportTicketType(int id, [FromBody] TBSupportTicketType model)
        {
            try
            {
                var type = await iSupportTicketType.GetByIdAsync(id);
                if (type == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                type = model;
                await iSupportTicketType.UpdateAsync(type);

                _response.Result = type;
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
        public async Task<ActionResult> DeleteSupportTicketType(int id)
        {
            try
            {
                var type = await iSupportTicketType.GetByIdAsync(id);
                if (type == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                type.CurrentState = false;
                await iSupportTicketType.UpdateAsync(type);

                _response.Result = type;
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
