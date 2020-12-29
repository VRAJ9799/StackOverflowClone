using StackOverflowClone.DomainModels;
using StackOverflowClone.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace StackOverflowClone.Repositories
{

    public class UsersRepository : IUsersRepository
    {
        StackOverflowDatabaseDbContext db;
        public UsersRepository()
        {
            db = new StackOverflowDatabaseDbContext();
        }
        public void InsertUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void UpdateUserDetails(User user)
        {
            User obj = db.Users.Where(temp => temp.UserID == user.UserID).FirstOrDefault();
            if (obj != null)
            {
                obj.Name = user.Name;
                obj.Mobile = user.Mobile;
                db.SaveChanges();
            }
        }
        public void UpdateUserPassword(User user)
        {
            User obj = db.Users.Where(temp => temp.UserID == user.UserID).FirstOrDefault();
            if (obj != null)
            {
                obj.PasswordHash = user.PasswordHash;
                db.SaveChanges();
            }
        }
        public void DeleteUser(int UserID)
        {
            User user = db.Users.Where(temp => temp.UserID == UserID).FirstOrDefault();
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }

        }
        public List<User> GetUsers()
        {
            List<User> users = db.Users.Where(temp => temp.IsAdmin == false).OrderBy(temp => temp.Name).ToList();
            return users;
        }
        public List<User> GetUsersByEmailAndPassword(string Email, string Password)
        {
            List<User> users = db.Users.Where(temp => temp.Email == Email && temp.PasswordHash == Password).ToList();
            return users;
        }
        public List<User> GetUsersByEmail(string Email)
        {
            List<User> users = db.Users.Where(temp => temp.Email == Email).ToList();
            return users;
        }
        public List<User> GetUsersByUserID(int UserID)
        {
            List<User> users = db.Users.Where(temp => temp.UserID == UserID).ToList();
            return users;
        }
        public int GetLatestUserID()
        {
            int UserID = db.Users.Select(temp => temp.UserID).Max();
            return UserID;
        }

    }
}
