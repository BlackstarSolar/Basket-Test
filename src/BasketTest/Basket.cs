using System;
using System.Collections.Generic;
using System.Linq;

namespace BasketTest
{
    public class Basket
    {
        private readonly IList<LineItem> _lines = new List<LineItem>();

        private readonly IList<GiftVoucher> _giftVouchers = new List<GiftVoucher>();

        public Basket()
        {
            Changed += Basket_Changed;
        }

        public decimal Total { get; private set; }

        private void Basket_Changed(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private event EventHandler Changed;

        private void OnChanged(EventArgs e)
        {
            Changed?.Invoke(this, e);
        }

        public void Add(LineItem line)
        {
            if (line == null) return;

            _lines.Add(line);
            OnChanged(new EventArgs());
        }

        public void Remove(LineItem line)
        {
            if (line == null) return;

            _lines.Remove(line);

            OnChanged(new EventArgs());
        }

        public void Apply(GiftVoucher voucher)
        {
            if (voucher == null) return;

            _giftVouchers.Add(voucher);

            OnChanged(new EventArgs());
        }

        private void CalculateTotal()
        {
            var giftVoucherReducibleSubTotal = _lines.Where(l => l.Item.CanRedeemGiftVouchersAgainst).Sum(l => CalculatePrice(l));

            var giftVoucherTotal = _giftVouchers.Sum(g => g.Amount);

            var giftVoucherReduction = Math.Min(giftVoucherReducibleSubTotal, giftVoucherTotal);

            var nonGiftVoucherReducibleSubTotal = _lines.Where(l => !l.Item.CanRedeemGiftVouchersAgainst).Sum(l => CalculatePrice(l));

            Total = giftVoucherReducibleSubTotal + nonGiftVoucherReducibleSubTotal - giftVoucherReduction;
        }

        private static decimal CalculatePrice(LineItem l)
        {
            return l.Item.Price * l.Quantity;
        }
    }
}