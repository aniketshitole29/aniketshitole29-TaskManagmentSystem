﻿using TaskManagementAPI.Models.Dto;

namespace TaskManagementAPI.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginResponseDto);
        Task<bool> AssignRole(string email,string roleName);
    }
}
