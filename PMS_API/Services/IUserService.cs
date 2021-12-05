using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_Models;
using PMS_API.Model;
namespace PMS_API.Services
{
    public interface IUserService
    {
        Task<UserApiModel> Authenticate(string username, string password);
        IEnumerable<UserApiModel> GetAll();
        UserApiModel GetById(int id);

    }
}
