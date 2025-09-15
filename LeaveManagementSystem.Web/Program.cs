using LeaveManagementSystem.Application.Models;
using LeaveManagementSystem.Application.Services.EmailService;
using LeaveManagementSystem.Application.Services.LeaveAllocationService;
using LeaveManagementSystem.Application.Services.LeaveRequests;
using LeaveManagementSystem.Application.Services.PeriodService;
using LeaveManagementSystem.Application.Services.Users;
using LeaveManagementSystem.Web.Services.LeaveService;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Application.AutoMapperProfiles;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;


namespace LeaveManagementSystem.Web;

public class Program
{

    public static void Main(string[] args)
    {
        //About this code :
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        #region Services Manager
        // Use this line to register all AutoMapper profiles from the external project:
        //builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        builder.Services.AddAutoMapper(cfg => { cfg.AddProfile<MappingProfiles>(); });

        builder.Services.AddTransient<IEmailSender, EmailSender>();
        builder.Services.AddScoped<ILeaveAllocationService, LeaveAllocationService>();

        builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
         builder.Services.AddScoped<IPeriodService, PeriodService>();
        builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("admin&super", policy =>
            {
                policy.RequireRole("Administrator", "SuperAdmin");
            }
            );

        });
        builder.Services.AddHttpContextAccessor();
        #endregion

        builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();


        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.Run();
    }
}
