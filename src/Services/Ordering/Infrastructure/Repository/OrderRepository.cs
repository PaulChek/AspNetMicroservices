using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts_Interfaces;
using Domain.Model;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository {
    public class OrderRepository : BaseRepository<Order>, IOrderRepository {
        public OrderRepository(OrderContext dbContext) : base(dbContext) {
        }

        public async Task<IEnumerable<Order>> GetAllOrdersByUserId(string userId) {
            return await _dbContext.Orders.Where(o => o.UserId == userId).ToListAsync();
        }
    }
}
