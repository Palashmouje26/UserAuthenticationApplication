using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserAuthenticationApplication.Repository.UserRagistraionRepository;
using UserAuthenticationApplication.Repository.User;
using UserAuthenticationApplication.DomainModel.Models.UserRegistrationDetail;

namespace UserAuthenticationApplication.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region private Member
        private readonly IUserRegistrationRepository _userRegistration;
        #endregion

        #region Constructor
        public UserController( IUserRegistrationRepository userRegistration)
        {
            _userRegistration = userRegistration;
        }
        #endregion

        #region Public Methods

        /**
        * @api {get} /api/userRagistration /:get all User information
        * @apiName GetUserRagistrationAsync
        * @apiGroup UserRagistration
        *    
        * @apiParam {Number} UserId id of the User.
        * 
        * @apiSuccess {String} UserName Username of the User.
        * 
        * @apiSuccessExample Success-Response:
        *     {
        *       "firstname": "John",
        *       "mobile : "7894561230"
        *     }
        *     
        * @apiError UserNotFound The information of the User was not found.
        * 
        */
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUserRagistrationAsync()
        {
            return Ok(await _userRegistration.GetAllUserAsync());
        }
        /**
        * @api {get} /api/UserRagistration /:id get one particuler User information
        * @apiName GetUserByIDAsync
        * @apiGroup UserRagistration
        *    
        * @apiParam {Number} employeeID id of the User.
        * 
        * @apiSuccess {String}  Username of the User.
        * 
        * @apiSuccessExample Success-Response:
        *     {
        *       "firstname": "John",
        *       "EmailId":Xyz@gmail.com"
        *     }
        *     
        * @apiError UserNotFound The id of the UserId was not found.
        * 
        */

        [HttpGet("GetUserByID/{Id}")]
        public async Task<IActionResult> GetUserByIDAsync([FromRoute] int Id)
        {
            return Ok(await _userRegistration.GetUserByIdAsync(Id));
        }
        /**
        * @api {post} /UserRagistration/
        * @apiBody {String} UserName           Mandatory Firstname of the employee.
        * @apiBody {String} EmailId            Mandatory  input with small letter"pa".
        * @apiBody {String} [address]          Optional nested address object.
        * @apiBody {String} PhoneNumber        Mandatory input 10 digit or number.
        * @apiBody {String} Password           Mandatory input 10 digit or number with combination with aplphabets.
        * @apiBody {bool} IsDeleted            User is Active or Not.
        */

        [HttpPost("AddEmployee")]

        public async Task<IActionResult> AddUserAsync([FromForm] UserRagistrationDetail user)
        {
            var result = await _userRegistration.AddUserAsync(user);

            if (result.UserId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }


        /**
         * @api {put} /employee/ Modify User information
         * @apiName UpdateEmployeeAsync
         * @apiGroup UserRagistration
         *
         * @apiParam {Number} id          User unique ID.
         * @apiParam {String} UserName  UserName of the User.
         * @apiParam {String} Password  Password of the User.
         *
         * @apiSuccessExample Success-Response:
         *  { 
         *      firstname = "John",
         *    
         *      Password =  "Xyz@123"
         *   
         *  }
         *
         * @apiUse EmployeeIDNotFoundError
         */

        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult> UpdateEmployeeAsync([FromForm] UserRagistrationDetail user)
        {
            if (user.UserId != user.UserId)
            {
                return BadRequest();
            }
            await _userRegistration.UpdateUserAsync(user);
            return Ok("Update Successfully");
        }

        /**
        * @api {put} /UserRagistration/ Modify User Active or Inactive
        * @apiName RemoveSoftdeleteAsync
        * @apiGroup UserRagistration
        *
        * @apiParam {Number} id User unique ID.

        *
        * @apiSuccessExample Success-Response:
        *  { 
        *      UserId = 1
        *  }
        *
        */

        [HttpPut("RemoveSoftDeleteById/{Id}")]
        public async Task<ActionResult> RemoveSoftdeleteAsync(int Id)
        {
            await _userRegistration.RemoveSoftdeleteAsync(Id);
            return Ok("Remove Successfully");
        }

        #endregion
    }
}
