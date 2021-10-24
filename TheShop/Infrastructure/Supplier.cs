using System.Collections.Generic;

namespace TheShop
{
    public class Supplier : ISupplier
    {
		public int SupplierId { get; set; }
		public string SupplierName { get; set; }

		public List<Article> Articles { get; set; }

		IArticle _article;

		IDatabaseDriver _databaseDriver = Factory.CreateDatabaseDriver();
        public Supplier(IArticle article)
        {
			_article = article;
        }
        public bool ArticleInInventory(int id)
        {
			var isInInventory = false;
			var article =_databaseDriver.GetById(id);
			if (article != null)
				isInInventory = true;
			return isInInventory;
        }

        public Article GetArticle(int id)
        {
			return _article as Article;
        }
    }
}
