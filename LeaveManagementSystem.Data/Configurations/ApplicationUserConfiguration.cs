using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Data.Configurations;

public class ApplicationUserConfiguration :IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
    var hasherPassword = new PasswordHasher<ApplicationUser>();
        builder.HasData(
            new ApplicationUser
            {
                Id = "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                UserName = "admin@localhost.com",
                NormalizedUserName = "admin@localhost.com".ToUpper(),
                PasswordHash = hasherPassword.HashPassword(null, "Admin@123"),
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "User",
                DateOfBirth = new DateOnly(2001, 11, 20)
            }
            );
    }
}
