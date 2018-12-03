using FluentAssertions;
using NUnit.Framework;

namespace BasketTest.UnitTests
{
    public class BasketTests
    {
        private Basket _target;

        private static readonly Item Hat = new Item("Hat", 9.99m);

        private static readonly Item Jumper = new Item("Jumper", 2.22m);

        [SetUp]
        public void SetUp()
        {
            _target = new Basket();
        }

        [Test]
        public void Basket_total_is_zero_when_no_lines()
        {
            _target.Total.Should().Be(0);
        }

        [Test]
        public void Basket_total_is_sum_of_line_items_when_no_vouchers_have_been_applied()
        {
            _target.Add(new LineItem(Hat, 1));
            _target.Add(new LineItem(Jumper, 2));

            _target.Total.Should().Be(14.43m);
        }

        [Test]
        public void Basket_total_updates_as_items_are_added()
        {
            _target.Add(new LineItem(Hat, 1));

            _target.Total.Should().Be(9.99m);

            _target.Add(new LineItem(Jumper, 1));

            _target.Total.Should().Be(12.21m);
        }

        [Test]
        public void Basket_total_updates_as_items_are_removed()
        {
            var oneHat = new LineItem(Hat, 1);
            _target.Add(oneHat);

            _target.Total.Should().Be(9.99m);

            _target.Remove(oneHat);

            _target.Total.Should().Be(0);
        }

        [Test]
        public void Gift_voucher_does_not_reduce_price_of_gift_voucher()
        {
            _target.Add(new LineItem(new GiftVoucher("ABC", 25m)));

            _target.Apply(new GiftVoucher("XXX", 10m));

            _target.Total.Should().Be(25m);
        }
    }
}
