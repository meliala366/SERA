using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using PostTestSERA.DataAccessLayer;
using PostTestSERA.Model;
using PostTestSERA.Controllers;
using System.Threading;

namespace PostTestSERAxUnit
{
    public class UnitTestCustomer
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task RetrieveCustomer()
        {
            var context = GetDbContext();
            CancellationToken cancellationToken=new CancellationToken();
            GetCustomerById.QueryHandler repo = new GetCustomerById.QueryHandler(context);
            var customer = new GetCustomerById.Query { Id = 1};

            await repo.Handle(customer, cancellationToken);
            var result =await context.customer.FirstOrDefaultAsync(p=>p.customerId == customer.Id);
            Assert.NotNull(result);
            Assert.Equal("Test Customer", result.customerName);
        }
    }
}