using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.Models.UserRegistrationDetail;
using UserAuthenticationApplication.Repository.DataRepository;
using UserAuthenticationApplication.Repository.User;
using UserAuthenticationApplication.Repository.UserRagistraionRepository;
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

            _userRagistraionRepository.Setup(x => x.GetAllUserAsync()).ReturnsAsync(new List<UserRagistrationDetail>() { new UserRagistrationDetail(), new UserRagistrationDetail() });
           
            //Art

            var result = await _userController.GetUserRagistrationAsync();
            
            //Assert

            var viewResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsType<List<UserRagistrationDetail>>(viewResult.Value);
            Assert.Equal(2, user.Count);


        }

        [Fact]
        public async Task GetUserRagistrationTest() 
        {
            //Arrange
            var employeedeatil = new UserRagistrationDetail();
            {

                employeedeatil.UserId = 1;
                employeedeatil.UserName = "Test";
            };

            var usertList = GetUserRagistraionsData();

            _userRagistraionRepository.Setup(x => x.GetUserByIdAsync(employeedeatil.UserId)).ReturnsAsync(employeedeatil);

            //Act
            var employee = await _userController.GetUserByIDAsync(1);

            //Assert
            Assert.NotNull(employee);

        }

        //[Fact]

        //public async Task Add()
        //{
            
        //        //arrange
        //        var productList = GetUserRagistraionsData();

        //        _userRagistraionRepository.Setup(x => x.AddUserAsync(productList[2]))
        //            .Returns(productList[2]);
               

        //        //act      

        //}



        

        private List<UserRagistrationDetail> GetUserRagistraionsData()
        {
            List<UserRagistrationDetail> productsData = new List<UserRagistrationDetail>
            {
                new UserRagistrationDetail()
                {
                    UserId = 1,
                    UserName = "Test",
                    EmailId = "Palash@gmail.com",
                    Address = "Pune",
                    Password = "Password",
                    PhoneNumber = "1234567890",
                    IsDeletd = true,
                }

            };
            return productsData;
        }
    }
}
