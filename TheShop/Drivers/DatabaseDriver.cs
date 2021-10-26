using System.Collections.Generic;
using System.Linq;

namespace TheShop
{
    public class DatabaseDriver : IDatabaseDriver
    {
        private List<Article> _articles = new List<Article>();

        public Article GetById(int id)
        {
            return _articles.Single(a => a.Id == id);
        }

        public void Save(Article article)
        {
            _articles.Add(article);
        }
    }
}