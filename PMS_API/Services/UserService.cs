using PMS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_API.Model;
using System.Linq;
using PMS_Business.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using PMS_Models;

namespace PMS_API.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        private readonly IUserBusiness _userBusiness;
        public UserService(IUserBusiness userBusiness, IOptions<AppSettings> appSettings)
        {
            _userBusiness = userBusiness;
            _appSettings = appSettings.Value;
        }


        public async Task<UserApiModel> Authenticate(string username, string password)
        {
            UserApiModel user = new UserApiModel();
            user.User=await _userBusiness.Login(username, password);
            if (user == null)
            {
                return null;
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.User.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.User.RoleName.Trim())

                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                return user;


            }
        }


        public IEnumerable<UserApiModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserApiModel GetById(int id)
        {
            throw new NotImplementedException();
        }

    
    }
}
