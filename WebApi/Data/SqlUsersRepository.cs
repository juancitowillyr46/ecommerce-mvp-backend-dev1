using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Data
{
    public class SqlUsersRepository : IUsersRepository
    {
        private readonly AppDbContext _context;

        public SqlUsersRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault<User>(opt => opt.Id == id);
        }

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}