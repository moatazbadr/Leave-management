using LeaveManagementSystem.Application.Models.LeaveRequestModels;

namespace LeaveManagementSystem.Application.Services.LeaveRequests
{
    public interface ILeaveRequestService
    {
        Task CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<List<LeaveRequestListVM>> GetEmployeeLeaveRequests();
        Task<EmployeeLeaveRequestLisVM> AdminGetAllLeaveRequests();

        Task CancelLeaveRequest(int leaveRequestId);
        Task ReviewLeaveRequest(int leaveRequestId,bool approved);
        Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model);
        Task <ReviewLeaveRequestVM> GetLeaveRequestForReview(int leaveRequestId);
    }
}