using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserAuthenticationApplication.DomainModel.Models.UserRegistration;
using UserAuthenticationApplication.Repository.Login;

namespace UserAuthenticationApplication.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Private Member
        private readonly ILoginRepository _loginRepository;
        #endregion

        #region Constructore
        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        #endregion

        #region Public Methods
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetLoginDetailAsync()
        {
            return Ok(await _loginRepository.GetAllUserAsync());

        }
        /**
      * @api {post} /Login/
      * @apiBody {String} UserId             Mandatory UserId of the .
      * @apiBody {String} EmailId            Mandatory  input with small letter"pa".
      * @apiBody {String} Password           Mandatory input 10 digit or number with combination with aplphabets.
      * @apiBody {bool} IsDeleted            User is Active or Not.
      */
        [HttpPost("AddUserLogin")]
        public async Task<IActionResult> AddLoginByNameAsync(string emailId, string passcode)
        {
            var result = await _loginRepository.AddloginUserAsync(emailId, passcode);

            if (result.IsValidate == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Email And Password Enter Incorrect");
            }
            return Ok("Login Successfully");
        }


        #endregion
    }
}