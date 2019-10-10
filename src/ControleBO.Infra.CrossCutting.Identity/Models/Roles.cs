using System.Linq;

namespace ControleBO.Infra.CrossCutting.Identity.Models
{
    public class Roles
    {
        public const string SuperUserEmail = "aspandolfi@gmail.com";

        public const string SuperUser = "SuperUser";

        public const string Admin = "Admin";

        public const string User = "User";

        public const string Viewer = "Viewer";

        public const string SuperUserAdmin = SuperUser + "," + Admin;

        public const string SuperUserAdminUser = SuperUserAdmin + "," + User;

        public static bool Contains(string role)
        {
            return GetAll.Contains(role);
        }

        internal static string[] GetAll = new string[] { SuperUser, Admin, User, Viewer };
    }
}
