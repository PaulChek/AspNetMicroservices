using Shop.Agregator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Agregator.Services {
    public interface IOrderService {
        Task<List<OrderResponseModel>> GetOrdersAsync(string userId);
    }
}
