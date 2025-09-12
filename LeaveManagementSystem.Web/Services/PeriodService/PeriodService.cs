using AutoMapper;
using LeaveManagementSystem.Web.Models.Period;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.PeriodService
{
    public class PeriodService : IPeriodService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PeriodService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(PeriodCreateVM createVM)
        {
            if (createVM == null)
            {
                return;
            }
            try
            {
                var period = _mapper.Map<Period>(createVM);
                await _context.periods.AddAsync(period);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception("An error occurred while adding the period.", ex);
            }

        }

        public async Task<T> GetPeriodAysnc<T>(int id) where T : class
        {
            if (id < 0)
            {
                return null;
            }
            var period = await _context.periods.FirstOrDefaultAsync(p => p.Id == id);
            if (period == null)
            {
                return null;
            }

            var periodVM = _mapper.Map<T>(period);
            return periodVM;
        }

        public async Task updatePeriodAysnc(PeriodEditVM periodEdit)
        {

            var period = _mapper.Map<Period>(periodEdit);
            if (period == null)
            {
                return;
            }
            _context.periods.Update(period);

            await _context.SaveChangesAsync();

        }
        public async Task<List<PeriodReadOnly>> GetAllPeriodsAsync()
        {
            var periods = await _context.periods.ToListAsync();
            return _mapper.Map<List<PeriodReadOnly>>(periods);
        }
        public async Task RemoveAsync(int id)
        {
            if (id < 0)
            {
                return;
            }
            var period = await _context.periods.FirstOrDefaultAsync(p => p.Id == id);
            if (period == null)
            {
                return;
            }
            _context.periods.Remove(period);
            await _context.SaveChangesAsync();
        }
        public bool PeriodExists(int id)
        {
            return _context.periods.Any(e => e.Id == id);
        }


        public async Task<bool> CheckPeriod(string name)
        {
            name = name.ToLower().Trim();
            return await _context.periods.AnyAsync(l => l.Name.ToLower().Trim() == name);
        }

        public async Task<Period> GetCurrentPeriod()
        {
            var currentDate = DateTime.Now;
            var period = await _context.periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
            return period;
        }
    }
}
