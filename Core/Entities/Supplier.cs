using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public class Supplier : ISupplier
    {
		public int SupplierId { get; set; }
		public string SupplierName { get; set; }

		public List<Article> Articles { get; set; }

		IArticle _article;
		List<Article> articles = new List<Article>();
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

		public List<Article> GetAllSuppliers()
        {
			articles = _databaseDriver.GetAll();

			return articles;
		}
    }

	public class Supplier1
	{
		public bool ArticleInInventory(int id)
		{
			return true;
		}

		public Article GetArticle(int id)
		{
			return new Article()
			{
				ID = 1,
				NameOfArticle = "Article from supplier1",
				ArticlePrice = 458
			};
		}
	}

	public class Supplier2
	{
		public bool ArticleInInventory(int id)
		{
			return true;
		}

		public Article GetArticle(int id)
		{
			return new Article()
			{
				ID = 1,
				NameOfArticle = "Article from supplier2",
				ArticlePrice = 459
			};
		}
	}

	public class Supplier3
	{
		public bool ArticleInInventory(int id)
		{
			return true;
		}

		public Article GetArticle(int id)
		{
			return new Article()
			{
				ID = 1,
				NameOfArticle = "Article from supplier3",
				ArticlePrice = 460
			};
		}
	}
}
