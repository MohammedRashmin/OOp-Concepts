using Microsoft.EntityFrameworkCore;
using Understand_OOP.Controllers;
using Understand_OOP.Database;
using Understand_OOP.Database.Entities;
using Understand_OOP.IRep;

namespace Understand_OOP.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly DataDbContext _dbContext;

        public UserRepo(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateUser(User user)
        {
            var checkUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (checkUser != null)
            {
                throw new Exception("User with this email already exists!");
            }

            await _dbContext.Users.AddAsync(user);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
