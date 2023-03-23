using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.Models.LoginDetails;
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
        public Task<List<UserRagistrationDetail>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<LoginDetail>> GetUserSpecificDetails(int userId)
        {
            //var response = await _dataRepository.FirstAsync<List<Login>>(x => x.UserId == userId);
            //if (response != null)
            //{
            //    return _mapper.Map<LoginDetail>(response);
            //}

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
            #endregion
        }

    }
}
