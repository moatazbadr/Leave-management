using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers;

[Authorize]
public class LeaveRequestController1 : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }
    public async Task<IActionResult> Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(int create )
    {
        return View();
    }
    public async Task<IActionResult> Cancel(int LeaveRequestId)
    {
        return View();
    }
}
