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

        #region Constructore
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
        /// 
        /// </summary>
        /// <returns></returns>

        public async Task<List<UserRagistrationDetail>> GetAllUserAsync()
        {
            var UserDetails = await _dataRepository.Where<DomainModel.Models.UserRegistration.UserRegistration>(x =>x.UserId >0 &&  x.IsDeletd).AsNoTracking().ToListAsync();
            return _mapper.Map<List<UserRegistration>, List<UserRagistrationDetail>>(UserDetails);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task<UserRagistrationDetail> GetUserByIdAsync(int UserId)
        {
            var UserDetail = await _dataRepository.FirstAsync<UserRegistration>(a => a.UserId == UserId);
            return _mapper.Map<UserRagistrationDetail>(UserDetail);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public async Task<UserRagistrationDetail> UpdateUserAsync(UserRagistrationDetail User)
        {
            var UserDetail = await _dataRepository.FirstAsync<UserRegistration>(a => a.UserId == User.UserId);

            UserDetail.UserName = User.UserName;
            UserDetail.EmailId = User.EmailId;
            UserDetail.Password = User.Password;

            await _dataRepository.UpdateAsync(UserDetail);
            return _mapper.Map<UserRagistrationDetail>(UserDetail);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public async Task RemoveSoftdeleteAsync(int UserId)
        {
            var UserDetail = await _dataRepository.FirstAsync<UserRegistration>(a => a.UserId == UserId);
            UserDetail.IsDeletd = false;
            await _dataRepository.UpdateAsync(UserDetail);
        }
        #endregion
    }
}
