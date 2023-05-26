using HotelsAPI.Models;

namespace HotelsAPI.Repository.Users
{
    public interface IUserRepo
    {
        Task<List<User>> GetuserDetails();
        Task<User?> GetUserById(int id);
        Task<List<User>> AddUser(User user);
        Task<List<User>?> UpdateUser(int id, User user);
        Task<List<User>?> DeleteUserById(int id);

    }
}
