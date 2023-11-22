using Project_DotNetCore.Base.Modules.Core.Filters;
using System;

namespace Project_DotNetCore.Base.Modules.AdminUsers.Models.DTOs
{
    public class DesignationMasterFilterDto : BaseFilterDto
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}