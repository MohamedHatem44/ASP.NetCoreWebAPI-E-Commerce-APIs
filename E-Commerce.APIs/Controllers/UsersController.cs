using E_Commerce.BL.Dtos.Users;
using E_Commerce.BL.Managers.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /*------------------------------------------------------------------------*/
        private readonly IUserManager _userManager;
        /*------------------------------------------------------------------------*/
        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        /*------------------------------------------------------------------------*/
        // Get All Users Without Details
        // Get: api/Users
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<ReadUserDto>> GetAllUsers()
        {
            var users = _userManager.GetAllUsers();
            int userCount = users.Count();
            var response = new { UsersCount = userCount, Users = users };
            return Ok(response);
        }
        /*------------------------------------------------------------------------*/
        // Get All Users With Orders
        // Get: api/Users/GetAllUsersWithOrders
        [HttpGet]
        [Route("GetAllUsersWithOrders")]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<ReadUserDto>> GetAllUsersWithOrders()
        {
            var users = _userManager.GetAllUsersWithOrders();
            int userCount = users.Count();
            var response = new { UsersCount = userCount, Users = users };
            return Ok(response);
        }
        /*------------------------------------------------------------------------*/
        // Get All Users With Shopping Cart
        // Get: api/Users/GetAllUsersWithShoppingCart
        [HttpGet]
        [Route("GetAllUsersWithShoppingCart")]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<ReadUserDto>> GetAllUsersWithShoppingCart()
        {
            var users = _userManager.GetAllUsersWithShoppingCart();
            int userCount = users!.Count();
            var response = new { UsersCount = userCount, Users = users };
            return Ok(response);
        }
        /*------------------------------------------------------------------------*/
        // Get a Specific User By Id Without Details
        // Get: api/Users/{id}
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<ReadUserDto> GetUserById(string id)
        {
            var user = _userManager.GetUserById(id);
            if (user == null)
            {
                return NotFound($"User With Id : {id} Not Found");
            }
            return Ok(user);
        }
        /*------------------------------------------------------------------------*/
        // Create a New User
        // Post: api/Users
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateUser(CreateUserDto createUserDto)
        {
            try
            {
                await _userManager.CreateUser(createUserDto);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    return StatusCode(500, "An error occurred while processing your request");
                }
            }
        }
        /*------------------------------------------------------------------------*/
        // Update a Specific User With Id
        // Patch: api/Users/{id}
        [HttpPatch]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<UpdateUserDto> UpdateUser(string id, UpdateUserDto updateUserDto)
        {
            // Retrieve the User by ID
            var user = _userManager.GetUserById(id);
            if (user == null)
            {
                // Return 404 Not Found status code
                return NotFound($"User With Id : {id} Not Found");
            }

            // Check if the updated User Email name is unique among existing Users
            var updatedUser = _userManager.UpdateUser(id, updateUserDto);
            if (updatedUser == null)
            {
                // If the User email is not unique, return Conflict
                return Conflict("User with the same email already exists, User Email must be unique");
            }
            // Return 200 OK status code along with the updated brand
            return Ok(updatedUser);
        }
        /*------------------------------------------------------------------------*/
        // Delete a Specific User By Id
        // Delete: api/Users/{id}
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(string id)
        {
            var user = _userManager.GetUserById(id);
            if (user == null)
            {
                return NotFound($"User With Id : {id} Not Found");
            }
            _userManager.DeleteUser(id);
            return Ok(new { Message = "User deleted successfully" });
        }
        /*------------------------------------------------------------------------*/
    }
}
