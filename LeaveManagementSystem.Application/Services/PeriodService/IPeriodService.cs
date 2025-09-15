using LeaveManagementSystem.Application.Models.Period;

namespace LeaveManagementSystem.Application.Services.PeriodService
{
    public interface IPeriodService
    {
        Task AddAsync(PeriodCreateVM createVM);
        Task<List<PeriodReadOnly>> GetAllPeriodsAsync();
        Task<T> GetPeriodAysnc<T>(int id) where T : class;
        Task RemoveAsync(int id);
        Task updatePeriodAysnc(PeriodEditVM periodEdit);
        bool PeriodExists(int id);
        Task<bool> CheckPeriod(string name);
        Task<Period> GetCurrentPeriod();
    }
}