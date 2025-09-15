using LeaveManagementSystem.Application.Models;
using LeaveManagementSystem.Application.Models.LeaveAllocation;
using LeaveManagementSystem.Web.Services.LeaveService;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize]
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveAllocationService _leaveAllocationService;
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveAllocationController(ILeaveAllocationService leaveAllocationService ,ILeaveTypeService leaveTypeService)
        {
            _leaveAllocationService = leaveAllocationService;
            _leaveTypeService = leaveTypeService;
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
        
        [Authorize(Roles= UserRoles.administrator)]
        public async Task<IActionResult> EditAllocation(int ? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var allocation = await _leaveAllocationService.GetAllocationForEmployee(Id.Value);
            if(allocation is null)
            {
                return NotFound();
            }


            return View(allocation);
        }

        [Authorize(Roles = UserRoles.administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(LeaveAllocationEditVM leaveAllocationEdit)
        {
            if ( await _leaveTypeService.DaysExceedMaximum(leaveAllocationEdit.leaveType.Id,leaveAllocationEdit.NumberOfDays))
            {
                ModelState.AddModelError("DaysExceeded", "the allocation exceeds the max days");
         
            }
           if (ModelState.IsValid)
            {
                await _leaveAllocationService.EditAllocation(leaveAllocationEdit);
                return RedirectToAction(nameof(Details), new { UserId = leaveAllocationEdit.Employee.Id });
            }
           var days =leaveAllocationEdit.NumberOfDays;

            leaveAllocationEdit = await _leaveAllocationService.GetAllocationForEmployee(leaveAllocationEdit.Id);
            leaveAllocationEdit.NumberOfDays = days; 
            return View(leaveAllocationEdit);
        }

        public async Task <IActionResult> Details(string? UserId)
        {
            var EmployeeVM = await _leaveAllocationService.GetEmployeeLeaveAllocation(UserId);

            return View(EmployeeVM);
        }
    }
}
