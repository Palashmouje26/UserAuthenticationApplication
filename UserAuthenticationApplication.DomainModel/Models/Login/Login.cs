using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserAuthenticationApplication.DomainModel.Models.UserRegistration;

namespace UserAuthenticationApplication.Repository.Login
{
    public class Login
    {
        [Key]
        public int LoginId  { get; set;}

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserRegistration UserRagistration { get; set; }

        public DateTime LoginHistory { get; set;}   

        public bool IsValidate { get; set;}

       

    }
}
