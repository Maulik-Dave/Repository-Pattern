using Microsoft.EntityFrameworkCore;

namespace Project_DotNetCore.Base.Modules.Core.Data
{
    public interface ISeedConfiguration
    {
        void Map(ModelBuilder builder);
    }
}