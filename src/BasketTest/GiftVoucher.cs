namespace BasketTest
{
    public class GiftVoucher : Item
    {
        public GiftVoucher(string code, decimal amount) : base("Gift Voucher", amount)
        {
            Code = code;
        }

        public string Code { get; }

        public decimal Amount => Price;

        public override bool IsDiscountable => false;

        public override bool CanRedeemGiftVouchersAgainst => false;
    }
}