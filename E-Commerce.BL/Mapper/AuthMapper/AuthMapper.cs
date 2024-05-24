using E_Commerce.BL.Dtos.Auth;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.AuthMapper
{
    public class AuthMapper : IAuthMapper
    {
        public User RegisterUser(RegisterDto registerDto)
        {
            return new User
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                UserName = registerDto.Email,
                Address = registerDto.Address,
                PhoneNumber = registerDto.PhoneNumber,
            };
        }
    }
}
