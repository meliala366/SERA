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
    public class GetCustomer
    {
        public class Query : IRequest<CustomerResponse> { }
        public class QueryHandler : IRequestHandler<Query, CustomerResponse>
        {
            private readonly AppDbContext _db;
            public QueryHandler(AppDbContext db) => _db = db;
            public async Task<CustomerResponse> Handle(Query request, CancellationToken cancellationToken)
            {
                CustomerResponse response = new CustomerResponse();
                response.Object = await _db.customer.ToListAsync(cancellationToken);
                response.Message = "Success";
                response.TransactionId = 0;
                return response;
            }

        }
    }
}
