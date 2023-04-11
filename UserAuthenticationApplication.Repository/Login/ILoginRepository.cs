using System.Collections.Generic;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.ApplicationClass.DTO.LoginDTO;
using UserAuthenticationApplication.DomainModel.Models.UserHistory;

namespace UserAuthenticationApplication.Repository.Login
{
    public interface ILoginRepository
    {

        /// <summary>
        ///  List of  All User details at a time.
        /// </summary>
        /// <param name="userId">userId of the current user.</param>
        /// <returns> return List of user login details.</returns>
        Task<List<LoginDetailDTO>> GetUserSpecificDetailsAsync(int userId);

        /// <summary>
        /// Adding user by login method.
        /// </summary>
        /// <param name="emailId">emailid is used for checking particular user email.</param>
        /// <param name="password"> passcode is used for checking particular user password</param>
        /// <returns> return user login </returns>
        Task<LoginDetailDTO> AddloginUserAsync(string emailId, string password);

        /// <summary>
        /// Show user login details and last login time.
        /// </summary>
        /// <param name="userId"> userId is user for current user.</param>
        /// <returns>return object</returns>
        Task<UserHistory> GetUserCountAsync(int userId);

        /// <summary>
        /// List to show all the users count of login and last lagin.
        /// </summary>
        /// <returns>return list of count.</returns>
        Task<List<UserHistory>> GetAllUserCountAsync();
    }
}
