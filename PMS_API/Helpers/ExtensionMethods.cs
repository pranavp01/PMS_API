using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMS_Models;
using PMS_API.Model;

namespace PMS_API.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<UserApiModel> WithoutPasswords(this IEnumerable<UserApiModel> users)
        {
            if (users == null) return null;

            return users.Select(x => x.WithoutPassword());
        }

        public static UserApiModel WithoutPassword(this UserApiModel user)
        {
            if (user == null) return null;

            user.User.Password = null;
            return user;
        }
    }
}
