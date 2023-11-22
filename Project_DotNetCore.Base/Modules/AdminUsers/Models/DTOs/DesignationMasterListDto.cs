using System;

namespace Project_DotNetCore.Base.Modules.AdminUsers.Models.DTOs
{
    public class DesignationMasterListDto
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public bool IsActive { get; set; }
        public int Level { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}