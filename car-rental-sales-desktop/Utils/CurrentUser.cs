using System;

using car_rental_sales_desktop.Models;

namespace car_rental_sales_desktop.Utils
{
    // Mevcut kullanıcı bilgilerini ve oturumunu yöneten statik sınıf.
    public static class CurrentUser
    {
        // Mevcut kullanıcı nesnesini tutar.
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

        // Kullanıcının şube müdürü olup olmadığını kontrol eder
        public static bool IsBranchManager()
        {
            return RoleName?.ToLower() == "branch manager";
        }

        // Kullanıcının personel olup olmadığını kontrol eder
        public static bool IsStaff()
        {
            return RoleName?.ToLower() == "staff";
        }

        // Kullanıcının teknisyen olup olmadığını kontrol eder
        public static bool IsTechnician()
        {
            return RoleName?.ToLower() == "technician";
        }

        // Kullanıcının bakım personeli olup olmadığını kontrol eder
        public static bool IsMaintenanceStaff()
        {
            return RoleName?.ToLower() == "maintenance staff";
        }

        // Kullanıcının müşteri olup olmadığını kontrol eder
        public static bool IsCustomer()
        {
            return RoleName?.ToLower() == "customer";
        }

        // Kullanıcının belirtilen işlemi yapma yetkisi var mı kontrol eder
        public static bool CanPerformAction(string action)
        {
            string role = RoleName?.ToLower();

            switch (action.ToLower())
            {
                case "manage_branches":
                    return IsAdmin();

                case "manage_staff":
                    return IsAdmin() || IsBranchManager();

                case "manage_customers":
                    return IsAdmin() || IsBranchManager() || IsStaff();

                case "manage_vehicles":
                    return IsAdmin() || IsBranchManager() || IsStaff() || IsTechnician() || IsMaintenanceStaff();

                case "manage_rentals":
                    return IsAdmin() || IsBranchManager() || IsStaff();

                case "approve_rentals":
                    return IsAdmin() || IsBranchManager() || IsStaff();

                case "manage_service":
                    return IsAdmin() || IsBranchManager() || IsTechnician() || IsMaintenanceStaff();

                case "view_reports":
                    return IsAdmin() || IsBranchManager();

                case "edit_vehicle_status":
                    return IsAdmin() || IsTechnician() || IsMaintenanceStaff();

                default:
                    return false;
            }
        }

        // Kullanıcının sadece kendi şubesindeki verileri görebilmesi için kontrol
        public static bool CanAccessBranch(int? branchId)
        {
            // Admin her şubeye erişebilir
            if (IsAdmin()) return true;

            // Şube müdürü ve personel sadece kendi şubelerine erişebilir
            if (IsBranchManager() || IsStaff())
            {
                return !BranchID.HasValue || !branchId.HasValue || BranchID.Value == branchId.Value;
            }

            return false;
        }

        // Mevcut kullanıcı bilgilerini ayarlar.
        // user: Ayarlanacak kullanıcı nesnesi.
        // ArgumentNullException: Kullanıcı nesnesi null ise fırlatılır.
        public static void SetCurrentUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user)); // Kullanıcı nesnesi boş olamaz.

            // Kullanıcı bilgilerini statik özelliklere ata.
            _currentUser = user;
            UserID = user.UserID;
            FirstName = user.UserFirstName;
            LastName = user.UserLastName;
            Username = user.Username;
            Email = user.UserEmail;
            Phone = user.UserPhone;
            RoleID = user.UserRoleID;
            RoleName = user.Role?.RoleName; // Rol null değilse rol adını al, aksi halde null ata.
            BranchID = user.UserBranchID;
            BranchName = user.Branch?.BranchName; // Şube null değilse şube adını al, aksi halde null ata.
        }

        // Mevcut kullanıcının oturumunu sonlandırır ve bilgileri sıfırlar.
        public static void Logout()
        {
            // Tüm kullanıcı bilgilerini varsayılan değerlerine döndür.
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

        // Mevcut kullanıcının yönetici (admin) olup olmadığını kontrol eder.
        // Döner: Kullanıcı yönetici ise true, değilse false döner.
        public static bool IsAdmin()
        {
            // Rol adını küçük harfe çevirip "admin" ile karşılaştır. Rol adı null ise false döner.
            return RoleName?.ToLower() == "admin";
        }

        // Mevcut kullanıcının belirtilen role erişimi olup olmadığını kontrol eder.
        // Yöneticilerin her role erişimi vardır.
        // requiredRole: Gerekli rol adı.
        // Döner: Kullanıcının role erişimi varsa true, yoksa false döner.
        public static bool HasAccess(string requiredRole)
        {
            // Gerekli rol veya mevcut kullanıcının rol adı boş veya null ise erişim yok.
            if (string.IsNullOrEmpty(requiredRole) || string.IsNullOrEmpty(RoleName))
                return false;

            // Kullanıcı yönetici ise her zaman erişimi vardır.
            if (IsAdmin())
                return true;

            // Mevcut kullanıcının rol adını küçük harfe çevirip gerekli rol adıyla (küçük harfe çevrilmiş) karşılaştır.
            return RoleName.ToLower() == requiredRole.ToLower();
        }
    }
}