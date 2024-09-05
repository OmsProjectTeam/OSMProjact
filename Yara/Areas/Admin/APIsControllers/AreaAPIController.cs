using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaAPIController : ControllerBase
    {
        IIArea iArea;
        public AreaAPIController(IIArea iArea1)
        {
            iArea = iArea1;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allData = await iArea.GetAllAsync();
            if (allData == null)
                return NotFound();

            return Ok(allData);
        }

        [HttpGet("GetAllv/{id}")]
        public async Task<IActionResult> GetAllv(int id)
        {
            var allData = await iArea.GetAllvAsync(id);
            if (allData == null)
                return NotFound();

            return Ok(allData);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var allData = await iArea.GetByIdAsync(id);
            if (allData == null)
                return NotFound();

            return Ok(allData);
        }

        [HttpPost]
        public async Task<IActionResult> AddData(Area area)
        {
            if (ModelState.IsValid)
            {
                await iArea.AddAsync(area);
                return Ok(area);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateData(int id, Area area)
        {
            var area1 = await iArea.GetByIdAsync(id);
            if(area1 == null)
                return NotFound();
            area1 = area;
            await iArea.UpdateAsync(area1);
            return Ok(area1);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            var area1 = await iArea.GetByIdAsync(id);
            if (area1 == null)
                return NotFound();
            await iArea.DeleteAsync(id);
            return Ok();
        }
    }
}
