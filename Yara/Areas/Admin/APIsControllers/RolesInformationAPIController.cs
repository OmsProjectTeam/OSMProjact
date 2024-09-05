using Infarstuructre.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesInformationAPIController : ControllerBase
    {
        public RolesInformationAPIController(IIRolsInformation iRolsInformation1)
        {
            iRolsInformation = iRolsInformation1;
            _response = new ApiResponse();
        }
        IIRolsInformation iRolsInformation;
        private ApiResponse _response;


        [HttpPost("GitAllRolesInformation")]
        public async Task<IActionResult> GitAllRolesInformation()
        {
            try
            {
                var rolesInfo = await iRolsInformation.GetAllAsync();
                if (rolesInfo == null)
                    _response.StatusCode = HttpStatusCode.NotFound;

                _response.Result = rolesInfo;
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

        [HttpPost("GitRolesInformationById/{id}")]
        public async Task<IActionResult> GitRolesInformationById(string id)
        {
            try
            {
                var roleInfo = await iRolsInformation.GetByIdAsync(id);
                if (roleInfo == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = roleInfo;
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
