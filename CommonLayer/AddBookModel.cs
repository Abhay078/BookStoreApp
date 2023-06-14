using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class AddBookModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public long Price { get; set; }
        public long DiscountedPrice { get; set; }
        public string BookImage { get; set; }
        public int Quantity { get; set; }
    }
}
