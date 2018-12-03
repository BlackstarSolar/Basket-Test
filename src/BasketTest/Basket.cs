using System;
using System.Collections.Generic;
using System.Linq;

namespace BasketTest
{
    public class Basket
    {
        private readonly IList<LineItem> _lines = new List<LineItem>();
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

        private void CalculateTotal()
        {
            Total = _lines.Sum(l => l.Quantity * l.Item.Price);
        }
    }
}