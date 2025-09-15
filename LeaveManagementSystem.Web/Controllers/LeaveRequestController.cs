
using LeaveManagementSystem.Application.Models.LeaveRequestModels;
using LeaveManagementSystem.Application.Services.LeaveRequests;
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
    public async Task<IActionResult> Create(int ? leaveTypeId)
    {
        
        var LeaveTypes= await _leaveTypeService.GetAllLeaveTypesAsync();
        var LeaveTypesList= new SelectList(LeaveTypes, "Id", "Name",leaveTypeId);
                                                       //id , name , selected value
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
    [Authorize(Policy = "admin&super")]
    public async Task<IActionResult> ListRequests()
    {
        var model = await _leaveRequestService.AdminGetAllLeaveRequests();

        return View(model);
    }

    [Authorize(Roles = UserRoles.administrator)]
    public async Task<IActionResult> Review(int leaveRequestId)
    {
      var model= await  _leaveRequestService.GetLeaveRequestForReview(leaveRequestId);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRoles.administrator)]
    public async Task<IActionResult> Review(int id, bool approved)
    {
       await _leaveRequestService.ReviewLeaveRequest(id,approved);


        return RedirectToAction(nameof(ListRequests));

    }
}

