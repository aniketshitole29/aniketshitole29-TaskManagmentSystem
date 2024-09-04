
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models.Dto;
using TaskManagementAPI.Services.AuthAPI.Service.IService;

namespace TaskManagementAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        protected ResponseDto _response;

        public AuthAPIController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _response = new ResponseDto();
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registration)
        {
            var errorMessage = await _authService.Register(registration);
            var result = await _authService.AssignRole(registration.Email, registration.RoleName.ToUpper());
            if (!string.IsNullOrEmpty(errorMessage) && result)
            {
                _response.Message = errorMessage;
                _response.IsSuccess = errorMessage == "Success";
            }
            else
                _response.IsSuccess = false;
            if (_response.IsSuccess)
            {
                return Ok(_response);
            }
            else
                return BadRequest(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginResponseDto)
        {
            var result = await _authService.Login(loginResponseDto);
            if(result != null && result.User!= null)
            {
                _response.Message = "Login Successfull";
                _response.Result = result;
                return Ok(_response);
            }
            else
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto requestDto)
        {
            var result = await _authService.AssignRole(requestDto.Email, requestDto.RoleName.ToUpper());
            if (result)
            {
                _response.Message = "Role Added Successfull";
                _response.Result = result;
                return Ok(_response);
            }
            else
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
        }
    }
}
