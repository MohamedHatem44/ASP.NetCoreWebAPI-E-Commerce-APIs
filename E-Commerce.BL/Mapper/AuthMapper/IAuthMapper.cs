using E_Commerce.BL.Dtos.Auth;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.AuthMapper
{
    public interface IAuthMapper
    {
        public User RegisterUser(RegisterDto registerDto);
    }
}
