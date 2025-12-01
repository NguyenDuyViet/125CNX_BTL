using _125CNX_ECommerce.Models;
using ShoeShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Service
{
    class UserService
    {
        private UserDao user;

        public UserService()
        {
            user = new UserDao();
        }

        public async Task<UsersModel> CheckLogin(string username, string password)
        {
            return await user.CheckLogin(username, password);
        }
    }
}
