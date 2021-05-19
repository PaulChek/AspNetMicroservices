using Cart.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.Api.Repository {
    public interface IRepository {
        Task<ShoppingCart> Get(string UserId);
        Task<ShoppingCart> Update(ShoppingCart cart);
        Task Delete(string UserId);
    }
}
