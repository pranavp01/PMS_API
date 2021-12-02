using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_Models;

namespace PMS_API.Model
{
    public class UserApiModel
    {
        public UserModel User { get; set; }
        public string Token { get; set; }
    }
}
