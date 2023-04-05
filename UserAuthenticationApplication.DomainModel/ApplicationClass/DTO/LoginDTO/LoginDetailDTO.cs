using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserAuthenticationApplication.DomainModel.ApplicationClass.DTO.LoginDTO
{
    public class LoginDetailDTO
    {
        public int LoginId { get; set; }

        public int UserId { get; set; }

        public DateTime LoginHistory { get; set; }

        public bool IsValidate { get; set; }
    }
}
