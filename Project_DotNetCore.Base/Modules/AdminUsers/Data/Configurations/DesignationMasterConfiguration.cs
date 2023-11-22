using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_DotNetCore.Base.Modules.AdminUsers.Models;

namespace Project_DotNetCore.Base.Modules.AdminUsers.Data.Configurations
{
    public class DesignationMasterConfiguration : IEntityTypeConfiguration<DesignationMaster>
    {
        public void Configure(EntityTypeBuilder<DesignationMaster> builder)
        {
            builder.Property(a => a.Id)
                .IsRequired();

            builder.Property(t => t.Designation)
             .IsRequired()
             .HasMaxLength(150);

            builder.Property(a => a.Level)
                .IsRequired();
        }
    }
}