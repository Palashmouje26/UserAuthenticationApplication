using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.Models.LoginDetails;
using UserAuthenticationApplication.DomainModel.Models.UserRegistrationDetail;

namespace UserAuthenticationApplication.Repository.Login
{
    public interface ILoginRepository
    {
        /// <summary>
        /// Fetch the AllUser details 
        /// </summary>
        /// <returns>Fetch the details from the database</returns>
        Task<List<UserRagistrationDetail>> GetAllUserAsync();


        Task<List<LoginDetail>> GetUserSpecificDetails(int userId);



        /// <summary>
        /// Add User 
        /// </summary>
        /// <param name="user">Add New user or ragesterd in Stors</param>
        /// <returns>Add New User Ragistration In database</returns>
        Task<LoginDetail> AddloginUserAsync(string emailId, string passcode);

    }
}
