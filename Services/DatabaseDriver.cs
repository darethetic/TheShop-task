using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public class DatabaseDriver : IDatabaseDriver
    {
        private List<Article> _articles = new List<Article>();
        private List<Supplier> _suppliers = new List<Supplier>();

        public Article GetById(int id)
        {
            return _articles.Single(x => x.ID == id);
        }

        public void Save(Article article)
        {
            _articles.Add(article);
        }

        public List<Article> GetAll()
        {
            return _articles;
        }

        public List<Supplier> GetAllSuppliers()
        {
            return new List<Supplier>()
            {
                new Supplier()
            };
        }
    }
}
