using FitemaAdmin.Services.Contracts;
using FitemaAdmin.Utils.Helpers;
using FitemaEntity.Requests;
using FitemaEntity.Responses;
using Newtonsoft.Json;

namespace FitemaAdmin.Services.Impl
{
    public class AuthService: IAuthService
    {
        private readonly IRestRequestService _restRequestService;

        public AuthService(IRestRequestService restRequestService)
        {
            _restRequestService = restRequestService;
        }

        public async Task<ApiResponse<AuthResponse>> SignIn(LoginRequest request)
        {
            var response = await _restRequestService.PostResponse("Auth/Authenticate", JsonConvert.SerializeObject(request));
            return ResponseHelper<AuthResponse>.SetResponse(response);
        }

        public async Task<ApiResponse<CreateUserResponse>> CreateUser(CreateUserRequest request)
        {
            var response = await _restRequestService.PostResponse("Auth/Register", JsonConvert.SerializeObject(request));
            return ResponseHelper<CreateUserResponse>.SetResponse(response);
        }
    }
}
