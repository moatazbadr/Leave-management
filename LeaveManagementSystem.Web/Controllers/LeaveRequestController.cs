using LeaveManagementSystem.Web.Models.LeaveRequestModels;
using LeaveManagementSystem.Web.Services.LeaveAllocationService;
using LeaveManagementSystem.Web.Services.LeaveService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagementSystem.Web.Controllers;

[Authorize]
public class LeaveRequestController(ILeaveTypeService _leaveTypeService) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
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
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Cancel(int LeaveRequestId)
    {
        return View();
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

