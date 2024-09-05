using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        IIUser iUser;
        private ApiResponse _response;
        public UserAPIController(IIUser iUser1)
        {
            iUser = iUser1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllUsers/{start}/{end}")]
        public async Task<IActionResult> GitAllUsers(int start, int end)
        {
            try
            {
                var users = await iUser.GetAllAsync(start, end);
                if (users == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = users;
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

        [HttpPost("GitUserById/{id}")]
        public async Task<IActionResult> GitUserById(int id)
        {
            try
            {
                var user = await iUser.GetByIdAsync(id);
                if (user == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = user;
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
    }
}
