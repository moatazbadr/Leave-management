using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>

    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "54635f9d-508d-49c5-a6a2-e5d513b2b8a1",
                    Name = "employee",
                    NormalizedName = "EMPLOYEE".ToUpper(),

                },
                new IdentityRole
                {
                    Id = "d852735f-e5bf-45d4-89ae-a1737e959552",
                    Name = "supervisor",
                    NormalizedName = "supervisor".ToUpper()

                },
                new IdentityRole
                {
                    Id = "a6932460-3d1d-4aa6-afb1-9d3c27b249c3",
                    Name = "administrator",
                    NormalizedName = "administrator".ToUpper()
                }
            );
        }
    }
}
