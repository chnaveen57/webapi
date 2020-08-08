using CarPooling.Models;
using System.Collections.Generic;

namespace CarPoolingServices.IServices
{
    public interface IUserServices
    {
        List<UserViewModel> GetUsers();
        bool IsUserExits(string userId);
        bool UpdateUser(UserViewModel user);
        UserViewModel UserData(string userId, string password);
        UserViewModel GetUserName(string Id);
        bool AddUser(UserViewModel user);
        UserViewModel GetUserById(string userId);
    }
}
