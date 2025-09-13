

namespace LeaveManagementSystem.Web.Services.Users
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetEmployees();
        Task<ApplicationUser> GetLoggedUser();
        Task<ApplicationUser> GetUserById(string id);
    }
}