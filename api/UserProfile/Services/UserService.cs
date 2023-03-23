using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace UserProfile.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> AddUser(User user);
    }
    public class UserService : IUserService
    {
        private readonly UserContext _context;
        public UserService(UserContext context)
        {
            _context = context;
        }
        public async Task<User> AddUser(User user)
        {
            user.UserId = Guid.NewGuid();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            List<User> users = await _context.Users.ToListAsync();
            return users;
        }
    }
}
