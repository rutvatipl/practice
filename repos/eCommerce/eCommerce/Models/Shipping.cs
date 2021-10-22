using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class Shipping
    {
        public int shippingdetailid { get; set; }
        public int customer_id { get; set; }
        [Required(ErrorMessage = "Required...")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Required...")]
        public string city { get; set; }
        [Required(ErrorMessage = "Required...")]
        public string state { get; set; }
        [Required(ErrorMessage = "Required...")]
        public string country { get; set; }
        [Required(ErrorMessage = "Required...")]
        public string zipcode { get; set; }
        [Required(ErrorMessage = "Required...")]
        public int order_id { get; set; }
        [Required(ErrorMessage = "Required...")]
        public decimal amountpaid { get; set; }
        [Required(ErrorMessage = "Required...")]
        public string paymenttype { get; set; }
    }
}