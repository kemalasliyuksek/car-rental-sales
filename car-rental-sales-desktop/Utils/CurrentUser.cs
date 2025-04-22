using System;
using car_rental_sales_desktop.Models;
using car_rental_sales_desktop.Repositories;

namespace car_rental_sales_desktop.Utils
{
    /// <summary>
    /// Static class to manage the current logged-in user information throughout the application
    /// </summary>
    public static class CurrentUser
    {
        // Properties
        private static User _user;

        /// <summary>
        /// Gets the ID of the currently logged-in user
        /// </summary>
        public static int UserID => _user?.UserID ?? 0;

        /// <summary>
        /// Gets the full name of the currently logged-in user
        /// </summary>
        public static string FullName => _user != null ? $"{_user.FirstName} {_user.LastName}" : string.Empty;

        /// <summary>
        /// Gets the username of the currently logged-in user
        /// </summary>
        public static string Username => _user?.Username ?? string.Empty;

        /// <summary>
        /// Gets the branch ID of the currently logged-in user
        /// </summary>
        public static int? BranchID => _user?.BranchID;

        /// <summary>
        /// Gets the branch name of the currently logged-in user
        /// </summary>
        public static string BranchName => _user?.Branch?.BranchName ?? "Genel Merkez";

        /// <summary>
        /// Gets the role ID of the currently logged-in user
        /// </summary>
        public static int RoleID => _user?.RoleID ?? 0;

        /// <summary>
        /// Gets the role name of the currently logged-in user
        /// </summary>
        public static string RoleName => _user?.Role?.RoleName ?? string.Empty;

        /// <summary>
        /// Gets whether the user is an administrator
        /// </summary>
        public static bool IsAdmin => _user?.RoleID == 1; // Assuming role ID 1 is Admin

        /// <summary>
        /// Gets the login time for the current session
        /// </summary>
        public static DateTime LoginTime { get; private set; }

        /// <summary>
        /// Gets the current User object
        /// </summary>
        public static User User => _user;

        /// <summary>
        /// Sets the current user and logs the login time
        /// </summary>
        /// <param name="user">The user to set as current</param>
        /// <returns>True if successful, false otherwise</returns>
        public static bool SetCurrentUser(User user)
        {
            if (user == null || !user.IsActive)
                return false;

            _user = user;
            LoginTime = DateTime.Now;

            // Update the LastLogin time in the database
            var userRepository = new UserRepository();
            userRepository.UpdateLastLogin(user.UserID);

            return true;
        }

        /// <summary>
        /// Clears the current user when logging out
        /// </summary>
        public static void Logout()
        {
            _user = null;
        }

        /// <summary>
        /// Checks if the current user has a specific role
        /// </summary>
        /// <param name="roleId">The role ID to check</param>
        /// <returns>True if the user has the role, false otherwise</returns>
        public static bool HasRole(int roleId)
        {
            return _user?.RoleID == roleId;
        }

        /// <summary>
        /// Refreshes the current user data from the database
        /// </summary>
        public static void RefreshUserData()
        {
            if (_user != null)
            {
                var userRepository = new UserRepository();
                _user = userRepository.GetById(_user.UserID);
            }
        }

        /// <summary>
        /// Gets the current session duration
        /// </summary>
        /// <returns>The time elapsed since login</returns>
        public static TimeSpan GetSessionDuration()
        {
            return DateTime.Now - LoginTime;
        }
    }
}