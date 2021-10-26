using System;
using System.Configuration;

namespace TheShop
{
	internal class Program
	{
        static int counter = 0;
		private static void Main(string[] args)
		{
			ApiService.InitializeClient();
			var shopService = Factory.CreateShopService();

            StartProgram(shopService);

            Console.ReadKey();
		}

        private static void StartProgram(IShopService shopService)
        {
            if (counter > Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfPossibleLoop"]))
                Environment.Exit(0);

            Console.WriteLine("Please insert: 1 - For order and sell article, 2 - For display article, 0 - for exit program");
            var option = Console.ReadLine();

            if (Int32.TryParse(option, out var value))
            {
                switch (value)
                {
                    case (int)Option.Order:
                        OrderAndSell(shopService);
                        break;
                    case (int)Option.Display:
                        Display(shopService);
                        break;
                    case (int)Option.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        StartProgram(shopService);
                        break;
                }
            }
        }

        private static void OrderAndSell(IShopService shopService)
        {
            try
            {
                Article article = Factory.CreateArticle();
                Console.WriteLine("Please enter id of article that you search for:");
                var articleId = Console.ReadLine();

                if (Int32.TryParse(articleId, out var id))
                {
                    Console.WriteLine("Please enter the maximum price that you are willing to pay:");
                    var maxPrice = Console.ReadLine();
                    if (Int32.TryParse(maxPrice, out var maxExpectedPrice))
                        article =  shopService.OrderArticle(id, maxExpectedPrice).Result;
                }

                Console.WriteLine("Please enter id of buyer that you sell article:");
                var buyerIdentificator = Console.ReadLine();

                if (Int32.TryParse(buyerIdentificator, out var buyerId))
                    shopService.SellArticle(article, buyerId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                counter++;
                StartProgram(shopService);
            }
        }

        private static void Display(IShopService shopService)
		{
			try
			{
                Console.WriteLine("Please enter id of article that you search for:");
                var articleId = Console.ReadLine();
                if (Int32.TryParse(articleId, out var id))
                {
                    var article = shopService.GetById(id);
                    Console.WriteLine("Found article with ID: " + id);
                }
            }
			catch (Exception ex)
			{
				Console.WriteLine("Article not found: " + ex);
			}
            finally
            {
                counter++;
                StartProgram(shopService);
            }
        }
	}
}