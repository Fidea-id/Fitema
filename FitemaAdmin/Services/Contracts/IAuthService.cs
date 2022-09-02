using FitemaEntity.Requests;
using FitemaEntity.Responses;

namespace FitemaAdmin.Services.Contracts
{
    public interface IAuthService
    {
        Task<DefaultResponse<AuthResponse>> SignIn(LoginRequest request);
        Task<DefaultResponse<CreateUserResponse>> CreateUser(CreateUserRequest request);
        //forgot password
        //resend email confirmation
    }
}
