namespace BasketTest
{
    public class GiftVoucher
    {
        public GiftVoucher(string code, decimal amount)
        {
            Code = code;
            Amount = amount;
        }

        public string Code { get; }

        public decimal Amount { get; }
    }
}