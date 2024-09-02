using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationCompaniesAPIController : ControllerBase
    {
        IIInformationCompanies iInformationCompanies;
        private ApiResponse _response;
        public InformationCompaniesAPIController(IIInformationCompanies iInformationCompanies1)
        {
            iInformationCompanies = iInformationCompanies1;
            _response = new ApiResponse();
        }


        [HttpPost("GitAllInformationCompanies/{start}/{end}")]
        public async Task<IActionResult> GitAllInformationCompanies(int start, int end)
        {
            try
            {
                var companies = await iInformationCompanies.GetAllAsync(start, end);
                if (companies == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = companies;
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

        [HttpPost("GitInformationCompaniesById/{id}")]
        public async Task<IActionResult> GitInformationCompaniesById(int id)
        {
            try
            {
                var company = await iInformationCompanies.GetByIdAsync(id);
                if (company == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = company;
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
        public async Task<IActionResult> AddInformationCompanies(TBInformationCompanies model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iInformationCompanies.AddAsync(model);

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
        public async Task<IActionResult> EditInformationCompanies(int id, [FromBody] TBInformationCompanies model)
        {
            try
            {
                var company = await iInformationCompanies.GetByIdAsync(id);
                if (company == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                company = model;
                await iInformationCompanies.UpdateAsync(company);

                _response.Result = company;
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
        public async Task<ActionResult> DeleteInformationCompanies(int id)
        {
            try
            {
                var company = await iInformationCompanies.GetByIdAsync(id);
                if (company == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                company.CurrentState = false;
                await iInformationCompanies.UpdateAsync(company);

                _response.Result = company;
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
                var result = await iInformationCompanies.DELETPHOTOAsync(id);

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
                var result = await iInformationCompanies.DELETPHOTOWethErrorAsync(name);

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
