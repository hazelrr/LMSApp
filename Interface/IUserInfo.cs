using LMS_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_App.Interface
{
    public interface IUserInfo
    {

        public Task<User> RegisterUser(User userInfo);
        public Task<User> LoginUser(Login login);
        public Task<bool> ResetPassword(ResetPassword resetPassword);
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserByEmailAddress(string emailid);

    }
}
