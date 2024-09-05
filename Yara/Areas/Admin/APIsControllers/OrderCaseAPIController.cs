using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCaseAPIController : ControllerBase
    {
        public OrderCaseAPIController(IIOrderCase iOrderCase1)
        {
            iOrderCase = iOrderCase1;
            _response = new ApiResponse();
        }

        IIOrderCase iOrderCase;
        private ApiResponse _response;

        [HttpPost("GitAllOrderCases/{start}/{end}")]
        public async Task<IActionResult> GitAllOrderCases(int start, int end)
        {
            try
            {
                var orderCase = await iOrderCase.GetAllAsync(start, end);
                if (orderCase == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = orderCase;
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

        [HttpPost("GitAllOrderCasesWithCondition")]
        public async Task<IActionResult> GitAllOrderCasesWithCondition(Expression<Func<OrderCase, bool>> condition)
        {
            try
            {
                var orderCase = await iOrderCase.GetAlWithConditionAsync(condition);
                if (orderCase == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = orderCase;
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

        [HttpPost("GitOrderCaseById/{id}")]
        public async Task<IActionResult> GitOrderCaseById(int id)
        {
            try
            {
                var orderCase = await iOrderCase.GetByIdAsync(id);
                if (orderCase == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = orderCase;
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
        public async Task<ActionResult> AddOrderCase(OrderCase model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iOrderCase.AddAsync(model);

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
        public async Task<ActionResult> EditOrderCase(int id, [FromBody] OrderCase model)
        {
            try
            {
                var order = await iOrderCase.GetByIdAsync(id);
                if (order == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                order = model;
                await iOrderCase.UpdateAsync(order);

                _response.Result = order;
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
        public async Task<ActionResult> DeleteOrderCase(int id)
        {
            try
            {
                var order = await iOrderCase.GetByIdAsync(id);
                if (order == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                order.CurrentState = false;
                await iOrderCase.UpdateAsync(order);

                _response.Result = order;
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
