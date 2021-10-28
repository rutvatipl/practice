using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    [MetadataType(typeof(customer_regmetadata))]
    public partial class customer_reg
    {
       
    }
    public partial class customer_regmetadata
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "First Name Required..")]
        public string fname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name Required..")]
        public string lname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id Required..")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "mobile no. Required..")]
        [DataType(DataType.PhoneNumber)]
        public string mobile { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required..")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "minimum 6 character is required")]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Confirm password and password do not match")]
        public string cpassword { get; set; }
        public string profile { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        
    }
}