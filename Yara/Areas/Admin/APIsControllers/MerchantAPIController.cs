using System.Linq.Expressions;

namespace Yara.Areas.Admin.API_Controller;

[Authorize(Roles = "Admin,ApiRoles")]
[Route("api/[controller]")]
[ApiController]
public class MerchantAPIController : ControllerBase
{
    public MerchantAPIController(IIMerchant iMerchant)
    {
        this.iMerchant = iMerchant;
    }

    private readonly IIMerchant iMerchant;

    [HttpPost("GitAllMerchants")]
    public async Task<ActionResult<IEnumerable<TBViewMerchant>>> GitAllMerchants()
    {
        var merchants = await iMerchant.GetAllMerchantsAsync();
        if(merchants == null)
            return NotFound("No data to show! ");

        return Ok(merchants);
    }

    [HttpPost("GitAllMerchantsWithCondition")]
    public async Task<ActionResult<IEnumerable<TBViewMerchant>>> GitAllMerchantsWithCondition(Expression<Func<TBViewMerchant, bool>> condition)
    {
        var merchants = await iMerchant.GetAllMerchantsWithConditionAsync(condition);
        if (merchants == null)
            return NoContent();

        return Ok(merchants);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult<TBViewMerchant>> GitMerchantById(int id)
    {
        var merchant = await iMerchant.GetMerchantAsync(id);
        if (merchant == null)
            return NotFound();

        return Ok(merchant);
    }

    [HttpPost]
    public async Task<ActionResult> AddMerchant(Merchant merchant)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        await iMerchant.AddMerchantAsync(merchant);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> EditMerchant(int id, [FromBody] Merchant merchant)
    {
        var merch = await iMerchant.GetMerchantAsync(id);
        if (merch == null)
            return NotFound();

        merch = merchant;
        await iMerchant.UpdateMerchantAsync(merch);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMerchant(int id)
    {
        var merch = await iMerchant.GetMerchantAsync(id);
        if (merch == null)
            return NotFound();

        merch.CurrentState = false;
        await iMerchant.UpdateMerchantAsync(merch);
        return Ok();
    }
}

