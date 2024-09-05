using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesCompaniesAPIController : ControllerBase
    {
        IITypesCompanies iTypesCompanies;
        private ApiResponse _response;
        public TypesCompaniesAPIController(IITypesCompanies iTypesCompanies1)
        {
            iTypesCompanies = iTypesCompanies1;

        }





        [HttpPost("GitAllTypesCompanies/{start}/{end}")]
        public async Task<IActionResult> GitAllTypesCompanies(int start, int end)
        {
            try
            {
                var Types = await iTypesCompanies.GetAllAsync(start, end);
                if (Types == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = Types;
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

        [HttpPost("GitTypesCompaniesById/{id}")]
        public async Task<IActionResult> GitTypesCompaniesById(int id)
        {
            try
            {
                var Type = await iTypesCompanies.GetByIdAsync(id);
                if (Type == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = Type;
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
        public async Task<IActionResult> AddTypesCompanies(TBTypesCompanies model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iTypesCompanies.AddAsync(model);

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
        public async Task<IActionResult> EditTypesCompanies(int id, [FromBody] TBTypesCompanies model)
        {
            try
            {
                var Type = await iTypesCompanies.GetByIdAsync(id);
                if (Type == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                Type = model;
                await iTypesCompanies.UpdateAsync(Type);

                _response.Result = Type;
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
        public async Task<ActionResult> DeleteTypesCompanies(int id)
        {
            try
            {
                var Type = await iTypesCompanies.GetByIdAsync(id);
                if (Type == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                Type.CurrentState = false;
                await iTypesCompanies.UpdateAsync(Type);

                _response.Result = Type;
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
