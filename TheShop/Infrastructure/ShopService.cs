using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheShop
{
    public class ShopService : IShopService
    {
        private IDatabaseDriver _databaseDriver;
        private ILogger _logger;

        public ShopService(ILogger logger, IDatabaseDriver databaseDriver)
        {
            _databaseDriver = databaseDriver;
            _logger = logger;
        }

        public async Task<Article> OrderArticle(int id, int maxExpectedPrice)
        {
            #region ordering article
            var suppliers = await _databaseDriver.GetAllSuppliersAsync();

            var articles = new List<Article>();

            foreach (var supplier in suppliers)
            {
                foreach (var articleOnStock in supplier.Articles)
                {
                    if (!articleOnStock.IsSold && articleOnStock.ID == id && articleOnStock.ArticlePrice < maxExpectedPrice)
                        articles.Add(articleOnStock);
                }
            }
            var article = articles.OrderBy(x => x.ArticlePrice).FirstOrDefault();

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
            catch (ArgumentNullException ex)
            {
                _logger.Error("Could not save article with id=" + article.ID + "; 'Reason:" + ex.Message);
                throw new Exception("Could not save article with id");
            }
        }

        public Article GetById(int id)
        {
            return _databaseDriver.GetById(id);
        }
    }


}
