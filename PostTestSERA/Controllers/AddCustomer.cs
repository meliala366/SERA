using MediatR;
using PostTestSERA.Model;
using PostTestSERA.DataAccessLayer;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace PostTestSERA.Controllers
{
    public class AddCustomer
    {
        public class Command : IRequest<int>
        {
            public string customerCode { get; set; }
            public string customerName { get; set; }
            public string customerAddress { get; set; }
            public int createdBy { get; set; }
            public DateTime createdAt { get; set; }
            public int modifiedBy { get; set; }
            public DateTime modifiedAt { get; set; }
        }
        public class CommandHandler : IRequestHandler<Command, int>
        {
            private readonly AppDbContext _db;
            public CommandHandler(AppDbContext db)=>_db = db;
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = new Customer
                {
                    customerAddress = request.customerAddress,
                    customerCode = request.customerCode,
                    customerName = request.customerName,
                    modifiedAt = request.modifiedAt,
                    modifiedBy = request.modifiedBy,
                    createdAt = request.createdAt,
                    createdBy = request.createdBy
                };
                await _db.AddAsync(entity, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);
                return entity.customerId;
            }
        }
    }
}
