using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers;

[Route("api/[controller]")]
[ApiController]
public class OrderNewApiController : ControllerBase
{
	public OrderNewApiController(IIOrderNew iOrderNew)
	{
		this.iOrderNew = iOrderNew;
		_response = new ApiResponse();
	}

	private readonly IIOrderNew iOrderNew;
	private ApiResponse _response;

	[HttpPost("GitAllOrdersNew/{start}/{end}")]
	public async Task<ActionResult<IEnumerable<TBViewOrderNew>>> GitAllOrdersNew(int start, int end)
	{
		try
		{
			var customers = await iOrderNew.GetAllOrdersNewAsync(start, end);
			if (customers == null)
				_response.StatusCode = HttpStatusCode.BadRequest;

			_response.Result = customers;
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

	[HttpPost("GitAllOrdersNewWithCondition")]
	public async Task<ActionResult<IEnumerable<TBViewOrderNew>>> GitAllOrdersNewWithCondition(Expression<Func<TBViewOrderNew, bool>> condition)
	{
		try
		{
			var customers = await iOrderNew.GetAllOrdersNewWithConditionAsync(condition);
			if (customers == null)
				_response.StatusCode = HttpStatusCode.BadRequest;
			_response.Result = customers;
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
	public async Task<ActionResult<TBOrderNew>> GitOrderNewById(int id)
	{
		try
		{
			var order = await iOrderNew.GetOrderNewByIdAsync(id);
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
	public async Task<ActionResult> AddOrderNewAsync(TBOrderNew order)
	{
		try
		{
			if (!ModelState.IsValid)
				_response.StatusCode = HttpStatusCode.BadRequest;

			await iOrderNew.AddOrderNewAsync(order);

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
	public async Task<ActionResult> UpdateOrderNewAsync(int id, [FromBody] TBOrderNew orderNew)
	{
		try
		{
			var order = await iOrderNew.GetOrderNewByIdAsync(id);
			if (order == null)
				_response.StatusCode = HttpStatusCode.BadRequest;

			order = orderNew;
			await iOrderNew.UpdateOrderNewAsync(order);

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
	public async Task<ActionResult> DeleteOrderNew(int id)
	{
		try
		{
			var order = await iOrderNew.GetOrderNewByIdAsync(id);
			if (order == null)
				_response.StatusCode = HttpStatusCode.BadRequest;

			order.CurrentState = false;
			await iOrderNew.UpdateOrderNewAsync(order);

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
