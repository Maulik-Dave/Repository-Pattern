namespace Project_DotNetCore.Base.Modules.Core.Data.Seed
{
    public abstract class BaseSeed : IComparable<BaseSeed>
    {
        protected readonly SqlContext Context;
        public int OrderId { get; set; }

        public abstract void Seed();

        protected BaseSeed(SqlContext context)
        {
            Context = context;
        }

        public int CompareTo(BaseSeed other)
        {
            return OrderId.CompareTo(other.OrderId);
        }
        //Comment By Sameer
        protected void UpdateAdministratorRoleWithPermissions(int[] adminPermissionIds)
        {
            //var administratorRole = Context.Set<AdminRole>().FirstOrDefault(w => w.SystemName == "administrator");
            //if (administratorRole == null) return;

            //var adminRolesAdminPermissions = AdminRole.AddPermissionsToRole(administratorRole, adminPermissionIds);

            //foreach (var adminRolesAdminPermission in adminRolesAdminPermissions)
            //{
            //    if (Context.Set<AdminRolesAdminPermissions>().Any(w => 
            //        w.AdminRoleId == adminRolesAdminPermission.AdminRoleId &&
            //        w.AdminPermissionId == adminRolesAdminPermission.AdminPermissionId))
            //        continue;

            //    Context.Set<AdminRolesAdminPermissions>().AddRange(adminRolesAdminPermissions);
            //}

            Context.SaveChanges();
        }

        //protected void UpdateAdministratorRoleWithPermissions(AdminPermission[] permissions)
        //{
        //    UpdateAdministratorRoleWithPermissions(permissions.Select(s => s.Id).ToArray());
        //}

        //protected void UpdateAdministratorRoleWithPermissions(AdminPermission permissions)
        //{
        //    UpdateAdministratorRoleWithPermissions(new[] { permissions.Id });
        //}
        //End
        protected static string ReadFile(string moduleName, string fileName)
        {
            //return File.ReadAllText(
            //    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules", moduleName, "Data", "Seed", "Templates",
            //        fileName));
            var path = AppDomain.CurrentDomain.BaseDirectory.Contains("\\bin") ? AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.LastIndexOf("\\bin")) : AppDomain.CurrentDomain.BaseDirectory;

            return File.ReadAllText(
                Path.Combine(path, "Modules", moduleName, "Data", "Seed", "Templates",
                    fileName));
        }
    }
}