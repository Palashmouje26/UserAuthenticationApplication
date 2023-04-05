using System.Collections.Generic;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.ApplicationClass.DTO.UserRagistrationDTO;

namespace UserAuthenticationApplication.Repository.User
{
    public interface IUserRegistrationRepository
    {
        /// <summary>
        /// Fetch the AllUser details 
        /// </summary>
        /// <returns>Fetch the details from the database</returns>
        Task<List<UserRagistrationDetailDTO>> GetAllUserAsync();
        /// <summary>
        /// Fetch the User details of the Perticular user 
        /// </summary>
        /// <param name="UserId">Get perticlar user deatails in the stores</param>
        /// <returns>Fetch the details from the database</returns>
        Task<UserRagistrationDetailDTO> GetUserByIdAsync(int UserId);
        /// <summary>
        /// Add User Ragistration
        /// </summary>
        /// <param name="user">Add New user or ragesterd in Stors</param>
        /// <returns>Add New User Ragistration </returns>
        Task<UserRagistrationDetailDTO> AddUserAsync(UserRagistrationDetailDTO user);
        /// <summary>
        /// Change new User Detail.
        /// </summary>
        /// <param name="user">Stores the name of the current user.</param>
        /// <returns>Update UserName ,EmailId and Password In database.</returns>
        Task<UserRagistrationDetailDTO> UpdateUserAsync(UserRagistrationDetailDTO user);
        /// <summary>
        /// Remove or In-active the user.
        /// </summary>
        /// <param name="UserId">Store the data changes in current user</param>
        /// <returns>Remove or inactive the user by userId </returns>
        Task RemoveUserAsync(int UserId);
        
    }
}
