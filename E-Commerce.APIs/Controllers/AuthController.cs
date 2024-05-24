using E_Commerce.BL.Dtos.Auth;
using E_Commerce.BL.Managers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /*------------------------------------------------------------------------*/
        private readonly IAuthManager _authManager;
        /*------------------------------------------------------------------------*/
        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }
        /*------------------------------------------------------------------------*/
        // Login
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var jwt = await _authManager.Login(loginDto);
                return Ok(jwt);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    return StatusCode(500, "An error occurred while processing your request.");
                }
            }
        }
        /*------------------------------------------------------------------------*/
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<TokenDto>> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                var jwt = await _authManager.Register(registerDto);
                return Ok(jwt);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    return StatusCode(500, "An error occurred while processing your request.");
                }
            }
        }
        /*------------------------------------------------------------------------*/
    }
}
