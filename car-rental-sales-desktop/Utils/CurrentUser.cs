using System;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;

namespace car_rental_sales_desktop.Utils
{
    public static class CurrentUser
    {
        private static User _user;

        public static int UserID => _user?.UserID ?? 0;

        public static string FullName => _user != null ? $"{_user.FirstName} {_user.LastName}" : string.Empty;

        public static string Username => _user?.Username ?? string.Empty;

        public static int? BranchID => _user?.BranchID;

        public static string BranchName => _user?.Branch?.BranchName ?? "Main Branch";

        public static int RoleID => _user?.RoleID ?? 0;

        public static string RoleName => _user?.Role?.RoleName ?? string.Empty;

        public static bool IsAdmin => _user?.RoleID == 1;

        public static DateTime LoginTime { get; private set; }

        public static User User => _user;

        public static bool SetCurrentUser(User user)
        {
            if (user == null || !user.IsActive)
                return false;

            _user = user;
            LoginTime = DateTime.Now;

            var userRepository = new UserRepository();
            userRepository.UpdateLastLogin(user.UserID);

            return true;
        }

        public static void Logout()
        {
            _user = null;
        }

        public static bool HasRole(int roleId)
        {
            return _user?.RoleID == roleId;
        }

        public static void RefreshUserData()
        {
            if (_user != null)
            {
                var userRepository = new UserRepository();
                _user = userRepository.GetById(_user.UserID);
            }
        }

        public static TimeSpan GetSessionDuration()
        {
            return DateTime.Now - LoginTime;
        }
    }
}