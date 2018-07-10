using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using DALC;

namespace WebSafe
{
    public class ProveedorRol : RoleProvider
    {
        private int _cacheTimeoutInMinute = 20;
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
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

        public override string[] GetRolesForUser(string username)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            var cacheKey = string.Format("{0}_role", username);
            if (HttpRuntime.Cache[cacheKey] != null)
            {
                return (string[])HttpRuntime.Cache[cacheKey];
            }
            string[] roleNames = new string[] { };
            using (SafeEntities se = new SafeEntities())
            {
                //DataBaseConnection.ORM.USUARIO user = db.USUARIO.FirstOrDefault(x => x.USERNAME.Equals(username));
                //var roleNames = db.ROL.Where(x => x.USUARIO.Equals(user)).Select(x => x.NOMBRE).ToList();
                roleNames = (from rol in se.TIPO_USUARIO
                             where rol.USUARIO.Any(x => x.USERNAME.Equals(username))
                             select rol.ROL).ToArray<string>();

                if (roleNames.Count() > 0)
                {
                    HttpRuntime.Cache.Insert(cacheKey, roleNames, null, DateTime.Now.AddMinutes(_cacheTimeoutInMinute), Cache.NoSlidingExpiration);
                }
            }

            return roleNames;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var userRoles = GetRolesForUser(username);
            return userRoles.Contains(roleName);
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