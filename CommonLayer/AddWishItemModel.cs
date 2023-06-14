using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer
{
    public class AddWishItemModel
    {
        public long UserId { get; set; }
        public int BookId { get; set; }
    }
}
