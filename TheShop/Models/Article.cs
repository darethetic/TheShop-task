using System;

namespace TheShop
{
    public class Article
    {
        public int Id { get; set; }
        public string NameOfArticle { get; set; }
        public double Price { get; set; }
        public bool IsSold { get; set; }
        public DateTime SoldDate { get; set; }
        public int BuyerUserId { get; set; }
    }
}
