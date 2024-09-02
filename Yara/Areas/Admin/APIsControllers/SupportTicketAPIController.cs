using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketAPIController : ControllerBase
    {
        IISupportTicket iSupportTicket;
        private ApiResponse _response;
        public SupportTicketAPIController(IISupportTicket iSupportTicket1)
        {
            iSupportTicket = iSupportTicket1;
            _response = new ApiResponse();
        }




        [HttpPost("GitAllSupportTickets/{start}/{end}")]
        public async Task<IActionResult> GitAllSupportTickets(int start, int end)
        {
            try
            {
                var city = await iSupportTicket.GetAllAsync(start, end);
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


        [HttpPost("GitSupportTicketById/{id}")]
        public async Task<IActionResult> GitSupportTicketById(int id)
        {
            try
            {
                var support = await iSupportTicket.GetByIdAsync(id);
                if (support == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = support;
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
        public async Task<IActionResult> AddSupportTicket(TBSupportTicket model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iSupportTicket.AddAsync(model);

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
        public async Task<IActionResult> EditSupportTicket(int id, [FromBody] TBSupportTicket model)
        {
            try
            {
                var support = await iSupportTicket.GetByIdAsync(id);
                if (support == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                support = model;
                await iSupportTicket.UpdateAsync(support);

                _response.Result = support;
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
        public async Task<ActionResult> DeleteSupportTicket(int id)
        {
            try
            {
                var support = await iSupportTicket.GetByIdAsync(id);
                if (support == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                support.CurrentState = false;
                await iSupportTicket.UpdateAsync(support);

                _response.Result = support;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }

            return Ok(_response);
        }

        [HttpPost("DeletePhoto/{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            try
            {
                var result = await iSupportTicket.DELETPHOTOAsync(id);

                if (result)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.Result = result;
                    return Ok(_response);
                }

                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = result;

                return Ok(_response);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }

            return Ok(_response);
        }

        [HttpPost("DeletePhotoWithError/{name}")]
        public async Task<IActionResult> DeletePhotoWithError(string name)
        {
            try
            {
                var result = await iSupportTicket.DELETPHOTOWethErrorAsync(name);

                if (result)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.Result = result;
                    return Ok(_response);
                }

                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = result;

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
