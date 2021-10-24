using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public class DatabaseDriver : IDatabaseDriver
    {
        public List<Supplier> _suppliers = new List<Supplier>();

        public Article GetById(int id)
        {
            return _suppliers.Select(x => x.Articles.FirstOrDefault(a => a.ID == id)) as Article;
        }

        public void Save(Article article)
        {
            foreach (var supplier in _suppliers)
            {
                foreach (var articleOnStock in supplier.Articles)
                {
                    if (articleOnStock.ID == article.ID)
                    {
                        articleOnStock.IsSold = true;
                    }
                }
            }
            // _suppliers.Select(x => x.Articles.FirstOrDefault(a => a.ID == article.ID)).Single(s => s.IsSold = true) ;
        }
         public async Task<List<Supplier>> GetAllSuppliersAsync() => _suppliers = await Service.LoadSuppliers();

    }
}