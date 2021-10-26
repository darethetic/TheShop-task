using System.Collections.Generic;
using System.Threading.Tasks;
using TheShop.Dtos;

namespace TheShop.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<List<Supplier>> GetAllSuppliersAsync();
        ArticleDto OrderArticlesFromSupplier(List<SupplierDto> suppliers, int id, int maxExpectedPrice);
    }
}
