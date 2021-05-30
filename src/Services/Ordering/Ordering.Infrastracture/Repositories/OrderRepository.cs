using Microsoft.EntityFrameworkCore;
using Ordering.App.Contracts.Persistence;
using Ordering.Domain.Model;
using Ordering.infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.infrastructure.Repositories {
    public class OrderRepository : BaseRepository<Order>, IOrderRepository {

        public OrderRepository(OrderContext orderContext) : base(orderContext) {
        }

        public async Task<IReadOnlyList<Order>> GetAsync(string userId) {
            return await _dbContext.Orders.Where(v => v.UserId == userId).ToListAsync();
        }
    }
}
