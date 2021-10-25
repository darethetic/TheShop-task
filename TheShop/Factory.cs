using System;
using TheShop.Services;
using TheShop.Services.Interfaces;

namespace TheShop
{
    public static class Factory
    {
        public static Article CreateArticle()
        {
            return new Article();
        }

        public static ILogger CreateLogger()
        {
            return new Logger();
        }

        public static Supplier CreateSupplier()
        {
            return new Supplier();
        }

        public static IDatabaseDriver CreateDatabaseDriver()
        {
            return new DatabaseDriver();
        }

        public static ISupplierService CreateSupplierService()
        {
            return new SuppllierService();
        }

        public static IShopService CreateShopService()
        {
            return new ShopService(CreateLogger(), CreateDatabaseDriver(), CreateSupplierService());
        }
    }
}
