using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserAuthenticationApplication.DomainModel.Models.UserRegistration
{
    public class UserRegistration
    {
        [Key]
        public int UserId { get; set; }

        [Required]

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters are not allowed.")]
        public string UserName { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }

        public string Address { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required]

        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,14})+$", ErrorMessage = "Password must be alphanumeric including at least 1 uppercase letter,1 lowercase letter and a special character with 8 to 14 characters")]
        public string Password { get; set; }

        public bool IsDeletd { get; set; }
    }
}
