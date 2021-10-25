using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheShop.Dtos;
using TheShop.Services.Interfaces;

namespace TheShop
{
    public class ShopService : IShopService
    {
        private IDatabaseDriver _databaseDriver;
        private ILogger _logger;
        private ISupplierService _supplierService;

        public ShopService(ILogger logger, IDatabaseDriver databaseDriver, ISupplierService supplierService)
        {
            _databaseDriver = databaseDriver;
            _logger = logger;
            _supplierService = supplierService;
        }

        public async Task<ArticleDto> OrderArticle(int id, int maxExpectedPrice)
        {
            #region ordering article
            var suppliers = await _supplierService.GetAllSuppliersAsync();



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
           
            #endregion
        }

        public void SellArticle(Article article, int buyerId)
        {
            if (article == null)
            {
                throw new Exception("Could not order article");
            }
            _logger.Debug("Trying to sell article with id=" + article.ID);

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            try
            {
                _databaseDriver.Save(article);
                _logger.Info("Article with id=" + article.ID + " is sold.");
            }
            catch (Exception ex)
            {
                _logger.Error("Could not save article with id=" + article.ID + "; 'Reason:" + ex.Message);
            }
        }

        public Article GetById(int id)
        {
            return _databaseDriver.GetById(id);
        }
    }


}
