using System;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Data
{
    public class MockUsersRepository : IUsersRepository
    {
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
            var users = new List<User>
            {
                new User{Id=1, Username="juan-rodas", Password="123456", Email="juan.rodas.manez1", CreatedOn=DateTime.Now, Block=false},
                new User{Id=2, Username="juan-perez", Password="123456", Email="juan.rodas.manez2", CreatedOn=DateTime.Now, Block=false},
                new User{Id=3, Username="jose-sanchez", Password="123456", Email="juan.rodas.manez3", CreatedOn=DateTime.Now, Block=false}
            };
            return users;
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            return new User{Id=1,Username="juan-rodas", Password="123456", Email="juan.rodas.manez@gmail.com", CreatedOn=DateTime.Now, Block=false};
        }

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}