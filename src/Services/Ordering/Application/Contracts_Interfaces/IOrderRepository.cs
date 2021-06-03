using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts_Interfaces {
    public interface IOrderRepository : IRepository<Order> {
        Task<IEnumerable<Order>> GetAllOrdersByUserId(string userId);
    }
}
