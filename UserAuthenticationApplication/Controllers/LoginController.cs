using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> GetLoginDetail()
        {
            return Ok(await _loginRepository.GetAllUserAsync());
        }
        #endregion
    }
}