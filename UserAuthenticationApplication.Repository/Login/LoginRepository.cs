using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.ApplicationClass.DTO.LoginDTO;
using UserAuthenticationApplication.DomainModel.Models.UserHistory;
using UserAuthenticationApplication.DomainModel.Models.UserRegistration;
using UserAuthenticationApplication.Repository.DataRepository;
using UserAuthenticationApplication.Repository.User;

namespace UserAuthenticationApplication.Repository.Login
{
    public class LoginRepository : ILoginRepository
    {

        #region Private Methods
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public LoginRepository(IDataRepository dataRepository, IMapper mapper)
        {
            _mapper = mapper;
            _dataRepository = dataRepository;
        }
        #endregion

        #region Public Methods
        /// <summary>
        ///  List of  All User details at a time.
        /// </summary>
        /// <param name="userId">userId of the current user.</param>
        /// <returns>object return</returns>
        public async Task<List<LoginDetailDTO>> GetUserSpecificDetailsAsync(int userId)
        {
            var userDetails = await _dataRepository.Where<Login>(a => a.UserId == userId).AsNoTracking().ToListAsync();
            return _mapper.Map<List<Login>, List<LoginDetailDTO>>(userDetails);

        }

        /// <summary>
        /// Adding and Checking User Validdate Or not If Valid Then store in data.
        /// </summary>
        /// <param name="emailId">Current User emailID.</param>
        /// <param name="password">Current user Password.</param>
        /// <returns>User Valid or not retrun.</returns>

        public async Task<LoginDetailDTO> AddloginUserAsync(string emailId, string password)
        {
            Login loginDetail = new Login();
            loginDetail.LoginHistory = DateTime.Now;

            var userDetail = await _dataRepository.FirstOrDefaultAsync<UserRegistration>(authUser => authUser.EmailId.Equals(emailId) && authUser.Password.Equals(password));

            if (userDetail != null)
            {
                loginDetail.UserId = userDetail.UserId;
                loginDetail.IsValidate = true;
            }
            else
            {
                var response = await _dataRepository.FirstOrDefaultAsync<UserRegistration>(x => x.EmailId == emailId);
                loginDetail.UserId = response.UserId;
                loginDetail.IsValidate = false;
            }
            await _dataRepository.AddAsync(loginDetail);
            return _mapper.Map<LoginDetailDTO>(loginDetail);

        }

        /// <summary>
        /// Show user login details and last login time.
        /// </summary>
        /// <param name="userId"> userId is user for current user.</param>
        /// <returns>User List</returns>
        public async Task<UserHistory> GetUserCountAsync(int userId)
        {
            return await GetUserHistory(userId);
        }

        /// <summary>
        /// List to show all the users count of login and last lagin.
        /// </summary>
        /// <returns>List return.</returns>
        public async Task<List<UserHistory>> GetAllUserCountAsync()
        {
            var userList = await _dataRepository.GetAllAsync<UserRegistration>();

            var loginHistory = await _dataRepository.GetAllAsync<Login>();

            return userList.Select(x => new UserHistory
            {
                UserId = x.UserId,
                UserName = x.UserName,
                countOfFailure = loginHistory.Where(a => a.UserId == x.UserId && !a.IsValidate).Count(),
                countOfSuccess = loginHistory.Where(a => a.UserId == x.UserId && a.IsValidate).Count(),
                LastSuccess = GetUserHistory(loginHistory, x.UserId),

            }).ToList();
        }

        #region Private Method
        /// <summary>
        /// Method  create for getiing last login time.
        /// </summary>
        /// <param name="userId">userId for login history.</param>
        /// <returns> return object</returns>
        private DateTime? GetUserHistory(List<Login> loginHistory, int userId)
        {
            var loginDetail = loginHistory.Where(a => a.UserId == userId);
            var lastSuccess = loginDetail.Where(a => a.IsValidate).OrderBy(a => a.LoginHistory);
            if (lastSuccess.Count() == 0)
            {
                return null;
            }
            return lastSuccess.First().LoginHistory;
        }


        /// <summary>
        ///  Method  create for getiing login history.
        /// </summary>
        /// <param name="userId">userId for login history.</param>
        /// <returns> return object</returns>
        private async Task<UserHistory> GetUserHistory(int userId)
        {
            var userDetail = await _dataRepository.FirstOrDefaultAsync<UserRegistration>(authUser => authUser.UserId.Equals(userId));
            var userLoginDetail = await _dataRepository.FirstOrDefaultAsync<Login>(authUser => authUser.UserId.Equals(userId));

            UserHistory userHistory = new UserHistory();
            var loginHistory = await _dataRepository.GetAllAsync<Login>();
            userHistory.UserId = userDetail.UserId;
            userHistory.UserName = userDetail.UserName;
            userHistory.countOfSuccess = await _dataRepository.CountAsync<Login>(authUser => authUser.UserId == userId && authUser.IsValidate);
            userHistory.countOfFailure = await _dataRepository.CountAsync<Login>(authUser => authUser.UserId == userId && !authUser.IsValidate);
            userHistory.LastSuccess = GetUserHistory(loginHistory, userId);

            return userHistory;
        }
        #endregion

        #endregion
    }
}
