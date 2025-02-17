using Understand_OOP.DTOs;

namespace Understand_OOP.IServ
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserRequestDto userRequestDto);
    }
}
