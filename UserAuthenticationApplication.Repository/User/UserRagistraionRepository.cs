using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.ApplicationClass.DTO.UserRagistrationDTO;
using UserAuthenticationApplication.DomainModel.Models.UserRegistration;
using UserAuthenticationApplication.Repository.DataRepository;
using UserAuthenticationApplication.Repository.User;

namespace UserAuthenticationApplication.Repository.UserRagistraionRepository
{
    public class UserRegistraionRepository : IUserRegistrationRepository
    {
        #region PrivetMember
        private readonly IDataRepository _dataRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public UserRegistraionRepository( IDataRepository dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Ragistered the user in Database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserRagistrationDetailDTO> AddUserAsync(UserRagistrationDetailDTO user)
        {
            var newUser = _mapper.Map<UserRagistrationDetailDTO, UserRegistration>(user);
            newUser.UserId = 0;
            await _dataRepository.AddAsync(newUser);
            return _mapper.Map< UserRegistration, UserRagistrationDetailDTO>(newUser);
        }
        /// <summary>
        /// List Show all Ragisterd User list.
        /// </summary>
        /// <returns>List Of ragisterd User Show</returns>
        public async Task<List<UserRagistrationDetailDTO>> GetAllUserAsync()
        {
            var userDetail = await _dataRepository.Where<UserRegistration>(x => x.IsDeletd).AsNoTracking().ToListAsync();
            return _mapper.Map<List<UserRegistration>, List<UserRagistrationDetailDTO>>(userDetail);
        }

        /// <summary>
        /// This Method is used for showing particular user detail.
        /// </summary>
        /// <param name="UserId"> Using UserId particular.</param>
        /// <returns>Showing of partucular user with their Salary</returns>
        public async Task<UserRagistrationDetailDTO> GetUserByIdAsync(int UserId)
        {
            var userDetail = await _dataRepository.FirstAsync<UserRegistration>(a => a.UserId == UserId);
            return _mapper.Map<UserRagistrationDetailDTO>(userDetail);
        }

        /// <summary>
        /// Updating Email and Passwords.
        /// </summary>
        /// <param name="User">Current UserId Is used</param>
        /// <returns>updating User information</returns>
        public async Task<UserRagistrationDetailDTO> UpdateUserAsync(UserRagistrationDetailDTO User)
        {
            var userDetail = await _dataRepository.FirstAsync<UserRegistration>(a => a.UserId == User.UserId);

            userDetail.UserName = User.UserName;
            userDetail.EmailId = User.EmailId;
            userDetail.Password = User.Password;

            await _dataRepository.UpdateAsync(userDetail);
            return _mapper.Map<UserRagistrationDetailDTO>(userDetail);
        }

        /// <summary>
        /// De_activate User through UserId.
        /// </summary>
        /// <param name="UserId">Current Using UserID.</param>
        /// <returns></returns>
        public async Task RemoveUserAsync(int UserId)
        {
            var userDetail = await _dataRepository.FirstAsync<UserRegistration>(a => a.UserId == UserId);
            userDetail.IsDeletd = true;
            await _dataRepository.UpdateAsync(userDetail);
        }
        #endregion
    }
}
