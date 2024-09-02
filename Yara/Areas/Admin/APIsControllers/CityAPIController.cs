using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityAPIController : ControllerBase
    {
        public CityAPIController(IICity iCity1) 
        {
            iCity = iCity1;
            _response = new ApiResponse();
        }
        IICity iCity;
        private ApiResponse _response;

        [HttpPost("GitAllCities/{start}/{end}")]
        public async Task<IActionResult> GitAllCities(int start, int end)
        {
            try
            {
                var city = await iCity.GetAllAsync(start, end);
                if (city == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = city;
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

        [HttpPost("GitAllCitiesWithCondition")]
        public async Task<IActionResult> GitAllCitiesWithCondition(Expression<Func<City, bool>> condition)
        {
            try
            {
                var city = await iCity.GetAlWithConditionAsync(condition);
                if (city == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = city;
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

        [HttpPost("GitCityById/{id}")]
        public async Task<IActionResult> GitCityById(int id)
        {
            try
            {
                var city = await iCity.GetByIdAsync(id);
                if (city == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = city;
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
        public async Task<IActionResult> AddCity(City model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iCity.AddAsync(model);

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
        public async Task<IActionResult> EditCity(int id, [FromBody] City model)
        {
            try
            {
                var city = await iCity.GetByIdAsync(id);
                if (city == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                city = model;
                await iCity.UpdateAsync(city);

                _response.Result = city;
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
        public async Task<ActionResult> DeleteCity(int id)
        {
            try
            {
                var city = await iCity.GetByIdAsync(id);
                if (city == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                city.CurrentState = false;
                await iCity.UpdateAsync(city);

                _response.Result = city;
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
