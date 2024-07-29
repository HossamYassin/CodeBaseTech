using Domain.DTOs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IEmailService _emailService;
        private readonly ISMSService _smsService;
        private readonly IRandomDigitService _randomDigitService;

        public UserService(IUserRepository userRepository, 
            IEmailService emailService, 
            ISMSService smsService, 
            IRandomDigitService randomDigitService) 
        {
            _repository = userRepository;
            _emailService = emailService;
            _smsService = smsService;
            _randomDigitService = randomDigitService;
        }

        public async Task<bool> RegisterAsync(CreateUserDto user)
        {
            return await _repository.CreateAsync(user);
        }

        public async Task<int> SendVerificationEmailAsync(string to)
        {
            var digits = await _randomDigitService.GenerateAsync();

            await _repository.AddEmailDigitsAsync(new EmailDigits()
            {
                Email = to,
                Digits = digits.ToString()
            });

            // send email and incloude digits inside body...
            
            //await _emailService.SendEmailAsync("Email Verification",
            //    "Your digits are: " + digits, to);

            return digits;
        }

        public async Task<bool> ValidateEmailDigitsAsync(EmailDigits emailDigits)
        {
            return await _repository.ValidateEmailDigitsAsync(emailDigits);
        }

        public async Task<int> SendVerificationSMSAsync(string to)
        {
            var digits = await _randomDigitService.GenerateAsync();

            await _repository.AddMobileDigitsAsync(new MobileDigits()
            {
                Mobile = to,
                Digits = digits.ToString()
            });

            // send sms and incloude digits inside message...

            //await _smsService.SendAsync(to, "Your digits are: " + digits);

            return digits;
        }

        public async Task<bool> ValidateMobileDigitsAsync(MobileDigits mobileDigits)
        {
            return await _repository.ValidateMobileDigitsAsync(mobileDigits);
        }

        public async Task<UserDTO> CreatePIN(CreateUserPINDto userPIN)
        {
            return await _repository.AddPINAsync(userPIN);
        }

        public async Task<UserDTO> LoginAsync(UserLoginDto userLogin)
        {
            return await _repository.LoginAsync(userLogin);
        }

    }
}
