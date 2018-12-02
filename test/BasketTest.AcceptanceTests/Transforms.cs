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
            foreach (var row in itemsTable.Rows)
            {
                var item = ItemTransform(row);
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
            return new OfferVoucher(code, discount, basketTotalThreshold);
        }
    }
}