using System.Collections.Generic;

namespace TheShop
{
    public interface IDatabaseDriver
    {
        Article GetById(int id);
        void Save(Article article);
        List<Article> GetAll();
    }
}