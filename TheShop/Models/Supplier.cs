using System.Collections.Generic;

namespace TheShop
{
    public class Supplier
    {
		public int SupplierId { get; set; }
        public Dictionary<Article, bool> Articles { get; set; }
    }
}
