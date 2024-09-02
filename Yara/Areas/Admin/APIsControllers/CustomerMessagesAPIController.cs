using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerMessagesAPIController : ControllerBase
    {
        IICustomerMessages iCustomerMessages;
        private ApiResponse _response;
        public CustomerMessagesAPIController(IICustomerMessages iCustomerMessages1)
        {
            iCustomerMessages = iCustomerMessages1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllCustomerMessages/{start}/{end}")]
        public async Task<IActionResult> GitAllCustomerMessages(int start, int end)
        {
            try
            {
                var customerMessages = await iCustomerMessages.GetAllAsync(start, end);
                if (customerMessages == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = customerMessages;
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

        [HttpPost("GitAllCustomerMessageForOneEntry")]
        public async Task<IActionResult> GitAllCustomerMessageForOneEntry(string user)
        {
            try
            {
                var customerMessages = await iCustomerMessages.GetAllDataentryAsync(user);
                if (customerMessages == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = customerMessages;
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

        [HttpPost("GitCityById/{id}")]
        public async Task<IActionResult> GitCustomerMessageById(int id)
        {
            try
            {
                var customerMessage = await iCustomerMessages.GetByIdAsync(id);
                if (customerMessage == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = customerMessage;
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
        public async Task<IActionResult> AddCustomerMessage(TBCustomerMessages model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iCustomerMessages.AddAsync(model);

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
        public async Task<IActionResult> EditCustomerMessage(int id, [FromBody] TBCustomerMessages model)
        {
            try
            {
                var customerMessage = await iCustomerMessages.GetByIdAsync(id);
                if (customerMessage == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                customerMessage = model;
                await iCustomerMessages.UpdateAsync(customerMessage);

                _response.Result = customerMessage;
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
        public async Task<ActionResult> DeleteCustomerMessage(int id)
        {
            try
            {
                var customerMessage = await iCustomerMessages.GetByIdAsync(id);
                if (customerMessage == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                customerMessage.CurrentState = false;
                await iCustomerMessages.UpdateAsync(customerMessage);

                _response.Result = customerMessage;
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
