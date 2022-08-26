using FitemaAPI.Helpers;
using FitemaAPI.Repository.Contracts;
using FitemaAPI.Services.Contracts;
using FitemaEntity.Models;
using FitemaEntity.Requests;
using FitemaEntity.Responses;
using FitemaEntity.Utils.Constants;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;

namespace FitemaAPI.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;
        private readonly IOrganizationRepository _organizationRepository;
        public AuthService(IUserRepository userRepository, IOrganizationRepository organizationRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _organizationRepository = organizationRepository;
            _appSettings = appSettings.Value;
        }

        public string GenPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public async Task<bool> CheckUserLoggedPassword(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            var verifyPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            return verifyPassword;
        }

        public async Task<DefaultResponse<AuthResponse>> Authenticate(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            var verifyPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            // return null if user not found
            if (user == null && verifyPassword == false) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);
            return new DefaultResponse<AuthResponse> { Data = new AuthResponse(user, token), Message = "Success", Success = true };
        }

        public async Task<DefaultResponse<Users>> GetById(int id)
        {
            return new DefaultResponse<Users> { Data = await _userRepository.GetUserById(id), Message = "Success", Success = true };
        }

        public async Task<DefaultResponse<CreateUserResponse>> Register(CreateUserRequest request)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                //create organization
                var org = new Organizations(request.OrganizationName, request.OrganizationAddress, request.OrganizationDescription, StatusActive.ACTIVE);
                var orgId = await _organizationRepository.CreateOrganization(org);
                //create user
                var userPassword = GenPassword(request.Password);
                var user = new Users(request.FullName, request.Email, userPassword, request.Role, orgId);
                var userId = await _userRepository.CreateUser(user);
                //scope complete
                transactionScope.Complete();
                var response = new CreateUserResponse(user.Email, user.FullName, user.Role, org.Name, org.Address, org.Description);
                return new DefaultResponse<CreateUserResponse> { Success = true, Data = response, Message = "Success" };
            }
        }

        private string generateJwtToken(Users user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
