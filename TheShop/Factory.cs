using System;
namespace TheShop
{
    public static class Factory
    {
        public static IArticle CreateArticle()
        {
            return new Article();
        }

        public static ILogger CreateLogger()
        {
            return new Logger();
        }

        public static ISupplier CreateSupplier()
        {
            return new Supplier(CreateArticle());
        }

        public static IDatabaseDriver CreateDatabaseDriver()
        {
            return new DatabaseDriver();
        }

        public static IShopService CreateShopService()
        {
            return new ShopService(CreateLogger(), CreateDatabaseDriver());
        }
    }
}
