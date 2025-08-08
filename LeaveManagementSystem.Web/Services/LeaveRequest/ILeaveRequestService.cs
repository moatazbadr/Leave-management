using LeaveManagementSystem.Web.Models.LeaveRequestModels;

namespace LeaveManagementSystem.Web.Services.LeaveRequest
{
    public interface ILeaveRequestService
    {
        Task CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<EmployeeLeaveRequestLisVM> GetEmployeeLeaveRequests();
        Task<LeaveRequestListVM> GetAllLeaveRequests();

        Task CancelLeaveRequest(int leaveRequestId);
        Task ReviewLeaveRequest(ReviewLeaveRequestVM model);

    }
}