using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Dtos;
using TheShop.Services.Interfaces;

namespace TheShop.Services
{
    public class SuppllierService: ISupplierService
    {
        public List<SupplierDto> _suppliers = new List<SupplierDto>();
        public async Task<List<SupplierDto>> GetAllSuppliersAsync() => _suppliers = await ApiService.LoadSuppliers();

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
            var article = articles.OrderBy(x => x.Price).FirstOrDefault();

            return article;
        }
    }
}
