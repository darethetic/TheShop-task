﻿using System.Threading.Tasks;
using TheShop.Dtos;

namespace TheShop
{
    public interface IShopService
    {
        Article GetById(int id);
        Task<ArticleDto> OrderArticle(int id, int maxExpectedPrice);
        void SellArticle(Article article, int buyerId);
    }
}