using AspnetRunBasics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services.Interfaces {
    public interface ICatalogService {
        Task<CatalogModel> GetItemByIdAsync(string id);
        Task<List<CatalogModel>> GetAllItemsAsync();
    }
}
