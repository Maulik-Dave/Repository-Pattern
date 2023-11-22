using Project_DotNetCore.Base.Modules.AdminUsers.Models;
using Project_DotNetCore.Base.Modules.AdminUsers.Models.DTOs;
using Project_DotNetCore.Base.Modules.Core.Filters;

namespace Project_DotNetCore.Base.Modules.AdminUsers.Filters
{
    public class DesignationMasterFilter : BaseFilter<DesignationMaster, DesignationMasterFilterDto>
    {
        public DesignationMasterFilter(IQueryable<DesignationMaster> query, DesignationMasterFilterDto dto) : base(query, dto)
        {
        }
        internal void FromCreatedAt()
        {
            Query = Query.Where(w => w.CreatedAt >= Dto.FromCreatedAt);
        }
        internal void ToCreatedAt()
        {
            Query = Query.Where(w => w.CreatedAt <= Dto.ToCreatedAt);
        }
    }
}