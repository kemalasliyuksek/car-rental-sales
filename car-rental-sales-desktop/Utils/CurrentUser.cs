using System;

using car_rental_sales_desktop.Models;

namespace car_rental_sales_desktop.Utils
{
    public static class CurrentUser
    {
        private static User _currentUser;

        public static int UserID { get; private set; }
        public static string FirstName { get; private set; }
        public static string LastName { get; private set; }
        public static string Username { get; private set; }
        public static string Email { get; private set; }
        public static string Phone { get; private set; }
        public static int RoleID { get; private set; }
        public static string RoleName { get; private set; }
        public static int? BranchID { get; private set; }
        public static string BranchName { get; private set; }

        public static string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public static void SetCurrentUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _currentUser = user;
            UserID = user.UserID;
            FirstName = user.UserFirstName;
            LastName = user.UserLastName;
            Username = user.Username;
            Email = user.UserEmail;
            Phone = user.UserPhone;
            RoleID = user.UserRoleID;
            RoleName = user.Role?.RoleName;
            BranchID = user.UserBranchID;
            BranchName = user.Branch?.BranchName;
        }

        public static void Logout()
        {
            _currentUser = null;
            UserID = 0;
            FirstName = null;
            LastName = null;
            Username = null;
            Email = null;
            Phone = null;
            RoleID = 0;
            RoleName = null;
            BranchID = null;
            BranchName = null;
        }

        public static bool IsAdmin()
        {
            return RoleName?.ToLower() == "admin";
        }

        public static bool HasAccess(string requiredRole)
        {
            if (string.IsNullOrEmpty(requiredRole) || string.IsNullOrEmpty(RoleName))
                return false;

            // Admin has access to everything
            if (IsAdmin())
                return true;

            // Direct role match
            return RoleName.ToLower() == requiredRole.ToLower();
        }
    }
}