using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusAPIController : ControllerBase
    {
        public OrderStatusAPIController(IIOrderStatus iOrderStatus1)
        {
            iOrderStatus = iOrderStatus1;
            _response = new ApiResponse();
        }
        IIOrderStatus iOrderStatus;
        private ApiResponse _response;



        [HttpPost("GitAllOrderStatus/{start}/{end}")]
        public async Task<IActionResult> GitAllOrderStatus(int start, int end)
        {
            try
            {
                var order = await iOrderStatus.GetAllAsync(start, end);
                if (order == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = order;
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

        [HttpPost("GitAllOrderStatusWithCondition")]
        public async Task<IActionResult> GitAllOrderStatusWithCondition(Expression<Func<TBViewOrderStatus, bool>> condition)
        {
            try
            {
                var order = await iOrderStatus.GetAlWithConditionAsync(condition);
                if (order == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = order;
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

        [HttpPost("GitOrderStatusById/{id}")]
        public async Task<IActionResult> GitOrderStatusById(int id)
        {
            try
            {
                var order = await iOrderStatus.GetByIdAsync(id);
                if (order == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = order;
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
        public async Task<IActionResult> AddOrderStatus(OrderStatus model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iOrderStatus.AddAsync(model);

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
        public async Task<IActionResult> EditOrderStatus(int id, [FromBody] OrderStatus model)
        {
            try
            {
                var order = await iOrderStatus.GetByIdAsync(id);
                if (order == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                order = model;
                await iOrderStatus.UpdateAsync(order);

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
        public async Task<ActionResult> DeleteOrderStatus(int id)
        {
            try
            {
                var order = await iOrderStatus.GetByIdAsync(id);
                if (order == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                order.CurrentState = false;
                await iOrderStatus.UpdateAsync(order);

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
