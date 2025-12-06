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

        public async Task<List<UsersModel>> GetAllUsers()
        {
            return await user.GetAllUser();
        }

        public async Task<bool> UpdateUser(UsersModel us)
        {
            return await user.UpdateUser(us);
        }

		public async Task<bool> DeleteUser(int UID)
		{
			return await user.DeleteUser(UID);
		}

        public async Task<bool> AddUser(UsersModel us)
        {
            return await user.AddUser(us);
        }
	}
}
