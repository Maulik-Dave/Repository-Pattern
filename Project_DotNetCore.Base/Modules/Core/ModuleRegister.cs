using Microsoft.AspNetCore.Routing;
using Project_DotNetCore.Base.Modules.Core.Helpers;

namespace Project_DotNetCore.Base.Modules.Core.Modules
{
    public static class ModuleRegister
    {
        private static readonly IEnumerable<BaseModule> Modules;

        static ModuleRegister()
        {
            Modules = ObjectHelper.GetEnumerableOfType<BaseModule>(null);
        }

        public static void RegisterBackgroundJobs()
        {
            foreach (var module in Modules)
                module.RegisterBackgroundJobs();
        }

        public static void RegisterModuleRoutes(IEndpointRouteBuilder endpoint)
        {
            foreach (var module in Modules)
                module.RegisterRoutes(endpoint);
        }
    }
}