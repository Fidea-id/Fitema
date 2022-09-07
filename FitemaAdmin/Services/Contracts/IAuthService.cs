using FitemaEntity.Requests;
using FitemaEntity.Responses;

namespace FitemaAdmin.Services.Contracts
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthResponse>> SignIn(LoginRequest request);
        Task<ApiResponse<CreateUserResponse>> CreateUser(CreateUserRequest request);
        //forgot password
        //resend email confirmation
    }
}
