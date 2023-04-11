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
      * @apiSuccessExample Success-Response:
        *  { 
        *      login = "Xyz@ghk.com",
        *      Password =  "Xyz@123"
        *  }
      */
        [HttpPost("adduserlogin")]
        public async Task<IActionResult> AddLoginAsync(string emailId, string passcode)
        {
            var result = await _loginRepository.AddloginUserAsync(emailId, passcode);

            if (result.IsValidate == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Email And Password Enter Incorrect");
            }
            return Ok("Login Successfully");
        }
        /**
       * @api {get} /api/LoginController/:Id get one particuler User login information.
       * @apiName GetUserSpecificDetailsAsync.
       * @apiGroup Login
       *    
       * @apiParam {Number}  userId of the User.
       * @apiError UserNotFound The id of the UserId was not found.
       */
        [HttpGet("userspecificdetails")]
        public async Task<IActionResult> GetUserSpecificDetailsAsync(int userId)
        {
            var response = await _loginRepository.GetUserSpecificDetailsAsync (userId);
            if (response != null)
            {
                return Ok(response);
            }
            else 
            {
                return BadRequest(); 
            }
        }
        /**
       * @api {get} /api/LoginController /:get One  User login information and count
       * @apiName GetUserCountDetailAsync.
       * @apiGroup Login.
       *    
       * @apiParam {Number}  Id of the User.
       * @apiError UserNotFound The id of the UserId was not found.
       */
        [HttpGet("usercountdetail")]
        public async Task<IActionResult> GetUserCountDetailAsync(int userId)
        {
            var response = await _loginRepository.GetUserCountAsync(userId);
            return Ok(response);
        }
        /**
       * @api {get} /api/LoginController /: All User information wth no. of count.
       * @apiName GetAllUserCountDetail.
       * @apiGroup Login.
       *    
       * @apiError UserNotFound .
       */
        [HttpGet("allusercountdetail")]
        public async Task<IActionResult> GetAllUserCountDetail()
        {
            var response = await _loginRepository.GetAllUserCountAsync();
            return Ok(response);
        }

        #endregion
    }
}