using Z.EntityFramework.Plus;

namespace Project_DotNetCore.Base.Modules.AdminUsers.CacheManagers
{
    public class DesignationMasterCacheManager
    {
        public static void ClearCache()
        {
            QueryCacheManager.ExpireTag(Name);
        }
        public static string Name { get; set; } = "DesignationMaster";
    }
}