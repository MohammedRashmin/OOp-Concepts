using Understand_OOP.Database.Entities;

namespace Understand_OOP.IRep
{
    public interface IUserRepo
    {
        Task<bool> CreateUser(User user);
    }
}
