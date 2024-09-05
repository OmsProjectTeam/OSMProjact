using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketStatusAPIController : ControllerBase
    {
        IISupportTicketStatus iSupportTicketStatus;
        private ApiResponse _response;
        public SupportTicketStatusAPIController(IISupportTicketStatus iSupportTicketStatus1)
        {
            iSupportTicketStatus = iSupportTicketStatus1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllSupportTicketStatus/{start}/{end}")]
        public async Task<IActionResult> GitAllSupportTicketStatus(int start, int end)
        {
            try
            {
                var statuses = await iSupportTicketStatus.GetAllAsync(start, end);
                if (statuses == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = statuses;
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

        [HttpPost("GitSupportTicketStatusById/{id}")]
        public async Task<IActionResult> GitSupportTicketStatusById(int id)
        {
            try
            {
                var status = await iSupportTicketStatus.GetByIdAsync(id);
                if (status == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = status;
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
        public async Task<IActionResult> AddSupportTicketStatus(TBSupportTicketStatus model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iSupportTicketStatus.AddAsync(model);

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
        public async Task<IActionResult> EditSupportTicketStatus(int id, [FromBody] TBSupportTicketStatus model)
        {
            try
            {
                var status = await iSupportTicketStatus.GetByIdAsync(id);
                if (status == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                status = model;
                await iSupportTicketStatus.UpdateAsync(status);

                _response.Result = status;
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
        public async Task<ActionResult> DeleteSupportTicketStatus(int id)
        {
            try
            {
                var status = await iSupportTicketStatus.GetByIdAsync(id);
                if (status == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                status.CurrentState = false;
                await iSupportTicketStatus.UpdateAsync(status);

                _response.Result = status;
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
