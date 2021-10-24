using System;

namespace TheShop
{
    public interface IArticle
    {
        int ArticlePrice { get; set; }
        int BuyerUserId { get; set; }
        int ID { get; set; }
        bool IsSold { get; set; }
        string NameOfArticle { get; set; }
        DateTime SoldDate { get; set; }
    }
}