using Infarstuructre.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQAPIController : ControllerBase
    {
        IIFAQ iFAQ;
        private ApiResponse _response;
        public FAQAPIController(IIFAQ iFAQ1)
        {
            iFAQ = iFAQ1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllFAQs/{start}/{end}")]
        public async Task<IActionResult> GitAllFAQs(int start, int end)
        {
            try
            {
                var faqs = await iFAQ.GetAllAsync(start, end);
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

        [HttpPost("GitAllActiveFAQs")]
        public async Task<IActionResult> GitAllActiveFAQs()
        {
            try
            {
                var faqs = await iFAQ.GetAllActiveAsync();
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

        [HttpPost("GitFAQById/{id}")]
        public async Task<IActionResult> GitFAQById(int id)
        {
            try
            {
                var faq = await iFAQ.GetByIdAsync(id);
                if (faq == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = faq;
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
        public async Task<IActionResult> AddFAQ(TBFAQ model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iFAQ.AddDataAsync(model);

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
        public async Task<IActionResult> EditFAQ(int id, [FromBody] TBFAQ model)
        {
            try
            {
                var faq = await iFAQ.GetByIdAsync(id);
                if (faq == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                faq = model;
                await iFAQ.UpdateAsync(faq);

                _response.Result = faq;
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
        public async Task<ActionResult> DeleteFAQ(int id)
        {
            try
            {
                var faq = await iFAQ.GetByIdAsync(id);
                if (faq == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                faq.CurrentState = false;
                await iFAQ.UpdateAsync(faq);

                _response.Result = faq;
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
