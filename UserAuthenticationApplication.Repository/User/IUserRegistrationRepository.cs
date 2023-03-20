using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.Models.UserRegistrationDetail;

namespace UserAuthenticationApplication.Repository.User
{
     public interface IUserRegistrationRepository
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
        /// <summary>
        /// Change new UserName,EmailId &passwor
        /// </summary>
        /// <param name="user">Stores the name of the current user</param>
        /// <parm name="model">Take parameter of type Changes which has the new UserName,EmailId & password of the user</parm>Stores the name of the current user</param>
        /// <returns>Update UserName ,EmailId and Password In database</returns>
        Task<UserRagistrationDetail> UpdateUserAsync(UserRagistrationDetail user);
        /// <summary>
        /// Remove or In-active the user
        /// </summary>
        /// <param name="UserId">store the data changes in current user</param>
        /// <returns>Remove or inactive the user by userId </returns>
        Task RemoveSoftdeleteAsync(int UserId);
        
    }
}
