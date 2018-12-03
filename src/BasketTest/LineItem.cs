namespace BasketTest
{
    public class LineItem
    {
        public LineItem(Item item, uint quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        public LineItem(Item item)
            : this(item, 1)
        {
        }

        public Item Item { get; }

        public uint Quantity { get; set; }

        public decimal Price => Item.Price * Quantity;
    }
}