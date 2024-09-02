using Infarstuructre.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInformationAPIController : ControllerBase
    {
        IIUserInformation iUserInformation;
        private ApiResponse _response;
        public UserInformationAPIController(IIUserInformation iUserInformation1)
        {
            iUserInformation = iUserInformation1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllUserInformation/{start}/{end}")]
        public async Task<IActionResult> GitAllUserInformation(int start, int end)
        {
            try
            {
                var users = await iUserInformation.GetAllAsync(start, end);
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

        [HttpPost("GitUserInformationById/{id}")]
        public async Task<IActionResult> GitUserInformationById(string id)
        {
            try
            {
                var user = await iUserInformation.GetByIdAsync(id);
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

        [HttpPost("GitAllUserInformationByName/{name}")]
        public async Task<IActionResult> GitAllUserInformationByName(string name)
        {
            try
            {
                var users = await iUserInformation.GetAllByNameAsync(name);
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

        [HttpPost("GitAllUserInformationById/{id}")]
        public async Task<IActionResult> GitAllUserInformationById(string id)
        {
            try
            {
                var users = await iUserInformation.GetAllbyIdAsync(id);
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

        [HttpPost("GitUserInformationByName/{name}")]
        public async Task<IActionResult> GitUserInformationByName(string name)
        {
            try
            {
                var user = await iUserInformation.GetByNameAsync(name);
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

        [HttpPost("GitUserInformationByRole")]
        public async Task<IActionResult> GitUserInformationByRole()
        {
            try
            {
                var users = await iUserInformation.GetAllbyRoleAsync();
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

        [HttpPost("GitUserInformationSupportActive")]
        public async Task<IActionResult> GitUserInformationSupportActive()
        {
            try
            {
                var users = await iUserInformation.GetActiveSupportAsync();
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
    }
}
