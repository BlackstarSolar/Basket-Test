namespace BasketTest
{
    public class OfferVoucher
    {
        public OfferVoucher(string code, decimal discount, decimal basketTotalThreshold)
            : this(code, discount, basketTotalThreshold, null)
        {
        }

        public OfferVoucher(string code, decimal discount, decimal basketTotalThreshold, string restrictedToCategory)
        {
            Code = code;
            Discount = discount;
            BasketTotalThreshold = basketTotalThreshold;
            RestrictedToCategory = restrictedToCategory;
        }

        public string Code { get; }

        public decimal Discount { get; }

        public decimal BasketTotalThreshold { get; }

        public string RestrictedToCategory { get; }

        public bool IsRestrictedToCategory => !string.IsNullOrWhiteSpace(RestrictedToCategory);
    }
}