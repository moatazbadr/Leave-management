using LeaveManagementSystem.Web.Models.Period;

namespace LeaveManagementSystem.Web.Services
{
    public interface IPeriodService
    {
        Task AddAsync(PeriodCreateVM createVM);
        Task<List<PeriodReadOnly>> GetAllPeriodsAsync();
        Task<T> GetPeriodAysnc<T>(int id) where T : class;
        Task RemoveAsync(int id);
        Task updatePeriodAysnc(PeriodEditVM periodEdit);
    }
}