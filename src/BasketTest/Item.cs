using System;
using System.Collections.Generic;
using System.Linq;

namespace BasketTest
{
    public class Item
    {
        public Item(string name, decimal price, params string[] categories)
        {
            Name = name;
            Price = price;
            Categories = categories.Where(c => !string.IsNullOrWhiteSpace(c)).ToArray();
        }

        public string Name { get; }

        public decimal Price { get; }

        public IEnumerable<string> Categories { get; }

        public virtual bool IsDiscountable => true;

        public virtual bool CanRedeemGiftVouchersAgainst => true;
    }
}