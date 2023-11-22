using Project_DotNetCore.Base.Modules.Core.Data;
using System;
using System.Collections.Generic;

namespace Project_DotNetCore.Base.Modules.AdminUsers.Models
{
    public class DesignationMaster : ITrackable
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public int Level { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}