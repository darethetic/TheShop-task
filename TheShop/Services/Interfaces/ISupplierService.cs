using System.Collections.Generic;
using System.Threading.Tasks;
using TheShop.Dtos;

namespace TheShop.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<List<SupplierDto>> GetAllSuppliersAsync();
        ArticleDto OrderArticlesFromSupplier(List<SupplierDto> suppliers, int id, int maxExpectedPrice);
    }
}
