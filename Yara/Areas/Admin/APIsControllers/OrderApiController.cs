using Domin.Entity;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.API_Controller;

[Authorize(Roles = "Admin,ApiRoles")]
[Route("api/[controller]")]
[ApiController]
public class OrderApiController : ControllerBase
{
	private ApiResponse _response;
	public OrderApiController(IIOrder iOrder)
	{
		this.iOrder = iOrder;
		_response = new ApiResponse();
	}

	private readonly IIOrder iOrder;

	[HttpPost("GitAllOrders/{start}/{end}")]
	public async Task<ActionResult<IEnumerable<TBViewOrder>>> GitAllOrders(int start, int end)
	{
		try
		{
			var orders = await iOrder.GetAllOrdersAsync(start, end);
			if (orders == null)
				_response.StatusCode = HttpStatusCode.BadRequest;

			_response.Result = orders;
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

	[HttpPost("GitAllOrdersWithCondition")]
	public async Task<ActionResult<IEnumerable<TBViewOrder>>> GitAllOrdersWithCondition(Expression<Func<TBViewOrder, bool>> condition)
	{
		try
		{
			var orders = await iOrder.GetAllOrdersWithConditionAsync(condition);
			if (orders == null)
				_response.StatusCode = HttpStatusCode.BadRequest;
			_response.Result = orders;
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

	[HttpPost("{id}")]
	public async Task<ActionResult<TBViewMerchant>> GitOrderById(int id)
	{
		try
		{
			var merchant = await iOrder.GetOrderAsync(id);
			if (merchant == null)
				_response.StatusCode = HttpStatusCode.BadRequest;
			_response.Result = merchant;
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
	public async Task<ActionResult> AddOrder(Order order)
	{
		try
		{
			if (!ModelState.IsValid)
				_response.StatusCode = HttpStatusCode.BadRequest;

			await iOrder.AddOrderAsync(order);

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

	[HttpPut("{id}")]
	public async Task<ActionResult> EditOrder(int id, [FromBody] Order order)
	{
		try
		{
			var ord = await iOrder.GetOrderAsync(id);
			if (ord == null)
				_response.StatusCode = HttpStatusCode.BadRequest;

			ord = order;
			await iOrder.UpdateOrderAsync(ord);

			_response.Result = ord;
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
	public async Task<ActionResult> DeleteOrder(int id)
	{
		try
		{
			var order = await iOrder.GetOrderAsync(id);
			if (order == null)
				_response.StatusCode = HttpStatusCode.BadRequest;

			order.CurrentState = false;
			await iOrder.UpdateOrderAsync(order);

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

    [HttpPost("GetOrdersByPhone/{phoneNumber}")]
    public async Task<ActionResult<IEnumerable<TBViewOrder>>> GetOrdersByPhone(string phoneNumber)
    {
        try
        {
			var orders = await iOrder.GetOrdersByPhoneAsync(phoneNumber);
            if (orders == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
            }

            _response.Result = orders;
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

