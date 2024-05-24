using E_Commerce.BL.Dtos.Users;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.UserMapper
{
    public interface IUserMapper
    {
        /*------------------------------------------------------------------------*/
        public ReadUserDto MapModelToReadUser(User user);
        /*------------------------------------------------------------------------*/
        public ReadUserOrdersDto MapModelToReadUserOrder(User user);
        /*------------------------------------------------------------------------*/
        public ReadUserShoppingCartDto MapModelToReadUserShoppingCart(User user);
        /*------------------------------------------------------------------------*/
        public User MapCreateUserToModel(CreateUserDto createUserDto);
        /*------------------------------------------------------------------------*/
        public void MapUpdateUserToModel(UpdateUserDto updateUserDto, User user);
        /*------------------------------------------------------------------------*/
    }
}
