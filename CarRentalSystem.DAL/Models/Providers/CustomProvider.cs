using CarRentalSystem.DAL.EF;
using CarRentalSystem.DAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace CarRentalSystem.DAL.Models.Providers
{
    public class CustomProvider:RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            string[] role = new string[] { };
            using (CarRentalSystemContext db = new CarRentalSystemContext())
            {
                // Получаем пользователя
                User user = db.Users.FirstOrDefault(u => u.Email == username);
                if (user != null)
                {
                    // получаем роль
                    Role userRole = db.Roles.Find(user.RoleId);
                    if (userRole != null)
                        role = new string[] { userRole.Name };
                }
            }
            return role; ;
        }
        public override void CreateRole(string roleName)
        {
            Role newRole = new Role() { Name = roleName };
            CarRentalSystemContext db = new CarRentalSystemContext();
            db.Roles.Add(newRole);
            db.SaveChanges();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            // Находим пользователя
            using (CarRentalSystemContext db = new CarRentalSystemContext())
            {
                // Получаем пользователя
                User user = db.Users.FirstOrDefault(u => u.Email == username);
                if (user != null)
                {
                    // получаем роль
                    Role userRole = db.Roles.Find(user.RoleId);
                    //сравниваем
                    if (userRole != null && userRole.Name == roleName)
                        outputResult = true;
                }
            }
            return outputResult;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
