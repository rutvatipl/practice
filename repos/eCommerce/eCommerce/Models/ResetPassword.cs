using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class ResetPassword
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required..")]
        [DataType(DataType.Password)]
      
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "New password and cpassword do not match")]
        public string cpassword { get; set; }
        [Required]
        public string ResetPasswordCode { get; set; }
    }
}