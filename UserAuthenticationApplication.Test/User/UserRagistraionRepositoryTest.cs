using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.ApplicationClass.DTO.UserRagistrationDTO;
using UserAuthenticationApplication.Repository.DataRepository;
using UserAuthenticationApplication.Repository.User;
using UserAuthenticationApplication.Web.Controllers;
using Xunit;

namespace UserAuthenticationApplication.Test
{
    public class UserRagistraionRepositoryTest
    {
        private readonly Mock<IDataRepository> _dataRepository;
        private readonly UserController _userController;
        private readonly Mock<IUserRegistrationRepository> _userRagistraionRepository;

        public UserRagistraionRepositoryTest()
        {
            _dataRepository = new Mock<IDataRepository>();
            _userRagistraionRepository = new Mock<IUserRegistrationRepository>();
            _userController = new UserController(_userRagistraionRepository.Object);

        }

        [Fact]
        public async Task GetAllUserRagistrationTest()
        {
            //Arrange
            _userRagistraionRepository.Setup(x => x.GetAllUserAsync()).ReturnsAsync(new List<UserRagistrationDetailDTO>() { new UserRagistrationDetailDTO(), new UserRagistrationDetailDTO() });

            //Art
            var result = await _userController.GetUserRagistrationAsync();

            //Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsType<List<UserRagistrationDetailDTO>>(viewResult.Value);
            Assert.Equal(2, user.Count);
        }

        [Fact]
        public async Task CreateUserRagistrationTest()
        {
            //Arrange
            var employeedeatil = new UserRagistrationDetailDTO();
            {

                employeedeatil.UserId = 1;
                employeedeatil.UserName = "Test";
            };

            var usertList = GetUserRagistraionsData();

            _userRagistraionRepository.Setup(x => x.GetUserByIdAsync(employeedeatil.UserId)).ReturnsAsync(usertList);

            //Act
            var employee = await _userController.GetUserByIDAsync(1);

            //Assert
            Assert.NotNull(employee);

        }

        [Fact]
        public async Task AddUserRagistrationTest()
        {
            var userDetail = new UserRagistrationDetailDTO();
            {
                userDetail.UserId = 0;
                userDetail.UserName = "Test";
                userDetail.EmailId = "Palash@gmail.com";
                userDetail.Address = "Pune";
                userDetail.Password = "Password";
                userDetail.PhoneNumber = "01234567890";
                userDetail.IsDeletd = true;

            };

            await _userController.AddUserAsync(userDetail);

            _dataRepository.Verify(mock => mock.AddAsync(It.IsAny<UserRagistrationDetailDTO>()), Times.Once);
        }
        private UserRagistrationDetailDTO GetUserRagistraionsData()
        {

            var userDetail = new UserRagistrationDetailDTO();

            userDetail.UserId = 1;
            userDetail.UserName = "Test";
            userDetail.EmailId = "Palash@gmail.com";
            userDetail.Address = "Pune";
            userDetail.Password = "Password";
            userDetail.PhoneNumber = "01234567890";
            userDetail.IsDeletd = true;

            return userDetail;
        }
    }
}
