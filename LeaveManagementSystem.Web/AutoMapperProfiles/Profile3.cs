using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveAllocation;
using LeaveManagementSystem.Web.Models.LeaveTypes;

namespace LeaveManagementSystem.Web.AutoMapperProfiles
{
    public class Profile3 : Profile
    {
       public Profile3()
        {
           CreateMap<LeaveAllocation ,LeaveAllocationVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.NumberOfDays))
                .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period))
                .ForMember(dest => dest.leaveType, opt => opt.MapFrom(src => src.LeaveType));
            CreateMap<LeaveAllocationVM, LeaveAllocation>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.NumberOfDays))
                .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period))
                .ForMember(dest => dest.LeaveType, opt => opt.MapFrom(src => src.leaveType));
            CreateMap<Period ,PeriodVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

           CreateMap<LeaveAllocation ,LeaveAllocationEditVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.NumberOfDays))
                .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period))
                .ForMember(dest => dest.leaveType, opt => opt.MapFrom(src => src.LeaveType))
                ;
            CreateMap<LeaveAllocationEditVM, LeaveAllocation>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.NumberOfDays))
                .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period))
                ;



        }
    }
}
