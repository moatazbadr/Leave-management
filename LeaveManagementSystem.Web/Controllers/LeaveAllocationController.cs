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
        [Authorize(Roles = UserRoles.administrator)]
        public async Task<IActionResult> Index()
        {
            var Employees = await _leaveAllocationService.GetEmployees();

            return View(Employees);
        }


        [Authorize(Roles = UserRoles.administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> AllocateLeave(string? Id)
        {
            await _leaveAllocationService.AllocateLeave(Id);

            return RedirectToAction(nameof(Details),new { UserId= Id }); //passed parameter 
        }
        public async Task <IActionResult> Details(string? UserId)
        {
            var EmployeeVM = await _leaveAllocationService.GetEmployeeLeaveAllocation(UserId);

            return View(EmployeeVM);
        }
    }
}
