using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuthenticationApplication.DomainModel.Models.UserHistory
{
    public class UserHistory
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int countOfSuccess { get; set; }
        public int countOfFailure { get; set;}
        public DateTime? LastSuccess { get; set; }
    }
}
