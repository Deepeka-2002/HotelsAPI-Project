using HotelsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelsAPI.Repository.Users
{
    public class UserRepo : IUserRepo   
    {
        public HotelContext _hotelContext;

        public UserRepo(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }


        public async Task<List<User>> GetuserDetails()
        {
            var users = await _hotelContext.user.ToListAsync();
            return users;
        }

        public async Task<User?> GetUserById(int id)
        {
            var users = await _hotelContext.user.FindAsync(id);
            if (users is null)
            {
                throw new ArithmeticException("Invalid user id");
            }
            return users;
        }

        public async Task<List<User>> AddUser(User user)
        {
            _hotelContext.user.Add(user);
            await _hotelContext.SaveChangesAsync();
            return await _hotelContext.user.ToListAsync();
        }

        public async Task<List<User>?> UpdateUser(int id, User user)
        {
            var users = await _hotelContext.user.FindAsync(id);
            if (users is null)
            {
                throw new ArithmeticException("Invalid user id to update details");
            }
            users.UserName = user.UserName;
            users.Password = user.Password;
            users.UserEmail = user.UserEmail;
            users.Role = user.Role;
            await _hotelContext.SaveChangesAsync();
            return await _hotelContext.user.ToListAsync();
        }

        public async Task<List<User>?> DeleteUserById(int id)
        {
            var users = await _hotelContext.user.FindAsync(id);
            if (users is null)
            {
                throw new ArithmeticException("Invalid user id to delete");

            }
            _hotelContext.Remove(users);
            await _hotelContext.SaveChangesAsync();
            return await _hotelContext.user.ToListAsync();
        }
    }
}
