namespace TheShop
{
    public interface IShopService
    {
        Article GetById(int id);
        void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId);
    }
}