using System.Collections.Generic;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.ApplicationClass.DTO.LoginDTO;
using UserAuthenticationApplication.DomainModel.Models.UserHistory;

namespace UserAuthenticationApplication.Repository.Login
{
    public interface ILoginRepository
    {
        /// <summary>
        /// Fetch the AllUser details 
        /// </summary>
        /// <returns>Fetch the details from the database</returns>
      //  Task<List<UserRagistrationDetail>> GetAllUserAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<LoginDetailDTO>> GetUserSpecificDetailsAsync(int userId);

        /// <summary>
        /// Add User 
        /// </summary>
        /// <param name="user">Add New user or ragesterd in Stors</param>
        /// <returns>Add New User Ragistration In database</returns>
        Task<LoginDetailDTO> AddloginUserAsync(string emailId, string passcode);

        Task<UserHistory> GetUserCountAsync(int userId);
        Task<List<UserHistory>> GetAllUserCountAsync();
    }
}
