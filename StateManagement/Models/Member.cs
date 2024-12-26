using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StateManagement.Models
{
    public class Member
    {
        [Display(Name = "Member's Name")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name can't be empty")]
        [RegularExpression(@"^[a-zA-Z]{3,}$", ErrorMessage = "Name should meet the requirements")]
        public string Name { get; set; }


        [Display(Name = "Activation Code")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid activation code")]
        public string ActivationCode { get; set; }

        [Display(Name = "National Insurance Number")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid National Insurance Number")]
        public string Nino { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter your date of birth")]
        public DateTime DOB { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Display(Name = "Confirm Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please confirm your email address here")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password can't be empty")]
        // [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[^\da-zA-Z]).{8}$", ErrorMessage = "Password must meet the requirements")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please confirm your password here")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set;}

        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address {  get; set; }
    }
}