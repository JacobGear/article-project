using ArticleBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticleBackend.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(int id, User user);
        Task<bool> DeleteUser(int id);
    }
}
