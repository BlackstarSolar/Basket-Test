namespace BasketTest
{
    public class OfferVoucher
    {
        public OfferVoucher(string code, decimal discount, decimal basketTotalThreshold)
        {
            Code = code;
            Discount = discount;
            BasketTotalThreshold = basketTotalThreshold;
        }

        public string Code { get; }

        public decimal Discount { get; }

        public decimal BasketTotalThreshold { get; }
    }
}