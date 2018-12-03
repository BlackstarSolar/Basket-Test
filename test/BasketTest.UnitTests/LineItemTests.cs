using FluentAssertions;
using NUnit.Framework;

namespace BasketTest.UnitTests
{
    public class LineItemTests
    {
        [Test]
        public void Price_is_item_price_multiplied_by_quantity()
        {
            var target = new LineItem(new Item("abc", 10), 5);

            target.Price.Should().Be(50);
        }
    }
}