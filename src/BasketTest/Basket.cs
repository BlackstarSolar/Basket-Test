using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BasketTest
{
    public class Basket
    {
        private static readonly CultureInfo MessageCulture = CultureInfo.GetCultureInfo("en-GB");

        private readonly IList<LineItem> _lines = new List<LineItem>();

        private readonly IList<GiftVoucher> _giftVouchers = new List<GiftVoucher>();

        private OfferVoucher _offerVoucher;

        private readonly IList<string> _messages = new List<string>();

        public Basket()
        {
            Changed += Basket_Changed;
        }

        public decimal Total { get; private set; }

        public IEnumerable<string> Messages => _messages;

        private void Basket_Changed(object sender, EventArgs e)
        {
            ClearMessages();
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

        public void Apply(OfferVoucher voucher)
        {
            _offerVoucher = voucher;

            OnChanged(new EventArgs());
        }

        private void CalculateTotal()
        {
            var giftVoucherReducibleSubTotal = _lines.Where(l => l.Item.CanRedeemGiftVouchersAgainst).Sum(l => l.Price);

            var giftVoucherTotal = _giftVouchers.Sum(g => g.Amount);

            var giftVoucherReduction = Math.Min(giftVoucherReducibleSubTotal, giftVoucherTotal);

            var nonGiftVoucherReducibleSubTotal =
                _lines.Where(l => !l.Item.CanRedeemGiftVouchersAgainst).Sum(l => l.Price);

            var subTotal = giftVoucherReducibleSubTotal + nonGiftVoucherReducibleSubTotal;

            var offerVoucherReduction = CalculateOfferVoucherReduction();

            Total = subTotal - giftVoucherReduction - offerVoucherReduction;
        }

        private decimal CalculateOfferVoucherReduction()
        {
            var subTotal = _lines.Where(l => l.Item.IsDiscountable).Sum(l => l.Price);

            if (_offerVoucher == null)
            {
                return 0;
            }

            var thresholdDelta = _offerVoucher.BasketTotalThreshold - subTotal;

            if (thresholdDelta > 0)
            {
                var additionalSpend = thresholdDelta + 0.01m;

                var message = string.Format(MessageCulture,
                    "You have not reached the spend threshold for voucher {0:C}. Spend another {1:C} to receive {2:C} discount from your basket total.",
                    _offerVoucher.Code, additionalSpend, _offerVoucher.Discount);

                _messages.Add(message);

                return 0;
            }

            var offerVoucherReduction = _offerVoucher.Discount;

            if (!_offerVoucher.IsRestrictedToCategory)
            {
                return offerVoucherReduction;
            }

            var applicableLines = _lines.Where(l => l.Item.Categories.Contains(_offerVoucher.RestrictedToCategory))
                .ToArray();

            if (!applicableLines.Any())
            {
                var message = string.Format(MessageCulture,
                    "There are no products in your basket applicable to voucher Voucher {0} .",
                    _offerVoucher.Code);

                _messages.Add(message);

                return 0;
            }

            offerVoucherReduction = Math.Min(applicableLines.Sum(l => l.Price), offerVoucherReduction);

            return offerVoucherReduction;
        }

        private void ClearMessages()
        {
            _messages.Clear();
        }
    }
}