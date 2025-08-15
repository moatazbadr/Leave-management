using LeaveManagementSystem.Web.Models.LeaveRequestModels;
using LeaveManagementSystem.Web.Services.LeaveAllocationService;
using LeaveManagementSystem.Web.Services.LeaveRequests;
using LeaveManagementSystem.Web.Services.LeaveService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagementSystem.Web.Controllers;

[Authorize]
public class LeaveRequestController(ILeaveTypeService _leaveTypeService ,ILeaveRequestService _leaveRequestService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var model = await _leaveRequestService.GetEmployeeLeaveRequests();

        return View(model);
    }
    public async Task<IActionResult> Create()
    {
        var LeaveTypes= await _leaveTypeService.GetAllLeaveTypesAsync();
        var LeaveTypesList= new SelectList(LeaveTypes, "Id", "Name");
        var model = new LeaveRequestCreateVM
        {
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            LeaveTypes = LeaveTypesList
        };

        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LeaveRequestCreateVM model)
    {
        if (await _leaveRequestService.RequestDatesExceedAllocation(model))
        {
            ModelState.AddModelError(string.Empty, "You have exceeded your Allocation");
            ModelState.AddModelError(nameof(model.EndDate), "the number of days requested is invalid");

        }

        if (ModelState.IsValid)
        {
            await _leaveRequestService.CreateLeaveRequest(model);
            return RedirectToAction(nameof(Index));
        }

        var LeaveTypes = await _leaveTypeService.GetAllLeaveTypesAsync();
        var LeaveTypesList = new SelectList(LeaveTypes, "Id", "Name");
        model.LeaveTypes = LeaveTypesList;
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Cancel(int Id)
    {
       
         await _leaveRequestService.CancelLeaveRequest(Id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> ListRequests()
    {
        return View();
    }

    public async Task<IActionResult> Review(int leaveRequestId)
    {

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Review(/*Use view model*/)
    {

        return View();

    }
}

