using LeaveManagementSystem.Web.Models.LeaveRequestModels;

namespace LeaveManagementSystem.Web.Services.LeaveRequests
{
    public interface ILeaveRequestService
    {
        Task CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<List<LeaveRequestListVM>> GetEmployeeLeaveRequests();
        Task<EmployeeLeaveRequestLisVM> AdminGetAllLeaveRequests();

        Task CancelLeaveRequest(int leaveRequestId);
        Task ReviewLeaveRequest(ReviewLeaveRequestVM model);
        Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model);
        Task <ReviewLeaveRequestVM> GetLeaveRequestForReview(int leaveRequestId);
    }
}