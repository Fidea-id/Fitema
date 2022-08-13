using Fitema.Models;

namespace Fitema.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<Users> GetUserByEmail(string email);
    }
}
