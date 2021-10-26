using System.Collections.Generic;
using TheShop.Dtos;

namespace TheShop.Mappers
{
    public static class SupplierModelMapper
    {
        public static Supplier ToModel(this SupplierDto supplierDto)
        {
            var supplier = new Supplier()
            {
                SupplierId = supplierDto.Id,
                Articles = new Dictionary<Article, bool>()
            };

            foreach (var item in supplierDto.Articles)
            {
                var article = new Article()
                {
                    Id = item.Id,
                    NameOfArticle = item.Name,
                    Price = item.Price
                };

                supplier.Articles.Add(article, item.InInventory);
            }

            return supplier;
        }
    }
}
