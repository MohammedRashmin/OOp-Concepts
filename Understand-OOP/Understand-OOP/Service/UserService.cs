using Microsoft.AspNetCore.Identity;
using Understand_OOP.Database.Entities;
using Understand_OOP.DTOs;
using Understand_OOP.IRep;
using Understand_OOP.IServ;
using Understand_OOP.Repository;

namespace Understand_OOP.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly ILogger<UserService> _logger;

        public UserService(UserRepo userRepo, ILogger<UserService> logger)
        {
            _userRepo = userRepo;
            _logger = logger;
        }

        public async Task<bool> CreateUser(UserRequestDto userRequestDto)
        {
            try
            {
                ValidateUser(userRequestDto);

                var user = new User
                {
                    Name = userRequestDto.Name,
                    Email = userRequestDto.Email,
                    Password = userRequestDto.Password
                };

                var result = await _userRepo.CreateUser(user);

                if (result)
                    _logger.LogInformation($"User {user.Email} created successfully.");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CreateUser: {ex.Message}");
                return false;
            }
        }

        private void ValidateUser(UserRequestDto userRequestDto)
        {
            if (string.IsNullOrWhiteSpace(userRequestDto.Email) || string.IsNullOrWhiteSpace(userRequestDto.Password))
                throw new Exception("Email and Password are required.");
        }
    }
    }

