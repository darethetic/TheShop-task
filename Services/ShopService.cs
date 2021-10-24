using System;
using System.Collections.Generic;
using System.Linq;

namespace TheShop
{
    public class ShopService : IShopService
    {
        private IDatabaseDriver _databaseDriver;
        private ILogger _logger;

        private ISupplier _supplier1;
        private ISupplier _supplier2;
        private ISupplier _supplier3;

        public ShopService(ILogger logger, IDatabaseDriver databaseDriver, ISupplier supplier1, ISupplier supplier2, ISupplier supplier3)
        {
            _databaseDriver = databaseDriver;
            _logger = logger;
            _supplier1 = supplier1;
            _supplier2 = supplier2;
            _supplier3 = supplier3;
        }

        public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
        {
            #region ordering article
            // Dovuci sve dobaljvace
            // Prodji kroz svaki od njih i proveri da li imaju trazeni artikal
            // Napravi novu orderovanu listu sa dobavljacima koji imaju trazeni artikal po ceni
            Article article = null;
            Article tempArticle = null;
            var articleExists = _supplier1.ArticleInInventory(id);
            if (articleExists)
            {
                tempArticle = _supplier1.GetArticle(id);
                if (maxExpectedPrice < tempArticle.ArticlePrice)
                {
                    articleExists = _supplier2.ArticleInInventory(id);
                    if (articleExists)
                    {
                        tempArticle = _supplier2.GetArticle(id);
                        if (maxExpectedPrice < tempArticle.ArticlePrice)
                        {
                            articleExists = _supplier3.ArticleInInventory(id);
                            if (articleExists)
                            {
                                tempArticle = _supplier3.GetArticle(id);
                                if (maxExpectedPrice < tempArticle.ArticlePrice)
                                {
                                    article = tempArticle;
                                }
                            }
                        }
                    }
                }
            }

            article = tempArticle;
            #endregion

            #region selling article

            if (article == null)
            {
                throw new Exception("Could not order article");
            }

            _logger.Debug("Trying to sell article with id=" + id);

            article.IsSold = true;
            article.SoldDate = DateTime.Now;
            article.BuyerUserId = buyerId;

            try
            {
                _databaseDriver.Save(article);
                _logger.Info("Article with id=" + id + " is sold.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error("Could not save article with id=" + id);
                throw new Exception("Could not save article with id");
            }
            catch (Exception)
            {
            }

            #endregion
        }

        public Article GetById(int id)
        {
            return _databaseDriver.GetById(id);
        }
    }


}
