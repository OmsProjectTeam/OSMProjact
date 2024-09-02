using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailAlartSettingAPIController : ControllerBase
    {
        IIEmailAlartSetting iEmailAlartSetting;
        private ApiResponse _response;
        public EmailAlartSettingAPIController(IIEmailAlartSetting iEmailAlartSetting1)
        {
            iEmailAlartSetting = iEmailAlartSetting1;
            _response = new ApiResponse();
        }


        [HttpPost("GitAllEmailAlerts/{start}/{end}")]
        public async Task<IActionResult> GitAllEmailAlerts(int start, int end)
        {
            try
            {
                var emails = await iEmailAlartSetting.GetAllAsync(start, end);
                if (emails == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = emails;
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

        [HttpPost("GitEmailAlertById/{id}")]
        public async Task<IActionResult> GitEmailAlertById(int id)
        {
            try
            {
                var email = await iEmailAlartSetting.GetByIdAsync(id);
                if (email == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = email;
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
        public async Task<IActionResult> AddEmailAlert(TBEmailAlartSetting model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iEmailAlartSetting.AddAsync(model);

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
        public async Task<IActionResult> EditEmailAlert(int id, [FromBody] TBEmailAlartSetting model)
        {
            try
            {
                var email = await iEmailAlartSetting.GetByIdAsync(id);
                if (email == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                email = model;
                await iEmailAlartSetting.UpdateAsync(email);

                _response.Result = email;
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
        public async Task<ActionResult> DeleteEmailAlert(int id)
        {
            try
            {
                var email = await iEmailAlartSetting.GetByIdAsync(id);
                if (email == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                email.CurrentState = false;
                await iEmailAlartSetting.UpdateAsync(email);

                _response.Result = email;
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
