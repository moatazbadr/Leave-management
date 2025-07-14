using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "54635f9d-508d-49c5-a6a2-e5d513b2b8a1",
                    Name = "employee",
                    NormalizedName = "EMPLOYEE".ToUpper(),

                },
                new IdentityRole
                {
                    Id = "d852735f-e5bf-45d4-89ae-a1737e959552",
                    Name= "supervisor",
                    NormalizedName = "supervisor".ToUpper()

                },
                new IdentityRole
                {
                    Id = "a6932460-3d1d-4aa6-afb1-9d3c27b249c3",
                    Name = "administrator",
                    NormalizedName = "administrator".ToUpper()
                }
                );
            var hasherPassword = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser 
                { 
                    Id = "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName= "admin@localhost.com",
                    PasswordHash = hasherPassword.HashPassword(null, "Admin@123"),
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "User",
                    DateOfBirth = new DateOnly(2001, 11, 20)
                }
                
                );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1ce6b43c-3b0d-45b0-a069-6b4aa6b9a1e7",
                    RoleId = "a6932460-3d1d-4aa6-afb1-9d3c27b249c3"
                }
                );

        }
        public DbSet<LeaveType> leaveTypes { get; set; }
    }
}
