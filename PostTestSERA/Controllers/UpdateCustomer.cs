using MediatR;
using PostTestSERA.Model;
using PostTestSERA.DataAccessLayer;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PostTestSERA.Controllers;
namespace PostTestSERA.Controllers
{
    public class UpdateCustomer
    {
        public class CommandUpdate : IRequest<ResponseBase>
        {
            public int customerId { get; set; }
            public string customerCode { get; set; }

            public string customerName { get; set; }
            public string customerAddress { get; set; }
            public int createdBy { get; set; }
            public DateTime createdAt { get; set; }
            public int modifiedBy { get; set; }
            public DateTime modifiedAt { get; set; }
        }
        public class CommandHandler : IRequestHandler<CommandUpdate, ResponseBase>
        {
            private readonly AppDbContext _db;
            public CommandHandler(AppDbContext db) => _db = db;
            public async Task<ResponseBase> Handle(CommandUpdate request, CancellationToken cancellationToken)
            {
                CustResponse response = new CustResponse();
                var cust =await _db.customer.FindAsync(request.customerId);
                cust.customerName = request.customerName;
                cust.customerAddress = request.customerAddress;
                cust.customerCode = request.customerCode;
                cust.createdAt= request.createdAt;
                cust.createdBy= request.createdBy;
                cust.modifiedAt= request.modifiedAt;
                cust.modifiedBy= request.modifiedBy;
                await _db.SaveChangesAsync();
                response.Message = "Success";
                response.TransactionId = 0;
                return response;
            }

        }
    }
}
