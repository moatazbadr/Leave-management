using LeaveManagementSystem.Web.Services.LeaveAllocationService;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize]
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveAllocationService _leaveAllocationService;

        public LeaveAllocationController(ILeaveAllocationService leaveAllocationService)
        {
            _leaveAllocationService = leaveAllocationService;
        }
        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> Index()
        {
            var Employees = await _leaveAllocationService.GetEmployees();

            return View(Employees);
        }
        public async Task <IActionResult> Details(string? UserId)
        {
            var EmployeeVM = await _leaveAllocationService.GetEmployeeLeaveAllocation(UserId);

            return View(EmployeeVM);
        }
    }
}
