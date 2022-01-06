using System;
using System.Collections.Generic;
using PMS_Repository.Dtos;
using System.Threading.Tasks;
using System.Linq;

namespace PMS_Repository.Implementations
{
    public class UserRepository : Interfaces.IUserRepository
    {

        private readonly UnitOfWork.UnitOfWork _unitOfWork;


        #region Public Constructor

        public UserRepository()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork();
        }

        #endregion
        public async Task<bool> AddUser(User user)
        {
            user.CreatedAt = DateTime.Now;
            _unitOfWork.UserRepository.Insert(user);
            return await _unitOfWork.Save() >= 1 ? true : false;
        }

        public async Task<bool> ChangePassword  (string email, string oldPassword, string newPassword)
        {
            bool result = false;
            int rowsaffected;
            var user = await _unitOfWork.UserRepository.FirstOrDefault(user => user.EmailId == email);
            if (user != null)
            {
                if (user.Password == oldPassword)
                {
                    result = false;
                    throw new Exception("Please provide password which is not used before");
                }
                else
                {
                    user.Password = newPassword;
                    _unitOfWork.UserRepository.Update(user);
                    rowsaffected = await _unitOfWork.Save();
                    if(rowsaffected >= 1)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public IQueryable<User> GetUserById(int id)
        {
            //    var user = _unitOfWork.UserRepository.GetWithInclude(user => user.Id == id);
            //    if (user != null)
            //    {
            //        return user;
            //    }
            //    return null;
            //}
            return null;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> Users = await _unitOfWork.UserRepository.GetAll(d=>d.RoleNavigation);
            return Users;
        }

        public async Task<User> Login(string email, string password)
        {
            string[] navigationProperty = { "RoleNavigation" };
            var user = await _unitOfWork.UserRepository.GetWithInclude(us => us.EmailId == email, navigationProperty);
            if(user !=null)
            {
                if(user.Password==password)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
