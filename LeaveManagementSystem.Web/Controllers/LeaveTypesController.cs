using LeaveManagementSystem.Application.Models.LeaveTypes;
using LeaveManagementSystem.Web.Services.LeaveService;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize(Roles = "administrator")]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _leaveTypeService.GetAllLeaveTypesAsync();
            return View(data);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var leaveType = await _leaveTypeService.GetleaveTypeAsync<LeaveTypesReadOnly>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypesCreateVM leaveTypesCreateVM)
        {
            if (leaveTypesCreateVM.Name.Contains("vacation"))
            {
                ModelState.AddModelError(nameof(leaveTypesCreateVM.Name), "you're kidding me Right ???");
            }

            bool leaveTypeExists = await _leaveTypeService.CheckLeaveType(leaveTypesCreateVM.Name);

            if (leaveTypeExists)
            {
                ModelState.AddModelError(nameof(leaveTypesCreateVM.Name), "This Leave Type already Exists");

            }
            if (ModelState.IsValid)
            {
                await _leaveTypeService.CreateAsync(leaveTypesCreateVM);
                return RedirectToAction(nameof(Index));
            }

            return View(leaveTypesCreateVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypeService.GetleaveTypeAsync<LeaveTypeEditVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
        {

            bool leaveTypeExists = await _leaveTypeService.CheckLeaveType(leaveTypeEdit.Name);

            if (leaveTypeExists && (id != leaveTypeEdit.Id))
            {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), "This Leave Type already Exists");
            }

            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _leaveTypeService.Edit(leaveTypeEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_leaveTypeService.LeaveTypeExists(leaveTypeEdit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEdit);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypeService.GetleaveTypeAsync<LeaveTypesReadOnly>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _leaveTypeService.Remove(id);


            return RedirectToAction(nameof(Index));
        }


    }
}
