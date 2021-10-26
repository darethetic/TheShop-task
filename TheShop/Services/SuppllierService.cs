using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Dtos;
using TheShop.Mappers;
using TheShop.Services.Interfaces;

namespace TheShop.Services
{
    public class SuppllierService : ISupplierService
    {
        private List<Supplier> _suppliers = new List<Supplier>();
        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            var suppliers = await ApiService.LoadSuppliers();            

            foreach (var item in suppliers)
            {
                _suppliers.Add(item.ToModel());
            }

            return _suppliers;
        }

        public ArticleDto OrderArticlesFromSupplier(List<SupplierDto> suppliers, int id, int maxExpectedPrice)
        {
            var articles = new List<ArticleDto>();            
            foreach (var supplier in suppliers)
            {
                foreach (var articleOnStock in supplier.Articles)
                {
                    if (articleOnStock.Id == id && articleOnStock.Price < maxExpectedPrice)
                        articles.Add(articleOnStock);
                }
            }

            var article = articles.Any() ? articles.OrderBy(x => x.Price).FirstOrDefault() : null;

            return article;
        }
    }
}
