using LeaveManagementSystem.Web.Services.LeaveAllocationService;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    public class LeaveAllocationController1 : Controller
    {
        private readonly ILeaveAllocationService _leaveAllocationService;

        public LeaveAllocationController1(ILeaveAllocationService leaveAllocationService)
        {
            _leaveAllocationService = leaveAllocationService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
