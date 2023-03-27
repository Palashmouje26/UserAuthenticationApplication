using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
        /**
      * @api {post} /Login/
      * @apiBody {String} UserId      Mandatory UserId of the .
      * @apiBody {String} EmailId     Mandatory  input with small letter"pa".
      * @apiBody {String} Password    Mandatory input 10 digit or number with combination with aplphabets.
      * @apiBody {bool} IsDeleted     User is Active or Not.
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

        [HttpGet("GetUserSpecificDetails")]
        public async Task<IActionResult> GetUserSpecificDetailsAsync(int userId)
        {
            var res = await _loginRepository.GetUserSpecificDetailsAsync (userId);
            if (res != null)
            {
                return Ok(res);
            }
            else { return BadRequest(); }
        }

        [HttpGet("GetUserCountDetail")]
        public async Task<IActionResult> GetUserCountDetailAsync(int userId)
        {
            var response = await _loginRepository.GetUserCountAsync(userId);
            return Ok(response);
        }
        [HttpGet("GetAllUserCountDetail")]
        public async Task<IActionResult> GetAllUserCountDetail()
        {
            var response = await _loginRepository.GetAllUserCountAsync();
            return Ok(response);
        }

        #endregion
    }
}