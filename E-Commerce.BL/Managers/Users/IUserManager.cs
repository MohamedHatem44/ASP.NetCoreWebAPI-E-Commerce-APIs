using E_Commerce.BL.Dtos.Users;

namespace E_Commerce.BL.Managers.Users
{
    public interface IUserManager
    {
        /*------------------------------------------------------------------------*/
        // Get All Users Without Details
        IEnumerable<ReadUserDto> GetAllUsers();
        /*------------------------------------------------------------------------*/
        // Get All Users With Orders
        IEnumerable<ReadUserOrdersDto> GetAllUsersWithOrders();
        /*------------------------------------------------------------------------*/
        // Get All Users With Shopping Cart
        IEnumerable<ReadUserShoppingCartDto>? GetAllUsersWithShoppingCart();
        /*------------------------------------------------------------------------*/
        // Get a Specific User By Id Without Details
        ReadUserDto? GetUserById(string id);
        /*------------------------------------------------------------------------*/
        // Create a New User
        Task CreateUser(CreateUserDto createUserDto);
        /*------------------------------------------------------------------------*/
        // Update a Specific User By Id
        ReadUserDto? UpdateUser(string id, UpdateUserDto updateUserDto);
        /*------------------------------------------------------------------------*/
        // Delete a Specific User By Id
        void DeleteUser(string id);
        /*------------------------------------------------------------------------*/
    }
}
