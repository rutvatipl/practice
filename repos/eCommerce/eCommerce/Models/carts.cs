using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.Models
{
    public class carts
    {
       
        public int product_id { get; set; }
        public string p_name { get; set; }
        public int cartstatusid { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> price { get; set; }
        public Nullable<int> bill { get; set; }
    }
}