using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<bool> ChangePassword(string email, string oldPassword, string newPassword)
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
            var user = _unitOfWork.UserRepository.GetWithInclude(user => user.Id == id);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> Users = await _unitOfWork.UserRepository.GetAll();
            return Users;
        }

        public Task<int> Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
