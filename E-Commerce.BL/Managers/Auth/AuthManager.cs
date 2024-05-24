using E_Commerce.BL.Dtos.Auth;
using E_Commerce.BL.Mapper.UnitMapper;
using E_Commerce.DAL;
using E_Commerce.DAL.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_Commerce.BL.Managers.Auth
{
    public class AuthManager : IAuthManager
    {
        /*------------------------------------------------------------------------*/
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitMapper _unitMapper;
        /*------------------------------------------------------------------------*/
        public AuthManager(IUnitOfWork unitOfWork, IConfiguration configuration, IUnitMapper unitMapper)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _unitMapper = unitMapper;
        }
        /*------------------------------------------------------------------------*/
        // Login
        public async Task<TokenDto> Login(LoginDto loginDto)
        {
            var user = await _unitOfWork.UserManager.FindByEmailAsync(loginDto.Email);

            // Find user
            if (user == null)
            {
                throw new ArgumentException("Invalid email or password.");
            }

            // Check password
            if (!await _unitOfWork.UserManager.CheckPasswordAsync(user, loginDto.Password))
            {
                throw new ArgumentException("Invalid email or password.");
            }
            // Generate token
            return GenerateToken(user);
        }
        /*------------------------------------------------------------------------*/
        // Register
        public async Task<TokenDto> Register(RegisterDto registerDto)
        {
            var existingUser = await _unitOfWork.UserManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                throw new ArgumentException("Email is already exist.");
            }

            // Create new user
            var newUser = _unitMapper.AuthMapper.RegisterUser(registerDto);

            var result = await _unitOfWork.UserManager.CreateAsync(newUser, registerDto.Password);
            if (!result.Succeeded)
            {
                throw new ArgumentException("Failed to create user.");
            }

            // Add "User" role to the newly registered user
            await _unitOfWork.UserManager.AddToRoleAsync(newUser, "User");

            // Generate token
            return GenerateToken(newUser);
        }
        /*------------------------------------------------------------------------*/
        // Generate Token
        private TokenDto GenerateToken(User _user)
        {
            var keyFromConfig = _configuration.GetSection("SecretKey").Value;
            var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig!);
            var key = new SymmetricSecurityKey(keyInBytes);

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var expiryDateTime = DateTime.Now.AddDays(30);
            var userClaims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, _user.Id),
                new (ClaimTypes.Email, _user.Email!),
            };

            // Get the user's roles
            var userRoles = _unitOfWork.UserManager.GetRolesAsync(_user).Result;
            foreach (var role in userRoles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwt = new JwtSecurityToken(
                claims: userClaims,
                expires: expiryDateTime,
                signingCredentials: signingCredentials);

            var jwtAsString = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenDto(jwtAsString, expiryDateTime);
        }
        /*------------------------------------------------------------------------*/
    }
}
