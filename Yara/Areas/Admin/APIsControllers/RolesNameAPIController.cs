using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesNameAPIController : ControllerBase
    {
        IIRolesName iRolesName;
        private ApiResponse _response;
        public RolesNameAPIController(IIRolesName iRolesName1)
        {
            iRolesName = iRolesName1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllRoleNames/{start}/{end}")]
        public async Task<IActionResult> GitAllRoleNames(int start, int end)
        {
            try
            {
                var roles = await iRolesName.GetAllAsync(start, end);
                if (roles == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = roles;
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

        [HttpPost("GitRoleNameById/{id}")]
        public async Task<IActionResult> GitRoleNameById(int id)
        {
            try
            {
                var role = await iRolesName.GetByIdAsync(id);
                if (role == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = role;
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
        public async Task<IActionResult> AddRoleName(RolesName model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iRolesName.AddAsync(model);

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
        public async Task<IActionResult> EditRoleName(int id, [FromBody] RolesName model)
        {
            try
            {
                var role = await iRolesName.GetByIdAsync(id);
                if (role == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                role = model;
                await iRolesName.UpdateAsync(role);

                _response.Result = role;
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
        public async Task<ActionResult> DeleteRoleName(int id)
        {
            try
            {
                var role = await iRolesName.GetByIdAsync(id);
                if (role == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                role.CurrentState = false;
                await iRolesName.UpdateAsync(role);

                _response.Result = role;
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
