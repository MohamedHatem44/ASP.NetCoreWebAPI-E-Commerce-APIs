using E_Commerce.BL.Dtos.Users;
using E_Commerce.BL.Mapper.UnitMapper;
using E_Commerce.DAL;

namespace E_Commerce.BL.Managers.Users
{
    public class UserManager : IUserManager
    {
        /*------------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitMapper _unitMapper;
        /*------------------------------------------------------------------------*/
        public UserManager(IUnitOfWork unitOfWork, IUnitMapper unitMapper)
        {
            _unitOfWork = unitOfWork;
            _unitMapper = unitMapper;
        }
        /*------------------------------------------------------------------------*/
        // Get All Users Without Details
        public IEnumerable<ReadUserDto> GetAllUsers()
        {
            var users = _unitOfWork.UserRepository.GetAll();
            var allUsers = users.Select(user => _unitMapper.UserMapper.MapModelToReadUser(user));
            return allUsers;
        }
        /*------------------------------------------------------------------------*/
        // Get All Users With Orders
        public IEnumerable<ReadUserOrdersDto> GetAllUsersWithOrders()
        {
            var users = _unitOfWork.UserRepository.GetAllUsersWithOrders();
            var allUsers = users.Select(user => _unitMapper.UserMapper.MapModelToReadUserOrder(user));
            return allUsers;
        }
        /*------------------------------------------------------------------------*/
        // Get All Users With Shopping Cart
        public IEnumerable<ReadUserShoppingCartDto>? GetAllUsersWithShoppingCart()
        {
            var users = _unitOfWork.UserRepository.GetAllUsersWithShoppingCart();
            if (users == null)
            {
                return null;
            }
            var allUsers = users.Select(user => _unitMapper.UserMapper.MapModelToReadUserShoppingCart(user));
            return allUsers;
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific User By Id Without Details
        public ReadUserDto? GetUserById(string id)
        {
            var user = _unitOfWork.UserRepository.GetUserById(id);
            if (user == null)
            {
                return null;
            }
            var specificUser = _unitMapper.UserMapper.MapModelToReadUser(user);
            return specificUser;
        }
        /*------------------------------------------------------------------------*/
        // Create a New User
        public async Task CreateUser(CreateUserDto createUserDto)
        {
            var existingUser = await _unitOfWork.UserManager.FindByEmailAsync(createUserDto.Email);
            if (existingUser != null)
            {
                throw new ArgumentException("Email is already exist.");
            }

            // Create a User
            var newUser = _unitMapper.UserMapper.MapCreateUserToModel(createUserDto);

            var result = await _unitOfWork.UserManager.CreateAsync(newUser, createUserDto.Password);
            if (!result.Succeeded)
            {
                throw new ArgumentException("Failed to create user.");
            }
        }
        /*------------------------------------------------------------------------*/
        // Update a Specific User By Id
        public ReadUserDto? UpdateUser(string id, UpdateUserDto updateUserDto)
        {
            // Retrieve the User by ID
            var user = _unitOfWork.UserRepository.GetUserById(id);
            // If user with the specified ID is not found, return null
            if (user == null)
            {
                return null;
            }

            // Check if the email is being changed
            if (!user.Email!.Equals(updateUserDto.Email, StringComparison.OrdinalIgnoreCase))
            {
                var existingUserWithSameEmail = _unitOfWork.UserRepository.GetUserByEmail(updateUserDto.Email);
                if (existingUserWithSameEmail != null && existingUserWithSameEmail.Id != id)
                {
                    return null; // Email already exists for another user
                }
            }
            // Update User details
            _unitMapper.UserMapper.MapUpdateUserToModel(updateUserDto, user);

            // Save changes to the database
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();

            // Convert the new User entity to a ReadUserDto
            var newUserToReturn = _unitMapper.UserMapper.MapModelToReadUser(user);
            return newUserToReturn;
        }
        /*------------------------------------------------------------------------*/
        // Delete a Specific User By Id
        public void DeleteUser(string id)
        {
            var user = _unitOfWork.UserRepository.GetUserById(id);
            if (user == null)
            {
                return;
            }
            _unitOfWork.UserRepository.Delete(user);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
    }
}
