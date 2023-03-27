using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.Models.LoginDetails;
using UserAuthenticationApplication.DomainModel.Models.UserHistory;
using UserAuthenticationApplication.DomainModel.Models.UserRegistration;
using UserAuthenticationApplication.DomainModel.Models.UserRegistrationDetail;
using UserAuthenticationApplication.Repository.DataRepository;
using UserAuthenticationApplication.Repository.User;

namespace UserAuthenticationApplication.Repository.Login
{
    public class LoginRepository : ILoginRepository
    {
        #region Private Method
        private readonly IUserRegistrationRepository _userRegistrationRepository;
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructore
        public LoginRepository(IDataRepository dataRepository, IMapper mapper)
        {
            _mapper = mapper;
            _dataRepository = dataRepository;
        }
        #endregion

        #region Public Methods
        //public Task<List<UserRagistrationDetail>> GetAllUserAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<LoginDetail>> GetUserSpecificDetailsAsync(int userId)
        {
            var employeeDetails = await _dataRepository.Where<Login>(a => a.UserId == userId).AsNoTracking().ToListAsync();
            return _mapper.Map<List<Login>, List<LoginDetail>>(employeeDetails);

        }

        /// <summary>
        /// Checking User Validdate Or not If Valid Then store in data
        /// </summary>
        /// <param name="emailId">Current User emailID</param>
        /// <param name="passcode">Current user Password</param>
        /// <returns>User Valid or not retrun  </returns>

        public async Task<LoginDetail> AddloginUserAsync(string emailId, string passcode)
        {
            Login loginDetail = new Login();
            loginDetail.LoginHistory = DateTime.Now;

            var UserDetail = await _dataRepository.FirstOrDefaultAsync<UserRegistration>(authUser => authUser.EmailId.Equals(emailId) && authUser.Password.Equals(passcode));

            if (UserDetail != null)
            {
                loginDetail.UserId = UserDetail.UserId;
                loginDetail.IsValidate = true;
            }
            else
            {
                var response = await _dataRepository.FirstOrDefaultAsync<UserRegistration>(x => x.EmailId == emailId);
                loginDetail.UserId = response.UserId;
                loginDetail.IsValidate = false;
            }
            await _dataRepository.AddAsync(loginDetail);
            return _mapper.Map<LoginDetail>(loginDetail);

        }
        public async Task<UserHistory> GetUserCountAsync(int userId)
        {

            return await GetUserHistory(userId);
        }
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
        private DateTime? GetUserHistory(List<Login> loginHistory, int userId)
        {
            var loginDetail = loginHistory.Where(a => a.UserId == userId);
            var lastSUccess = loginDetail.Where(a => a.IsValidate).OrderBy(a => a.LoginHistory);
            if (lastSUccess.Count() == 0)
            {
                return null;
            }
            return lastSUccess.First().LoginHistory;
        }
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
    }
}
