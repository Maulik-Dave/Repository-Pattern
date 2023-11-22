namespace Project_DotNetCore.Base.Modules.Core.Helpers
{
    public class AppConfiguration
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnectionString { get; set; }
    }
}