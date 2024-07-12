using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PostTestSERA.DataAccessLayer;
using PostTestSERA.Model;
using MediatR;

namespace PostTestSERA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMediator _mediator;
        public CRUDController(IMediator mediator)=>_mediator=mediator;

        [HttpGet]
        public async Task<CustomerResponse> GetCustomers() => await _mediator.Send(new GetCustomer.Query());
        [HttpGet("{id}")]
        public async Task<CustResponse> GetCustomer(int id) => await _mediator.Send(new GetCustomerById.Query { Id=id});
        [HttpPost]
        public async Task<ResponseBase> CreateCustomer([FromBody]AddCustomer.Command command)
        {
            ResponseBase response = new ResponseBase();
            if (!ModelState.IsValid)
            {
                response.Message = "Bad Request";
                response.TransactionId = 0;
                return response;
            }

            var createCustomerId = await _mediator.Send(command);
            CreatedAtAction(nameof(GetCustomer), new { id = createCustomerId }, null);
            response.Message = "Success";
            response.TransactionId = 0;
            return response;
        }
        [HttpPut]
        public async Task<ResponseBase> UpdateCustomer([FromBody]UpdateCustomer.CommandUpdate command)
        {
            var updateCustomer= await _mediator.Send(command);
            ResponseBase response= new ResponseBase();
            response.Message = "Success";
            response.TransactionId = 0;
            return response;
        }
        [HttpDelete]
        public async Task<ResponseBase> DeleteCustomer(int customerId)
        {
            await _mediator.Send(new Delete.DeleteCommand { CustomerId=customerId });
            ResponseBase response=  new ResponseBase();
            response.Message = "Success";
            response.TransactionId = 0;
            return response;
        }
       
    }
}
