using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using PMS_Business.Interfaces;
using PMS_Models;
using PMS_Repository.Interfaces;
using PMS_Repository.Dtos;

namespace PMS_Business.Implementations
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserBusiness(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddUser(UserModel user)
        {
            var userDto = _mapper.Map<User>(user);
            return await _userRepository.AddUser(userDto);
        }

        public Task<bool> ChangePassword(string email, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public  IQueryable<UserModel> GetUserById(int id)
        {
            var userDto =  _userRepository.GetUserById(id);
            return _mapper.Map<IQueryable<UserModel>>(userDto);
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var usersDto = await _userRepository.GetUsers();
            return _mapper.Map<IEnumerable<UserModel>>(usersDto);
        }

        public Task<int> Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
