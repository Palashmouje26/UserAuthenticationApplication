using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        /// <summary>
        /// Fetch the User details of the Perticular user 
        /// </summary>
        /// <param name="UserId">Get perticlar user deatails in the stores</param>
        /// <returns>Fetch the details from the database</returns>
        Task<UserRagistrationDetail> GetUserByIdAsync(int UserId);
        /// <summary>
        /// Add User 
        /// </summary>
        /// <param name="user">Add New user or ragesterd in Stors</param>
        /// <returns>Add New User Ragistration In database</returns>
        Task<UserRagistrationDetail> AddUserAsync(UserRagistrationDetail user);
        
    }
}
