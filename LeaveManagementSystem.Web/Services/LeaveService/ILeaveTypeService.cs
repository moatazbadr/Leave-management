using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.Services.LeaveService
{
    public interface ILeaveTypeService
    {
        Task<bool> CheckLeaveType(string name);
        Task CreateAsync(LeaveTypesCreateVM leaveTypesCreate);
        Task<bool> DaysExceedMaximum(int leaveTypeId, int days);
        Task Edit(LeaveTypeEditVM leaveTypeEdit);
        Task<List<LeaveTypesReadOnly>> GetAllLeaveTypesAsync();
        Task<T?> GetleaveTypeAsync<T>(int id) where T : class;
        bool LeaveTypeExists(int id);
        Task Remove(int id);
    }
}