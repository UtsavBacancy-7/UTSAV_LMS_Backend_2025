using LMS_Backend.LMS.Application.DTOs.Authentication;
using LMS_Backend.LMS.Application.Interfaces.Authentication;
using LMS_Backend.LMS.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace LMS_Backend.LMS.API.Controllers
{
    [ApiController]
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterDTO register)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var message = await _authRepository.RegisterAsync(register);
                return Ok(new { Message = message });
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred. : {ex.Message}" });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginDTO userLoginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var loginResponse = await _authRepository.LoginAsync(userLoginDTO);
                return Ok(loginResponse);
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred. : {ex.Message}" });
            }
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp(ForgotPwdDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var message = await _authRepository.SendOtpToEmail(dto);
            return Ok(new { message = "OTP sent to email." });
        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult<string>> ResetPassword(ResetPwdDTO resetPwdDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _authRepository.ResetPassword(resetPwdDTO);
                return Ok(new { Message = result });
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred. : {ex.Message}" });
            }
        }
    }
}