using Project_DotNetCore.Base.Modules.AdminUsers.Models;
using Project_DotNetCore.Base.Modules.Core.Filters;
using Project_DotNetCore.Base.Modules.Core.ListOrders;
using System.Linq;

namespace Project_DotNetCore.Base.Modules.AdminUsers.ListOrders
{
    public class DesignationMasterListOrder : BaseListOrder<DesignationMaster>
    {
        public DesignationMasterListOrder(IQueryable<DesignationMaster> query, BaseFilterDto dto) : base(query, dto)
        {
        }
        internal void CreatedAt()
        {
            Query = OrderBy(o => o.CreatedAt);
        }
    }
}