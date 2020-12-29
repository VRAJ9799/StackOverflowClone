using StackOverflowClone.CustomsFilter;
using StackOverflowClone.ServiceLayer.Interfaces;
using StackOverflowClone.ViewModels;
using System;
using System.Web.Mvc;

namespace StackOverflowClone.Controllers
{
    public class AccountController : Controller
    {
        IUsersService UsersService;
        public AccountController(IUsersService usersService)
        {
            this.UsersService = usersService;
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                int userID = this.UsersService.InsertUser(registerViewModel);
                Session["CurrentUserID"] = userID;
                Session["CurrentUserName"] = registerViewModel.Name;
                Session["CurrentUserEmail"] = registerViewModel.Email;
                Session["CurrentUserPassword"] = registerViewModel.Password;
                Session["CurreentUserIsAdmin"] = false;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View();
            }
        }
        public ActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                UserViewModel userViewModel = this.UsersService.GetUsersByEmailAndPassword(loginViewModel.Email, loginViewModel.Password);
                if (userViewModel != null)
                {
                    Session["CurrentUserID"] = userViewModel.UserID;
                    Session["CurrentUserName"] = userViewModel.Name;
                    Session["CurrentUserEmail"] = userViewModel.Email;
                    Session["CurrentUserPassword"] = userViewModel.PasswordHash;
                    Session["CurreentUserIsAdmin"] = userViewModel.IsAdmin;
                    if (userViewModel.IsAdmin)
                    {
                        return RedirectToRoute(new { Controller = "Home", action = "Index" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("x", "Invalid Email/Password");
                    return View(loginViewModel);
                }
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View(loginViewModel);
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        [UserAuthorizationFilterAttribute]
        public ActionResult ChangeProfile()
        {
            int userID = Convert.ToInt32(Session["CurrentUserID"]);
            UserViewModel user = this.UsersService.GetUsersByUserID(userID);
            EditUserDetailsViewModel editUserDetails = new EditUserDetailsViewModel() { Name = user.Name, Email = user.Email, Mobile = user.Mobile, UserID = user.UserID };
            return View(editUserDetails);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilterAttribute]

        public ActionResult ChangeProfile(EditUserDetailsViewModel editUserDetails)
        {
            if (ModelState.IsValid)
            {
                editUserDetails.UserID = Convert.ToInt32(Session["CurrentUserID"]);
                this.UsersService.UpdateUserDetails(editUserDetails);
                Session["CurrentUserName"] = editUserDetails.Name;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View(editUserDetails);
            }
        }
        [UserAuthorizationFilter]
        public ActionResult ChangePassword()
        {
            int userID = Convert.ToInt32(Session["CurrentUserID"]);
            UserViewModel userViewModel = this.UsersService.GetUsersByUserID(userID);
            EditUserPasswordViewModel editUserPassword = new EditUserPasswordViewModel()
            {
                Email = userViewModel.Email,
                Password = "",
                ConfirmPassword = "",
                UserID = userViewModel.UserID
            };
            return View(editUserPassword);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [UserAuthorizationFilter]
        public ActionResult ChangePassword(EditUserPasswordViewModel editUserPassword)
        {
            if (ModelState.IsValid)
            {
                editUserPassword.UserID = Convert.ToInt32(Session["CurrentUserID"]);
                this.UsersService.UpdateUserPassword(editUserPassword);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View(editUserPassword);
            }
        }
    }
}