using System;
using System.Collections.Generic;
using System.Text;
using PMS_Models;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_Business.Interfaces
{
    public interface IUserBusiness
    {
        IQueryable<UserModel> GetUserById(int id);
        Task<UserModel> Login(string email, string password);
        Task<IEnumerable<UserModel>> GetUsers();
        Task<bool> AddUser(UserModel user);
        Task<bool> ChangePassword(string email, string oldPassword, string newPassword);
    }
}
