using MediatR;
using PostTestSERA.Model;
using PostTestSERA.DataAccessLayer;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace PostTestSERA.Controllers
{
    public class Delete
    {
        public class DeleteCommand : IRequest
        {
            public int CustomerId { get; set; }
        }
        public class CommandHandler : IRequestHandler<DeleteCommand, Unit>
        {
            private readonly AppDbContext _db;
            public CommandHandler(AppDbContext db) => _db = db;
            public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var cus=await _db.customer.FindAsync(request.CustomerId);
                if (cus == null) return Unit.Value;
                _db.customer.Remove(cus);
                await _db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
