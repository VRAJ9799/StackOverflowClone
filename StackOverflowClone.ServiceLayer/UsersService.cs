using AutoMapper;
using StackOverflowClone.DomainModels;
using StackOverflowClone.Repositories;
using StackOverflowClone.Repositories.Interfaces;
using StackOverflowClone.ServiceLayer.Interfaces;
using StackOverflowClone.ViewModels;
using System.Collections.Generic;
using System.Linq;
namespace StackOverflowClone.ServiceLayer
{

    public class UsersService : IUsersService
    {
        IUsersRepository UsersRepository;
        public UsersService()
        {
            UsersRepository = new UsersRepository();
        }

        public int InsertUser(RegisterViewModel registerViewModel)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<RegisterViewModel, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            User user = mapper.Map<RegisterViewModel, User>(registerViewModel);
            user.PasswordHash = SHA256Generator.GenerateHash(registerViewModel.Password);
            UsersRepository.InsertUser(user);
            int uid = UsersRepository.GetLatestUserID();
            return uid;
        }
        public void UpdateUserDetails(EditUserDetailsViewModel editUserDetailsViewModel)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserDetailsViewModel, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            User user = mapper.Map<EditUserDetailsViewModel, User>(editUserDetailsViewModel);
            UsersRepository.UpdateUserDetails(user);
        }
        public void UpdateUserPassword(EditUserPasswordViewModel editUserPasswordViewModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EditUserPasswordViewModel, User>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            User user = mapper.Map<EditUserPasswordViewModel, User>(editUserPasswordViewModel);
            user.PasswordHash = SHA256Generator.GenerateHash(editUserPasswordViewModel.Password);
            UsersRepository.UpdateUserPassword(user);
        }
        public void DeleteUser(int userID)
        {
            UsersRepository.DeleteUser(userID);
        }
        public List<UserViewModel> GetUsers()
        {
            List<User> users = UsersRepository.GetUsers();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            List<UserViewModel> userViewModels = mapper.Map<List<User>, List<UserViewModel>>(users);
            return userViewModels;

        }
        public UserViewModel GetUsersByEmailAndPassword(string Email, string Password)
        {
            User user = UsersRepository.GetUsersByEmailAndPassword(Email, SHA256Generator.GenerateHash(Password)).FirstOrDefault();
            UserViewModel userViewModel = null;
            if (user != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserViewModel>();
                    cfg.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                userViewModel = mapper.Map<User, UserViewModel>(user);
            }
            return userViewModel;
        }
        public UserViewModel GetUsersByEmail(string Email)
        {
            User user = UsersRepository.GetUsersByEmail(Email).FirstOrDefault();
            UserViewModel userViewModel = null;
            if (user != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserViewModel>();
                    cfg.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                userViewModel = mapper.Map<User, UserViewModel>(user);
            }
            return userViewModel;
        }
        public UserViewModel GetUsersByUserID(int userID)
        {
            User user = UsersRepository.GetUsersByUserID(userID).FirstOrDefault();
            UserViewModel userViewModel = null;
            if (user != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserViewModel>();
                    cfg.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                userViewModel = mapper.Map<User, UserViewModel>(user);
            }
            return userViewModel;
        }
    }
}
