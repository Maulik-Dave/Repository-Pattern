using Project_DotNetCore.Base.Modules.AdminUsers.Data.Permissions;
using Project_DotNetCore.Base.Modules.Core.Data;
using Project_DotNetCore.Base.Modules.Core.Data.Seed;

namespace Project_DotNetCore.Base.Modules.AdminUsers.Data.Seed
{
    public class DesignationMasterPermissionsSeed : BaseSeed
    {
        public DesignationMasterPermissionsSeed(SqlContext context) : base(context)
        {
            OrderId = 2;
        }
        public override void Seed()
        {
            //Comment by Sameer
            //if (!Context.Set<AdminPermission>().Any(w => w.Name == DesignationMasterPermission.List))
            //{
            //    var listPermission = AdminPermission.Create("Designation Master", DesignationMasterPermission.List);
            //    Context.Set<AdminPermission>().Add(listPermission);
            //    Context.SaveChanges();

            //    var insertUpdateDeletePermissions = AdminPermission.CreateInsertUpdateDelete("Designation Master", DesignationMasterPermission.List, listPermission.Id);
            //    Context.Set<AdminPermission>().AddRange(insertUpdateDeletePermissions);
               
            //    Context.SaveChanges();

            //    UpdateAdministratorRoleWithPermissions(listPermission);
            //    UpdateAdministratorRoleWithPermissions(insertUpdateDeletePermissions);
            //}
            //End

        }
    }
}