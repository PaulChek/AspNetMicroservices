using Ordering.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.App.Contracts.Persistence {
    public interface IOrderRepository : IAsyncRepository<Order> {
        Task<IReadOnlyList<Order>> GetAsync(string userId);
    }
}
