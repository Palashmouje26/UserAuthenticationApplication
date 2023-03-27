using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.Models.UserRegistration;
using UserAuthenticationApplication.DomainModel.Models.UserRegistrationDetail;
using UserAuthenticationApplication.Repository.DataRepository;
using UserAuthenticationApplication.Repository.User;

namespace UserAuthenticationApplication.Repository.UserRagistraionRepository
{
    public class UserRagistraionRepository : IUserRegistrationRepository
    {
        #region PrivetMember
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public UserRagistraionRepository( IDataRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserRagistrationDetail> AddUserAsync(UserRagistrationDetail user)
        {
            var newUser = _mapper.Map<UserRagistrationDetail, UserRegistration>(user);
            newUser.UserId = 0;
            await _dataRepository.AddAsync(newUser);
            return _mapper.Map< UserRegistration, UserRagistrationDetail>(newUser);
        }
        /// <summary>
        /// Show all Ragisterd User list 
        /// </summary>
        /// <returns>List Of ragisterd User Show</returns>

        public async Task<List<UserRagistrationDetail>> GetAllUserAsync()
        {
            var userDetail = await _dataRepository.Where<UserRegistration>(x => x.IsDeletd).AsNoTracking().ToListAsync();
            return _mapper.Map<List<UserRegistration>, List<UserRagistrationDetail>>(userDetail);
        }

        /// <summary>
        /// This Method is used for showing List of user with registerd details
        /// </summary>
        /// <param name="UserId"> Using UserId particular  </param>
        /// <returns>List of partucular employee with their Salary</returns>
        public async Task<UserRagistrationDetail> GetUserByIdAsync(int UserId)
        {
            var userDetail = await _dataRepository.FirstAsync<UserRegistration>(a => a.UserId == UserId);
            return _mapper.Map<UserRagistrationDetail>(userDetail);
        }

        /// <summary>
        /// Updating Email and Passwords
        /// </summary>
        /// <param name="User"> Current UserId Is used</param>
        /// <returns>updating User information</returns>
        public async Task<UserRagistrationDetail> UpdateUserAsync(UserRagistrationDetail User)
        {
            var userDetail = await _dataRepository.FirstAsync<UserRegistration>(a => a.UserId == User.UserId);

            userDetail.UserName = User.UserName;
            userDetail.EmailId = User.EmailId;
            userDetail.Password = User.Password;

            await _dataRepository.UpdateAsync(userDetail);
            return _mapper.Map<UserRagistrationDetail>(userDetail);
        }

        /// <summary>
        /// De_activate User through UserId
        /// </summary>
        /// <param name="UserId">Current Using UserID </param>
        /// <returns></returns>
        public async Task RemoveSoftdeleteAsync(int UserId)
        {
            var userDetail = await _dataRepository.FirstAsync<UserRegistration>(a => a.UserId == UserId);
            userDetail.IsDeletd = true;
            await _dataRepository.UpdateAsync(userDetail);
        }
        #endregion
    }
}
