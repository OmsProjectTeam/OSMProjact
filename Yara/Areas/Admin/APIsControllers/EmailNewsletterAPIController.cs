using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailNewsletterAPIController : ControllerBase
    {
        IIEmailNewsletter iEmailNewsletter;
        private ApiResponse _response;
        public EmailNewsletterAPIController(IIEmailNewsletter iEmailNewsletter1)
        {
            iEmailNewsletter = iEmailNewsletter1;
            _response = new ApiResponse();
        }


        [HttpPost("GitAllCities/{start}/{end}")]
        public async Task<IActionResult> GitAllEmailNewsletter(int start, int end)
        {
            try
            {
                var emails = await iEmailNewsletter.GetAllAsync(start, end);
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

        [HttpPost("GitAllSubscriped/{id}")]
        public async Task<IActionResult> GitAllSubscriped(int id)
        {
            try
            {
                var emails = await iEmailNewsletter.GetAllSubscribedAsync(id);
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

        [HttpPost("GetEmailNewsletterById/{id}")]
        public async Task<IActionResult> GetEmailNewsletterById(int id)
        {
            try
            {
                var email = await iEmailNewsletter.GetByIdAsync(id);
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
        public async Task<IActionResult> AddEmailNewsletter(TBEmailNewsletter model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iEmailNewsletter.AddAsync(model);

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
        public async Task<IActionResult> EditEmailNewsletter(int id, [FromBody] TBEmailNewsletter model)
        {
            try
            {
                var email = await iEmailNewsletter.GetByIdAsync(id);
                if (email == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                email = model;
                await iEmailNewsletter.UpdateAsync(email);

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
        public async Task<ActionResult> DeleteEmailNewsletter(int id)
        {
            try
            {
                var email = await iEmailNewsletter.GetByIdAsync(id);
                if (email == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                email.CurrentState = false;
                await iEmailNewsletter.UpdateAsync(email);

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
