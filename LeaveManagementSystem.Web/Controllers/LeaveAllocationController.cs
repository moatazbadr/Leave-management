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
        public async Task <IActionResult> Details()
        {
            var EmployeeVM = await _leaveAllocationService.GetEmployeeLeaveAllocation();

            return View(EmployeeVM);
        }
    }
}
