using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQListAPIController : ControllerBase
    {
        IIFAQList iFAQList;
        private ApiResponse _response;
        public FAQListAPIController(IIFAQList iFAQList1)
        {
            iFAQList = iFAQList1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllFAQList/{start}/{end}")]
        public async Task<IActionResult> GitAllFAQList(int start, int end)
        {
            try
            {
                var lists = await iFAQList.GetAllAsync(start, end);
                if (lists == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = lists;
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

        [HttpPost("GitFAQListById/{id}")]
        public async Task<IActionResult> GitFAQListById(int id)
        {
            try
            {
                var list = await iFAQList.GetByIdAsync(id);
                if (list == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = list;
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
        public async Task<IActionResult> AddFAQList(TBFAQList model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iFAQList.AddAsync(model);

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
        public async Task<IActionResult> EditFAQList(int id, [FromBody] TBFAQList model)
        {
            try
            {
                var list = await iFAQList.GetByIdAsync(id);
                if (list == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                list = model;
                await iFAQList.UpdateAsync(list);

                _response.Result = list;
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
        public async Task<ActionResult> DeleteFAQList(int id)
        {
            try
            {
                var list = await iFAQList.GetByIdAsync(id);
                if (list == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                list.CurrentState = false;
                await iFAQList.UpdateAsync(list);

                _response.Result = list;
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
