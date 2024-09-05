using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferAPIController : ControllerBase
    {
        IITransfer iTransfer;
        private ApiResponse _response;
        public TransferAPIController(IITransfer iTransfer1)
        {
            iTransfer = iTransfer1;
            _response = new ApiResponse();
        }

        [HttpPost("GetAllProfits/{start}/{end}")]
        public async Task<IActionResult> GetAllProfits(int start, int end)
        {
            try
            {
                var Profits = await iTransfer.GetAllProfitsAsync(start, end);
                if (Profits == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = Profits;
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

        [HttpPost("GitAllProfitsWithCondition")]
        public async Task<IActionResult> GitAllProfitsWithCondition(Expression<Func<TBViewTransfer, bool>> condition)
        {
            try
            {
                var Profits = await iTransfer.GetAllProfitsWithConditionAsync(condition);
                if (Profits == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = Profits;
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

        [HttpPost("GetProfitById/{id}")]
        public async Task<IActionResult> GetProfitById(int id)
        {
            try
            {
                var Profit = await iTransfer.GetProfitByIdAsync(id);
                if (Profit == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = Profit;
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
        public async Task<IActionResult> AddProfit(TBTransfer model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iTransfer.AddProfitsAsync(model);

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
        public async Task<IActionResult> EditProfit(int id, [FromBody] TBTransfer model)
        {
            try
            {
                var profit = await iTransfer.GetProfitByIdAsync(id);
                if (profit == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                profit = model;
                await iTransfer.UpdateProfitAsync(profit);

                _response.Result = profit;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }

            return Ok(_response);
        }


        [HttpPost("DeletePhoto/{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            try
            {
                var result = await iTransfer.DELETPHOTOAsync(id);

                if (result)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.Result = result;
                    return Ok(_response);
                }

                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = result;

                return Ok(_response);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.Message };
            }

            return Ok(_response);
        }

        [HttpPost("DeletePhotoWithError/{name}")]
        public async Task<IActionResult> DeletePhotoWithError(string name)
        {
            try
            {
                var result = await iTransfer.DELETPHOTOWethErrorAsync(name);

                if (result)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.Result = result;
                    return Ok(_response);
                }

                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = result;

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
