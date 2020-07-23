using System;
using System.Linq;

namespace Connections
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IWinSettingProvider _settingProvider;

        public UserService(IWinSettingProvider settingProvider)
        {
            _settingProvider = settingProvider;
        }

        public IWinSettingProvider SettingProvider
        {
            get { return _settingProvider; }
        }

        public UserResponse SaveUser(UserRequest request)
        {
            Logger.Info("SaveUser(): Saving user {0}", LocalStore.CurrentUser.UserName);
            var response = new UserResponse();

            User user = request.User;
            LoginInformation loginInfo = user.LoginInformations;
            loginInfo.AccessedDate = DateTime.Today;

            var isUserIdExists = DbContext.Users.Any(x => x.UserId == user.UserId);
            var isUserNameExists = DbContext.Users.Any(x => x.LoginInformations.Username == user.LoginInformations.Username);
            var isUserEmailIdExists = DbContext.Users.Any(x => x.Email == user.Email);
            var isSuperUserExists = request.User.LoginInformations.UserType == UserType.SuperUser;

            if (user.UserId == 0)
            {
                if (isUserIdExists)
                {
                    Logger.Warn("SaveUser(): User Id {0} already exists", LocalStore.CurrentUser.UserId);
                    response.AddValidationError("UserId", "User Id already exists!");
                }
                else if (isUserNameExists)
                {
                    Logger.Warn("SaveUser(): Username {0} already exists", LocalStore.CurrentUser.UserName);
                    response.AddValidationError("Username", "User name already exists!");
                }

                else if (isUserEmailIdExists)
                {
                    Logger.Warn("SaveUser(): Email {0} already exists", LocalStore.CurrentUser.Email);
                    response.AddValidationError("Email", "Email Id already exists!");
                }

                else if (isSuperUserExists)
                {
                    Logger.Fatal("SaveUser(): System cannot have multiple Superuser");
                    throw new InvalidOperationException("System cannot have multiple Superuser");
                }
                
            }
            else
            {
                // LoginInformation is a saparate entity and need query again for finding older values
                var originalloginInfo = GetOriginalRecord(loginInfo);
                var originaluser = GetOriginalRecord(user);

                if (user.LoginInformations.Username != (String)originalloginInfo["Username"] && isUserNameExists)
                {
                    Logger.Warn("SaveUser(): Username {0} already exists", LocalStore.CurrentUser.UserName);
                    response.AddValidationError("Username", "User name already exists!");
                }

                if (user.Email != (String)originaluser["Email"] && isUserEmailIdExists)
                {
                    Logger.Warn("SaveUser(): Email {0} already exists", LocalStore.CurrentUser.Email);
                    response.AddValidationError("Email", "Email Id already exists!");
                }

            }

            if (response.IsValid == false)
                return response;

            user.AccessedBy = LocalStore.CurrentUser.UserId;
            user.AccessedDate = DateTime.Now;
            if (user.UserId == 0)
            {
                DbContext.Users.AddObject(user);
            }
            // Save user
            DbContext.SaveChanges();
            Logger.Info("SaveUser(): User {0} Saved", LocalStore.CurrentUser.UserId);

            return response;
        }

        public User AuthenticateUser(UserLoginRequest request)
        {
            var loginInfo = DbContext.LoginInformations.SingleOrDefault(x => x.IsActive
                                                                             && String.Compare(x.Username, request.UserName, StringComparison.OrdinalIgnoreCase) == 0
                                                                             && String.Compare(x.Password, request.Password) == 0);

            Logger.Debug("AuthenticateUser(): Logging in..");
            if (loginInfo == null)
            {
                Logger.Warn("AuthenticateUser(): User not found..");
                return null;
            }

            var user = loginInfo.User;

            // update the last login date
            user.LastLoginDate = DateTime.Now;
            DbContext.SaveChanges();
            Logger.Info("AuthenticateUser(): User {0} Successfully logged in", loginInfo.Username);
            return user;
        }

        public User GetUserByUserName(string userName)
        {
            var user = DbContext.LoginInformations.SingleOrDefault(x => String.Compare(x.Username, userName, StringComparison.OrdinalIgnoreCase) == 0);

            if (user != null) 
                return user.User;

            return null;
        }

        public IQueryable<User> GetAllUser()
        {
            return DbContext.Users.Where(x => x.LoginInformations.UserType_Enum != (short)UserType.SuperUser);
        }
    }
}