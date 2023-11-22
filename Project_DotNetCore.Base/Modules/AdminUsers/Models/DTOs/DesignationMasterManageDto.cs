using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_DotNetCore.Base.Modules.AdminUsers.Models.DTOs
{
    public class DesignationMasterManageDto
    {
        public int Id { get; set; }
        [DisplayName("Designation")]
        [Required(ErrorMessage = "Designation is Required")]
        public string Designation { get; set; }

        [DisplayName("Level")]
        [Required(ErrorMessage = "Level is Required")]
        public int Level { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}