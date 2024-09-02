using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionAPIController : ControllerBase
    {
        IITransaction iTransaction;
        private ApiResponse _response;
        public TransactionAPIController(IITransaction iTransaction1)
        {
            iTransaction = iTransaction1;
            _response = new ApiResponse();
        }

        [HttpPost("GitAllCities/{start}/{end}")]
        public async Task<IActionResult> GitAllTransactions(int start, int end)
        {
            try
            {
                var transactions = await iTransaction.GetAllAsync(start, end);
                if (transactions == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                _response.Result = transactions;
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

        [HttpPost("GitTransactionById/{id}")]
        public async Task<IActionResult> GitTransactionById(int id)
        {
            try
            {
                var transaction = await iTransaction.GetByIdAsync(id);
                if (transaction == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Result = transaction;
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
        public async Task<IActionResult> AddTransaction(TBTransaction model)
        {
            try
            {
                if (!ModelState.IsValid)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                await iTransaction.AddAsync(model);

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
        public async Task<IActionResult> EditTransaction(int id, [FromBody] TBTransaction model)
        {
            try
            {
                var transaction = await iTransaction.GetByIdAsync(id);
                if (transaction == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                transaction = model;
                await iTransaction.UpdateAsync(transaction);

                _response.Result = transaction;
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
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            try
            {
                var transaction = await iTransaction.GetByIdAsync(id);
                if (transaction == null)
                    _response.StatusCode = HttpStatusCode.BadRequest;

                transaction.CurrentState = false;
                await iTransaction.UpdateAsync(transaction);

                _response.Result = transaction;
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
