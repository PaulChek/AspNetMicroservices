using Shop.Agregator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Agregator.Services {
    public interface ICatalogService {
        Task<CatalogModel> GetItemByIdAsync(string id);
        Task<List<CatalogModel>> GetAllItemsAsync();
    }
}
