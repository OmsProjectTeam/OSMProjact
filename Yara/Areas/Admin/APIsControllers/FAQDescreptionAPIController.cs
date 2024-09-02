using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQDescreptionAPIController : ControllerBase
    {
        IIFAQDescreption iFAQDescreption;
        private ApiResponse _response;
        public FAQDescreptionAPIController(IIFAQDescreption iFAQDescreption1)
        {
            iFAQDescreption = iFAQDescreption1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllFAQDescreption/{start}/{end}")]
        public async Task<IActionResult> GitAllFAQDescreption(int start, int end)
        {
            try
            {
                var faqs = await iFAQDescreption.GetAllAsync(start, end);
                if (faqs == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = faqs;
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

        [HttpPost("GitFAQDescreptionById/{id}")]
        public async Task<IActionResult> GitFAQDescreptionById(int id)
        {
            try
            {
                var desc = await iFAQDescreption.GetByIdAsync(id);
                if (desc == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = desc;
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
        public async Task<IActionResult> AddFAQDescreption(TBFAQDescreption model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iFAQDescreption.AddAsync(model);

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
        public async Task<IActionResult> EditFAQDescreption(int id, [FromBody] TBFAQDescreption model)
        {
            try
            {
                var desc = await iFAQDescreption.GetByIdAsync(id);
                if (desc == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                desc = model;
                await iFAQDescreption.UpdateAsync(desc);

                _response.Result = desc;
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
        public async Task<ActionResult> DeleteFAQDescreption(int id)
        {
            try
            {
                var desc = await iFAQDescreption.GetByIdAsync(id);
                if (desc == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                desc.CurrentState = false;
                await iFAQDescreption.UpdateAsync(desc);

                _response.Result = desc;
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
