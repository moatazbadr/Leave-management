using AutoMapper;
using LeaveManagementSystem.Application.Models.LeaveRequestModels;

namespace LeaveManagementSystem.Application.AutoMapperProfiles;

public class LeaveRequestAutoMapper : Profile
{
    public LeaveRequestAutoMapper()
    {
        CreateMap<LeaveRequestCreateVM, LeaveRequest>()
           .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
             .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
             .ForMember(dest => dest.leaveTypeId, opt => opt.MapFrom(src => src.leaveTypeId))
             .ForMember(dest => dest.RequestComments, opt => opt.MapFrom(src => src.RequestComments));

    }
}
