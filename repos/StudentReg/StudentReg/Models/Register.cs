//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentReg.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Register
    {
        [Required(ErrorMessage = " Id is Required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Firstname is Required")]
        [StringLength(10, MinimumLength = 5)]

        [RegularExpression(@"(\S\D)+", ErrorMessage = " Space and numbers not allowed")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname Id is Required")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Mobile  Id is Required")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Email Id is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Id is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Cpassword Id is Required")]
        [DataType(DataType.Password)]
        public string Cpassword { get; set; }
        [Required(ErrorMessage = "Profile Id is Required")]
        public string Profile { get; set; }
        [Required(ErrorMessage = "Gender Id is Required")]
        public string Gender { get; set; }
    }
}

