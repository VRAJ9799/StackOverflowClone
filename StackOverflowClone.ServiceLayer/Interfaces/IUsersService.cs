using StackOverflowClone.ViewModels;
using System.Collections.Generic;

namespace StackOverflowClone.ServiceLayer.Interfaces
{
    public interface IUsersService
    {
        int InsertUser(RegisterViewModel registerViewModel);
        void UpdateUserDetails(EditUserDetailsViewModel editUserDetailsViewModel);
        void UpdateUserPassword(EditUserPasswordViewModel editUserPasswordViewModel);
        void DeleteUser(int userID);
        List<UserViewModel> GetUsers();
        UserViewModel GetUsersByEmailAndPassword(string Email, string Password);
        UserViewModel GetUsersByEmail(string Email);
        UserViewModel GetUsersByUserID(int userID);
    }
}
