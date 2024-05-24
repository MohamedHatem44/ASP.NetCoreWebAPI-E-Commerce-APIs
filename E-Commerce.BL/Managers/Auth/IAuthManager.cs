using E_Commerce.BL.Dtos.Auth;

namespace E_Commerce.BL.Managers.Auth
{
    public interface IAuthManager
    {
        /*------------------------------------------------------------------------*/
        // Login
        Task<TokenDto> Login(LoginDto loginDto);
        /*------------------------------------------------------------------------*/
        // Register
        Task<TokenDto> Register(RegisterDto registerDto);
        /*------------------------------------------------------------------------*/
    }
}
