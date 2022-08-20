using FitemaEntity.Models;

namespace FitemaAPI.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<Users> GetUserByEmail(string email);
        Task<int> CreateUser(Users user);
        Task<Users> GetUserById(int id);
    }
}
