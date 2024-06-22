using Domin.Entity;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.API_Controller;

[Authorize(Roles = "Admin,ApiRoles")]
[Route("api/[controller]")]
[ApiController]
public class MerchantAPIController : ControllerBase
{
	private ApiResponse _response;
	public MerchantAPIController(IIMerchant iMerchant)
    {
        this.iMerchant = iMerchant;
        _response = new ApiResponse();
    }

    private readonly IIMerchant iMerchant;

    [HttpPost("GitAllMerchants/{start}/{end}")]
    public async Task<ActionResult<IEnumerable<TBViewMerchant>>> GitAllMerchants(int start, int end)
    {
        try
        {
			var merchants = await iMerchant.GetAllMerchantsAsync(start, end);
			if (merchants == null)
				_response.StatusCode = HttpStatusCode.BadRequest;

			_response.Result = merchants;
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

    [HttpPost("GitAllMerchantsWithCondition")]
    public async Task<ActionResult<IEnumerable<TBViewMerchant>>> GitAllMerchantsWithCondition(Expression<Func<TBViewMerchant, bool>> condition)
    {
        try
        {
            var merchants = await iMerchant.GetAllMerchantsWithConditionAsync(condition);
            if (merchants == null)
                _response.StatusCode = HttpStatusCode.BadRequest;
            _response.Result = merchants;
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
    public async Task<ActionResult<TBViewMerchant>> GitMerchantById(int id)
    {
        try
        {
            var merchant = await iMerchant.GetMerchantAsync(id);
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
    public async Task<ActionResult> AddMerchant(Merchant merchant)
    {
        try
        {
            if (!ModelState.IsValid)
                _response.StatusCode = HttpStatusCode.BadRequest;

            await iMerchant.AddMerchantAsync(merchant);

            _response.Result = merchant;
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
    public async Task<ActionResult> EditMerchant(int id, [FromBody] Merchant merchant)
    {
        try
        {
			var merch = await iMerchant.GetMerchantAsync(id);
			if (merch == null)
				_response.StatusCode = HttpStatusCode.BadRequest;

			merch = merchant;
			await iMerchant.UpdateMerchantAsync(merch);

			_response.Result = merch;
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
    public async Task<ActionResult> DeleteMerchant(int id)
    {
        try
        {
			var merch = await iMerchant.GetMerchantAsync(id);
			if (merch == null)
				_response.StatusCode = HttpStatusCode.BadRequest;

			merch.CurrentState = false;
			await iMerchant.UpdateMerchantAsync(merch);

			_response.Result = merch;
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

