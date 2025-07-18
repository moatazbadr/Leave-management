using AutoMapper;
using LeaveManagementSystem.Web.Models.Period;

namespace LeaveManagementSystem.Web.AutoMapperProfiles
{
    public class Profile2 :Profile
    {

public Profile2()
        {
            // TODO : Transform from PeriodCreateVM to Period
            CreateMap<PeriodCreateVM, Period>()
                .ForMember(dest => dest.Name ,opt =>opt.MapFrom(src=>src.Name))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

            CreateMap<Period,PeriodEditVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

            CreateMap<PeriodEditVM, Period>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

        }
    }
}
