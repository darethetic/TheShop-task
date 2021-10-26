using System.Threading.Tasks;

namespace TheShop
{
    public interface IShopService
    {
        Article GetById(int id);
        Task<Article> OrderArticle(int id, int maxExpectedPrice);
        void SellArticle(Article article, int buyerId);
    }
}