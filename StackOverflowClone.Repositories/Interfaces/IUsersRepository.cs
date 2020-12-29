using StackOverflowClone.DomainModels;
using System.Collections.Generic;
namespace StackOverflowClone.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        void InsertUser(User u);
        void UpdateUserDetails(User u);
        void UpdateUserPassword(User u);
        void DeleteUser(int uid);
        List<User> GetUsers();
        List<User> GetUsersByEmailAndPassword(string Email, string Password);
        List<User> GetUsersByEmail(string Email);
        List<User> GetUsersByUserID(int UserID);
        int GetLatestUserID();
    }
}
