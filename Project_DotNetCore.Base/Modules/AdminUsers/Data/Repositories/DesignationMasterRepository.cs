using Project_DotNetCore.Base.Modules.AdminUsers.Models;
using Project_DotNetCore.Base.Modules.Core.Data;
using Project_DotNetCore.Base.Modules.Core.DTOs;

namespace Project_DotNetCore.Base.Modules.AdminUsers.Data.Repositories
{
    public interface IDesignationMasterRepository : IRepository<DesignationMaster>
    {
        IList<IdNameDto> GetDesignations();
    }

    public class DesignationMasterRepository : Repository<DesignationMaster>, IDesignationMasterRepository
    {
        public DesignationMasterRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public IList<IdNameDto> GetDesignations()
        {
            return this.AsNoTracking.OrderBy(w => w.Designation).Where(x => x.IsActive == true)
                .Select(s => new IdNameDto
                {
                    Id = (int)s.Id,
                    Name = s.Designation
                }).ToList();
        }
    }
}