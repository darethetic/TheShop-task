using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheShop
{
    public interface IDatabaseDriver
    {
        Article GetById(int id);
        void Save(Article article);
        Task<List<Supplier>> GetAllSuppliersAsync();
    }
}