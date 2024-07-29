using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(CreateUserDto user);
        Task<int> SendVerificationEmailAsync(string to);
        Task<bool> ValidateEmailDigitsAsync(EmailDigits emailDigits);
        Task<int> SendVerificationSMSAsync(string to);
        Task<bool> ValidateMobileDigitsAsync(MobileDigits mobileDigits);
        Task<UserDTO> CreatePIN(CreateUserPINDto userPIN);
        Task<UserDTO> LoginAsync(UserLoginDto userLogin);

    }
}
