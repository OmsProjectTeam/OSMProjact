using Domin.Entity.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectAndDisconnectAPIController : ControllerBase
    {
        private ApiResponse _response;
        IIConnectAndDisconnect iConnectAndDisconnect;
        public ConnectAndDisconnectAPIController(IIConnectAndDisconnect iConnectAndDisconnect1)
        {
            iConnectAndDisconnect = iConnectAndDisconnect1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllConnecting/{start}/{end}")]
        public async Task<IActionResult> GitAllConnecting(int start, int end)
        {
            try
            {
                var connected = await iConnectAndDisconnect.GetAllAsync(start, end);
                if (connected == null)
                    _response.StatusCode = HttpStatusCode.NotFound;

                _response.Result = connected;
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

        [HttpPost("GitConnectingById/{id}")]
        public async Task<IActionResult> GitConnectingById(string id)
        {
            try
            {
                var conn = await iConnectAndDisconnect.GetByIdAsync(id);
                if (conn == null)
                    _response.StatusCode = HttpStatusCode.NotFound;
                _response.Result = conn;
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

        [HttpPost("GitConnectingByName/{id}")]
        public async Task<IActionResult> GitConnectingByName(string name)
        {
            try
            {
                var conn = await iConnectAndDisconnect.GetByNameAsync(name);
                if (conn == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = conn;
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
        public async Task<IActionResult> AddConnection(TBConnectAndDisConnect model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iConnectAndDisconnect.AddAsync(model);

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveConnection(string id)
        {
            try
            {
                var conn = await iConnectAndDisconnect.GetByIdAsync(id);
                if (conn == null)
                    _response.StatusCode = HttpStatusCode.NotFound;


                await iConnectAndDisconnect.DeleteAsync(id);
                _response.Result = "Connection disAbled";
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
