using Fitema.Dtos;
using Fitema.Dtos.Auth;
using Fitema.Repository.Contracts;
using Fitema.Services.Contracts;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Fitema.Models;

namespace Fitema.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Tuple<ResponseDto, ClaimsPrincipal?>> Login(LoginDto authenticationUserDto)
        {
            var user = await _userRepository.GetUserByEmail(authenticationUserDto.Email);
            if (user == null)
            {
                return new Tuple<ResponseDto, ClaimsPrincipal?>(new ResponseDto { Success = false, Message = "User not found." }, null);
            }
            var verifyPassword = BCrypt.Net.BCrypt.Verify(authenticationUserDto.Password, user.Password);
            if (!verifyPassword)
            {
                return new Tuple<ResponseDto, ClaimsPrincipal?>(new ResponseDto { Success = false, Message = "Password doesn't match." }, null);
            }
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.FullName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim("Organization", user.OrgId.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, user.Role));
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return new Tuple<ResponseDto, ClaimsPrincipal?>(new ResponseDto { Success = true, Message = "Success." }, claimsPrincipal);
        }

        public string GenPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public async Task<bool> CheckUserLoggedPassword(LoginDto authenticationUserDto)
        {
            var user = await _userRepository.GetUserByEmail(authenticationUserDto.Email); 
            var verifyPassword = BCrypt.Net.BCrypt.Verify(authenticationUserDto.Password, user.Password);
            return verifyPassword;
        }
    }
}
