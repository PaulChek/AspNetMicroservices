using AspnetRunBasics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services.Interfaces {
    public interface IOrderService {
        Task<List<OrderResponseModel>> GetOrdersAsync(string userId);
    }
}
