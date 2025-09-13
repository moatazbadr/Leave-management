using Microsoft.Identity.Client;

namespace LeaveManagementSystem.Web.Services.Users;

public class UserService(UserManager<ApplicationUser> _userManager, IHttpContextAccessor _contextAccessor) : IUserService
{
    public async Task<ApplicationUser> GetLoggedUser()
    {
        var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
        return user;
    }
    public async Task<ApplicationUser> GetUserById(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        return user;
    }
    public async Task<List<ApplicationUser>> GetEmployees()
    {
     
        var employees = await _userManager.GetUsersInRoleAsync(UserRoles.employee); 
        return employees.ToList();

    }

}
