using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class AddOrderModel
    {
        public DateTime CreatedDate { get; set; }
        public List<int> BookIds { get; set; }
    }
}
