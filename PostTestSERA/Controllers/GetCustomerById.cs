using MediatR;
using PostTestSERA.Model;
using PostTestSERA.DataAccessLayer;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PostTestSERA.Controllers;

public class GetCustomerById
{
    public class Query : IRequest<CustResponse>
    {
        public int Id { get; set; }
    }
    public class QueryHandler : IRequestHandler<Query, CustResponse>
    {
        private readonly AppDbContext _db;
        public QueryHandler(AppDbContext db) => _db = db;
        public async Task<CustResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            CustResponse response = new CustResponse();
            response.Object=await _db.customer.FindAsync(request.Id);
            response.Message = "Success";
            response.TransactionId = 0;
            return response;
        }

    }

}
