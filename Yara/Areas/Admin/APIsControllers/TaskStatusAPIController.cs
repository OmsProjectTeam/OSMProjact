using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusAPIController : ControllerBase
    {
        IITaskStatus iTaskStatus;
        private ApiResponse _response;
        public TaskStatusAPIController(IITaskStatus iTaskStatus1)
        {
            iTaskStatus = iTaskStatus1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllTaskStatus/{start}/{end}")]
        public async Task<IActionResult> GitAllTaskStatus(int start, int end)
        {
            try
            {
                var tasks = await iTaskStatus.GetAllAsync(start, end);
                if (tasks == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = tasks;
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

        [HttpPost("GitTaskStatusById/{id}")]
        public async Task<IActionResult> GitTaskStatusById(int id)
        {
            try
            {
                var task = await iTaskStatus.GetByIdAsync(id);
                if (task == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = task;
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
        public async Task<IActionResult> AddTaskStatus(TaskStatus model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iTaskStatus.AddAsync(model);

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
        public async Task<IActionResult> EditTaskStatus(int id, [FromBody] TaskStatus model)
        {
            try
            {
                var task = await iTaskStatus.GetByIdAsync(id);
                if (task == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                task = model;
                await iTaskStatus.UpdateAsync(task);

                _response.Result = task;
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
        public async Task<ActionResult> DeleteTaskStatus(int id)
        {
            try
            {
                var task = await iTaskStatus.GetByIdAsync(id);
                if (task == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                task.CurrentState = false;
                await iTaskStatus.UpdateAsync(task);

                _response.Result = task;
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
