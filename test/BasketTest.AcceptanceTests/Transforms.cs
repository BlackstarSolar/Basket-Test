using System.Collections.Generic;
using System.Globalization;
using BasketTest;
using TechTalk.SpecFlow;

namespace BasketTest.AcceptanceTests
{
    [Binding]
    public class Transforms
    {
        [StepArgumentTransformation]
        public IEnumerable<LineItem> LineItemsTransform(Table itemsTable)
        {
            var factory = new ItemFactoryStrategyFactory();

            foreach (var row in itemsTable.Rows)
            {
                var name = row["Name"];
                var item = factory.CreateFromName(name).BuildFromRow(name, row);
                var quantity = uint.Parse(row["Quantity"], NumberStyles.Number);
                yield return new LineItem(item, quantity);
            }
        }

        private static Item ItemTransform(TableRow row)
        {
            var name = row["Name"];
            var price = decimal.Parse(row["Price"],
                NumberStyles.AllowCurrencySymbol | NumberStyles.Currency);
            var category = row.ContainsKey("Category") ? row["Category"] : null;
            return new Item(name, price, category);
        }

        [StepArgumentTransformation(@"(?:[a\d]\s)?£(\d{1,}\.\d{2})\sGift\sVoucher\s(\w{3}-\w{3})")]
        public GiftVoucher GiftVoucherTransform(decimal amount, string code)
        {
            return new GiftVoucher(code, amount);
        }

        [StepArgumentTransformation(@"(?:[a\d]\s)?£(\d{1,}\.\d{2})\soff\sbaskets\sover\s£(\d{1,}\.\d{2})\sOffer\sVoucher\s(\w{3}-\w{3})")]
        public OfferVoucher OfferVoucherTransform(decimal discount, decimal basketTotalThreshold, string code)
        {
            return new OfferVoucher(code, discount, basketTotalThreshold);
        }

        [StepArgumentTransformation(@"(?:[a\d]\s)?£(\d{1,}\.\d{2})\soff\s([\w\s]+)\sin\sbaskets\sover\s£(\d{1,}\.\d{2})\sOffer\sVoucher\s(\w{3}-\w{3})")]
        public OfferVoucher OfferVoucherWithRestrictionTransform(decimal discount, string restriction, decimal basketTotalThreshold, string code)
        {
            return new OfferVoucher(code, discount, basketTotalThreshold, restriction);
        }

        private class ItemFactoryStrategyFactory
        {
            public IItemFactory CreateFromName(string name)
            {
                name = name.ToUpperInvariant();
                switch (name)
                {
                    case "GIFT VOUCHER": return new GiftVoucherFactory();
                    default: return new StandardItemFactory();
                }
            }
        }

        private interface IItemFactory
        {
            Item BuildFromRow(string name, TableRow row);
        }

        private class StandardItemFactory : IItemFactory
        {
            public virtual Item BuildFromRow(string name, TableRow row)
            {
                var price = ParsePrice(row);
                var category = ExtractCategory(row);
                return new Item(name, price, category);
            }

            private static string ExtractCategory(TableRow row)
            {
                return row.ContainsKey("Category") ? row["Category"] : null;
            }

            protected static decimal ParsePrice(TableRow row)
            {
                return decimal.Parse(row["Price"],
                    NumberStyles.AllowCurrencySymbol | NumberStyles.Currency);
            }
        }

        private class GiftVoucherFactory : StandardItemFactory
        {
            public override Item BuildFromRow(string name, TableRow row)
            {
                var price = ParsePrice(row);
                return new BasketTest.GiftVoucher(name, price);
            }
        }
    }

    
}