using Shop.Agregator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Agregator.Services {
    public interface ICartService {
        Task<CartModel> GetCartAsync(string userId);
    }
}
