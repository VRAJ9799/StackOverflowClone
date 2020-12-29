using StackOverflowClone.ServiceLayer.Interfaces;
using System.Web.Http;

namespace StackOverflowClone.ApiControllers
{
    public class AccountController : ApiController
    {
        IUsersService UsersService;
        public AccountController(IUsersService usersService)
        {
            this.UsersService = usersService;
        }
        public string Get(string Email)
        {
            if (this.UsersService.GetUsersByEmail(Email) != null)
            {
                return "Found";
            }
            else
            {
                return "Not Found";
            }
        }
    }
}
