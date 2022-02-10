using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUser();
        void CreateUser(User user);
        User GetUserById(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }   
}