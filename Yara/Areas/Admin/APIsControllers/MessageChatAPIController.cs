using Domin.Entity.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageChatAPIController : ControllerBase
    {
        IIMessageChat iMessageChat;
        private ApiResponse _response;
        public MessageChatAPIController(IIMessageChat iMessageChat1)
        {
            _response = new ApiResponse();
            iMessageChat = iMessageChat1;
        }

        [HttpPost("GitMessageById/{id}")]
        public async Task<IActionResult> GitMessageById(int id)
        {
            try
            {
                var msg = await iMessageChat.GetByIdAsync(id);
                if (msg == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = msg;
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

        [HttpPost("GetBySenderId/{sId}")]
        public async Task<IActionResult> GetBySenderId(string sId)
        {
            try
            {
                var msgs = await iMessageChat.GetBySenderIdAsync(sId);
                if (msgs == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = msgs;
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

        [HttpPost("GetByReciverId/{rId}")]
        public async Task<IActionResult> GetByReciverId(string rId)
        {
            try
            {
                var msgs = await iMessageChat.GetByReciverIdAsync(rId);
                if (msgs == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = msgs;
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

        [HttpPost("GetByReciverIdLast/{rId}")]
        public async Task<IActionResult> GetByReciverIdLast(string rId)
        {
            try
            {
                var msgs = await iMessageChat.GetByReciverIdLastAsync(rId);
                if (msgs == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = msgs;
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


        [HttpPost("GetBySenderAndReciverId/{sId}/{rId}")]
        public async Task<IActionResult> GetBySenderAndReciverId(string sId, string rId)
        {
            try
            {
                var msgs = await iMessageChat.GetBySenderIdAndReciverIdAsync(sId, rId);
                if (msgs == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = msgs;
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

        [HttpPost("AddMessage")]
        public async Task<IActionResult> AddMessage(TBMessageChat model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iMessageChat.saveDataAsync(model);

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
        public async Task<IActionResult> EditMessage(int id, [FromBody] TBMessageChat model)
        {
            try
            {
                var msg = await iMessageChat.GetByIdAsync(id);
                if (msg == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                msg = model;
                await iMessageChat.UpdateDataAsync(msg);

                _response.Result = msg;
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
        public async Task<ActionResult> DeleteMessage(int id)
        {
            try
            {
                var msg = await iMessageChat.GetByIdAsync(id);
                if (msg == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                msg.CurrentState = false;
                await iMessageChat.UpdateDataAsync(msg);

                _response.Result = msg;
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
