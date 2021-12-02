using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_Repository.Dtos;

namespace PMS_Repository.Interfaces
{
   public interface IUserRepository
    {
        IQueryable<User> GetUserById(int id);
        Task<User> Login(string email, string password);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> AddUser(User user);
        Task<bool> ChangePassword(string email, string oldPassword, string newPassword);
    }
}
