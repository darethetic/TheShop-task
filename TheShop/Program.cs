using System;

namespace TheShop
{
    internal class Program
	{
		private static void Main(string[] args)
		{
			Service.InitializeClient();
            var shopService = Factory.CreateShopService();

			StartProgram(shopService);

			Console.ReadKey();
		}

		private static void StartProgram(IShopService shopService)
        {
			Console.WriteLine("Please insert: order - For order and sell article, display - For display article");
			var option = Console.ReadLine();

			switch (option)
			{
				case "order":
					OrderAndSell(shopService);
					break;
				case "display":
					Display(shopService);
					break;
				default:
					StartProgram(shopService);
					break;
			}
		}

		private async static void OrderAndSell(IShopService shopService)
		{
			try
			{
				//order and sell
				var article = await shopService.OrderArticle(1, 200);
				shopService.SellArticle(article, 10);
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
				//print article on console
				var article = shopService.GetById(1);
				Console.WriteLine("Found article with ID: " + article.ID);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}
		}
    }
}