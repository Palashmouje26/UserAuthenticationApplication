using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UserAuthenticationApplication.DomainModel.Models.UserRegistration;
using UserAuthenticationApplication.DomainModel.Models.UserRegistrationDetail;

namespace UserAuthenticationApplication.Repository.Login
{
    public class Login
    {
        [Key]
        public int LoginId  { get; set;}

       
        [ForeignKey("UserId")]
        public string UserId { get; set;}
        public virtual UserRegistration UserRagistration { get; set; }
        public DateTime LoginHistory { get; set;}   
        public bool IsValidate { get; set;}


    }
}
