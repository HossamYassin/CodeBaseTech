using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CreateAsync(CreateUserDto user);
        Task<bool> ExistAsync(CreateUserDto user);
        Task<UserDTO> AddPINAsync(CreateUserPINDto user);
        Task<UserDTO> LoginAsync(UserLoginDto user);
        Task<bool> ValidateEmailDigitsAsync(EmailDigits digits);
        Task<bool> ValidateMobileDigitsAsync(MobileDigits digits);
        Task<bool> AddMobileDigitsAsync(MobileDigits digits);
        Task<bool> AddEmailDigitsAsync(EmailDigits digits);
    }
}
