using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.Models.UserRegistrationDetail;

namespace UserAuthenticationApplication.Repository.Login
{
    public class LoginRepository : ILoginRepository
    {
        public Task<UserRagistrationDetail> AddUserAsync(UserRagistrationDetail user)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserRagistrationDetail>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserRagistrationDetail> GetUserByIdAsync(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
