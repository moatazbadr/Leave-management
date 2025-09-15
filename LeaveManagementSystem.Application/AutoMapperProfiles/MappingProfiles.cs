using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.AutoMapperProfiles;
using AutoMapper;
using LeaveManagementSystem.Application.Models.LeaveRequestModels;
using LeaveManagementSystem.Application.Models.LeaveTypes;
using LeaveManagementSystem.Application.Models.Period;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LeaveRequestCreateVM, LeaveRequest>()
      .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
        .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
        .ForMember(dest => dest.leaveTypeId, opt => opt.MapFrom(src => src.leaveTypeId))
        .ForMember(dest => dest.RequestComments, opt => opt.MapFrom(src => src.RequestComments));
        CreateMap<LeaveType, LeaveTypesReadOnly>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.Days));


        CreateMap<LeaveTypesCreateVM, LeaveType>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.Days));

        CreateMap<LeaveTypeEditVM, LeaveType>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.Days))

            ;
        //ReverseMap() => allows for both ways mapping


        CreateMap<LeaveType, LeaveTypeEditVM>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.Days));

        CreateMap<PeriodCreateVM, Period>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
           .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

        CreateMap<Period, PeriodEditVM>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

        CreateMap<PeriodEditVM, Period>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

        CreateMap<Period, PeriodReadOnly>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

        CreateMap<LeaveAllocation, LeaveAllocationVM>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.NumberOfDays))
             .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period))
             .ForMember(dest => dest.leaveType, opt => opt.MapFrom(src => src.LeaveType));
        CreateMap<LeaveAllocationVM, LeaveAllocation>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.NumberOfDays))
            .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period))
            .ForMember(dest => dest.LeaveType, opt => opt.MapFrom(src => src.leaveType));
        CreateMap<Period, PeriodVM>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

        CreateMap<LeaveAllocation, LeaveAllocationEditVM>()
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

        CreateMap<ApplicationUser, EmployeeListVM>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            ;
    }

}
