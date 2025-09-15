using AutoMapper;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Application.Models.LeaveTypes;

namespace LeaveManagementSystem.Application.AutoMapperProfiles;

public class Profile1 :Profile
{
    public Profile1()
    {
        //  LeaveType :source , IndexViewModel : destination
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


    }
}
