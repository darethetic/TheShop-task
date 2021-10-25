using System;

namespace TheShop
{
    public class Article
    {
        public int ID { get; set; }
        public string NameOfArticle { get; set; }
        public double ArticlePrice { get; set; }
        public bool IsSold { get; set; }
        public DateTime SoldDate { get; set; }
        public int BuyerUserId { get; set; }
    }
}
