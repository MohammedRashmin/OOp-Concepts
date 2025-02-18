using Microsoft.EntityFrameworkCore;
using Understand_OOP.Database;
using Understand_OOP.Database.Entities;
using Understand_OOP.IRep;
using Microsoft.Extensions.Logging;

namespace Understand_OOP.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly DataDbContext _dbContext;
        private readonly ILogger<UserRepo> _logger;

        public UserRepo(DataDbContext dbContext, ILogger<UserRepo> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> CreateUser(User user)
        {
            var checkUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (checkUser != null)
            {
                _logger.LogWarning($"User with email {user.Email} already exists.");
                throw new Exception("User with this email already exists!");
            }

            await _dbContext.Users.AddAsync(user);
            var saved = await _dbContext.SaveChangesAsync() > 0;

            if (!saved)
            {
                _logger.LogError("Failed to save user to the database.");
                throw new Exception("Failed to save user to the database.");
            }

            _logger.LogInformation($"User {user.Email} created successfully.");
            return saved;
        }
    }
}
