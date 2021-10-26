using System;
using System.Threading.Tasks;

namespace TheShop
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			ApiService.InitializeClient();
			var shopService = Factory.CreateShopService();

            OrderAndSell(shopService);            
            
            Display(shopService);

            Console.ReadKey();
		}

		private async static void OrderAndSell(IShopService shopService)
		{
			try
			{
                var article = shopService.OrderArticle(1, 500).Result;
                shopService.SellArticle(article, 10);

                //Article article = Factory.CreateArticle();
                //Console.WriteLine("Please enter id of article that you search for:");
                //var articleId = Console.ReadLine();

                //if (Int32.TryParse(articleId, out var id))
                //{
                //    Console.WriteLine("Please enter the maximum price that you are willing to pay:");
                //    var maxPrice = Console.ReadLine();
                //    if (Int32.TryParse(maxPrice, out var maxExpectedPrice))
                //        article = await shopService.OrderArticle(id, maxExpectedPrice);
                //}

                //Console.WriteLine("Please enter id of buyer that you sell article:");
                //var buyerIdentificator = Console.ReadLine();

                //if (Int32.TryParse(buyerIdentificator, out var buyerId))
                //    shopService.SellArticle(article, buyerId);
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

		}

		private static void Display(IShopService shopService)
		{
			try
			{
                var article = shopService.GetById(1);
                Console.WriteLine("Found article with ID: " + article.Id);

                //Console.WriteLine("Please enter id of article that you search for:");
                //var articleId = Console.ReadLine();
                //if (Int32.TryParse(articleId, out var id))
                //{
                //    var article = shopService.GetById(id);
                //    Console.WriteLine("Found article with ID: " + id);
                //}

            }
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}
		}
	}
}