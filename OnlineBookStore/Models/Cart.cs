using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace OnlineBookStore.Models
{
    public class Cart
    {
        //first part declares, second part instantiates
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        public void AddItem (Book bookItem, int qty)
        {
            CartLineItem line = Items
                .Where(b => b.Book.BookId == bookItem.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new CartLineItem
                {
                    Book = bookItem,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity = line.Quantity + qty;
            }
        }

        //function to calculate cart total
        public double CalculateTotal()
        {
            double subtotal = Items.Sum(x => x.Quantity * x.Book.Price);

            return subtotal;
        }
    }

    public class CartLineItem
    {
        public int LineId { get; set; }
        public Book Book { get; set; } //instance of the "Book" type
        public int Quantity { get; set; }
    }
}
