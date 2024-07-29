using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Migrations;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _dbContext;

        public UserRepository(IMapper mapper, ApplicationDBContext dBContext)
        {
            _mapper = mapper;
            _dbContext = dBContext;
        }

        public async Task<bool> CreateAsync(CreateUserDto user)
        {
            var userEntity = _mapper.Map<CreateUserDto, User>(user);
            await _dbContext.Users.AddAsync(userEntity);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExistAsync(CreateUserDto user)
        {
            return await _dbContext.Users
                .AnyAsync(x=>x.IC == user.IC || x.Email == user.Email 
                || x.Mobile == user.Mobile); 
        }

        public async Task<UserDTO> AddPINAsync(CreateUserPINDto user)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(x=>x.IC == user.IC);
            
            if (existingUser is not null)
            {
                existingUser.PIN = user.PIN;
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<User, UserDTO>(existingUser);
            }

            return null;
        }

        public async Task<UserDTO> LoginAsync(UserLoginDto user)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.IC == user.IC);
            if (existingUser is not null)
            {
                return _mapper.Map<User, UserDTO>(existingUser);
            }

            return null;
        }

        public async Task<bool> AddEmailDigitsAsync(EmailDigits digits)
        {
            var existingUser = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Email == digits.Email);

            if (existingUser is not null)
            {
                existingUser.EmailDigits = digits.Digits;

                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ValidateEmailDigitsAsync(EmailDigits digits)
        {
            var existingUser = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Email == digits.Email && x.EmailDigits == digits.Digits);
            
            if (existingUser is not null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> AddMobileDigitsAsync(MobileDigits digits)
        {
            var existingUser = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Mobile == digits.Mobile);

            if (existingUser is not null)
            {
                existingUser.MobileDigits = digits.Digits;

                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
        public async Task<bool> ValidateMobileDigitsAsync(MobileDigits digits)
        {
            var existingUser = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Mobile == digits.Mobile && x.MobileDigits == digits.Digits);

            if (existingUser is not null)
            {
                return true;
            }

            return false;
        }
    }
}
