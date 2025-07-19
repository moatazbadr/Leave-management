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
        public async Task <IActionResult> Index()
        {
            var LeaveAllocations = _leaveAllocationService.GetAllocations();

            return View();
        }
    }
}
