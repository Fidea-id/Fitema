using Fitema.Dtos;
using Fitema.Dtos.Auth;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Security.Claims;

namespace Fitema.Services.Contracts
{
    public interface IAuthService
    {
        Task<Tuple<ResponseDto, ClaimsPrincipal?>> Login(LoginDto authenticationUserDto);
        string GenPassword(string password);
    }
}
