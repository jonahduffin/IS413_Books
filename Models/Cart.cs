using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JonahsBooks.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Book bookToAdd, int qtyToAdd)
        {
            CartLine line = Lines
                .Where(b => b.Book.BookID == bookToAdd.BookID)
                .FirstOrDefault();
            // If book hasn't been added yet, add it to the cart
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = bookToAdd,
                    Quantity = qtyToAdd
                });
            }
            // If the book is already in the cart, increase the quantity
            else
            {
                line.Quantity += qtyToAdd;
            }

        }

        public virtual void RemoveLine(Book bookToRemove) =>
            Lines.RemoveAll(x => x.Book.BookID == bookToRemove.BookID);

        public virtual void ClearCart() => Lines.Clear();

        public decimal ComputeTotalSum() =>
            Lines.Sum(e => Convert.ToDecimal(e.Book.price) * e.Quantity);

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
