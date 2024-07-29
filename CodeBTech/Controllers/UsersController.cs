using Domain.DTOs;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeBTech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(IUserService userService,
            ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.RegisterAsync(createUserDto);
            return Ok(user);
        }

        [HttpGet("SendVerificationEmail/{email}")]
        public async Task<IActionResult> SendVerificationEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(ModelState);
            }

            var digits = await _userService.SendVerificationEmailAsync(email);
            return Ok(digits);
        }

        [HttpPost("ValidateEmailDigits")]
        public async Task<IActionResult> ValidateEmailDigitsAsync(EmailDigits emailDigits)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isMatch = await _userService.ValidateEmailDigitsAsync(emailDigits);
            return Ok(isMatch);
        }

        [HttpGet("SendVerificationSMS/{mobile}")]
        public async Task<IActionResult> SendVerificationSMSAsync(string mobile)
        {
            if (string.IsNullOrEmpty(mobile))
            {
                return BadRequest(ModelState);
            }

            var digits = await _userService.SendVerificationSMSAsync(mobile);
            return Ok(digits);
        }

        [HttpPost("ValidateMobileDigits")]
        public async Task<IActionResult> ValidateMobileDigitsAsync(MobileDigits mobileDigits)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isMatch = await _userService.ValidateMobileDigitsAsync(mobileDigits);
            return Ok(isMatch);
        }

        [HttpPost("CreatePIN")]
        public async Task<IActionResult> CreatePINAsync(CreateUserPINDto createUserPIN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.CreatePIN(createUserPIN);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(UserLoginDto userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.LoginAsync(userLogin);
            return Ok(user);
        }
    }
}
