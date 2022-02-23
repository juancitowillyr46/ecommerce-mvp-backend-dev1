using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Data
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
        User GetUserById(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User GetUserByEmail(string email);
    }   
}