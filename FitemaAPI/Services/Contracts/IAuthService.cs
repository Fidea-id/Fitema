﻿using FitemaAPI.Helpers;
using FitemaEntity.Dtos;
using FitemaEntity.Dtos.Auth;
using FitemaEntity.Models;
using FitemaEntity.Requests;
using FitemaEntity.Responses;
using System.Security.Claims;

namespace FitemaAPI.Services.Contracts
{
    public interface IAuthService
    {
        Task<DefaultResponse<AuthResponse>> Authenticate(LoginRequest request);
        Task<DefaultResponse<CreateUserResponse>> Register(CreateUserRequest request);
        Task<DefaultResponse<Users>> GetById(int id);
        string GenPassword(string password);
    }
}