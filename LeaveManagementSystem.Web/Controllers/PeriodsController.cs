using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Data;
using AutoMapper;
using LeaveManagementSystem.Web.Models.Period;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using LeaveManagementSystem.Web.Services.PeriodService;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize(Roles = "administrator")]
    public class PeriodsController : Controller
    {
      
        private readonly IPeriodService _periodService;
        private readonly IMapper _mapper;

        public PeriodsController(IPeriodService periodService ,IMapper mapper)
        {
            _periodService = periodService;
            _mapper = mapper;
        }

        

        // GET: Periods
        public async Task<IActionResult> Index()
        {
            var data = await _periodService.GetAllPeriodsAsync();

            if (data == null || !data.Any())
            {
                return View("NoDataFound");
            }
            
            return View(data);
        }

        // GET: Periods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var period = await _periodService.GetPeriodAysnc<PeriodReadOnly>(id.Value);
            if (period == null)
            {
                return NotFound();
            }

            return View(period);
        }

        // GET: Periods/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PeriodCreateVM period)
        {
            
            var existingPeriod = await _periodService.CheckPeriod(period.Name);

            if (existingPeriod)
            {
                ModelState.AddModelError(nameof(period.Name), "This period already exists.");
            }

            if (ModelState.IsValid)
            {
                 await  _periodService.AddAsync(period);

                return RedirectToAction(nameof(Index));
            }
            return View(period);
        }

        // GET: Periods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var period = await _periodService.GetPeriodAysnc<PeriodEditVM>(id.Value);
            if (period == null)
            {
                return NotFound();
            }
            return View(period);
        }

        // POST: Periods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PeriodEditVM period)
        {
            if (id != period.Id)
            {
                return NotFound();
            }
            bool leaveTypeExists = await _periodService.CheckPeriod(period.Name);

            if (leaveTypeExists && (id != period.Id))
            {
                ModelState.AddModelError(nameof(period.Name), "This Leave Type already Exists");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _periodService.updatePeriodAysnc(period);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_periodService.PeriodExists(period.Id))
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
            return View(period);
        }

        // GET: Periods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var period = await _periodService.GetPeriodAysnc<PeriodReadOnly>(id.Value);
            if (period == null)
            {
                return NotFound();
            }

            return View(period);
        }

        // POST: Periods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _periodService.RemoveAsync(id);
          
            return RedirectToAction(nameof(Index));
        }

        
    }
}
