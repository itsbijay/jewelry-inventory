using System.Linq;

namespace Connections
{
    public interface IUserService
    {
        UserResponse SaveUser(UserRequest request);
        User AuthenticateUser(UserLoginRequest request);
        User GetUserByUserName(string userName);
        IQueryable<User> GetAllUser();
    }
}