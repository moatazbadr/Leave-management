using AutoMapper;

namespace LeaveManagementSystem.Web.AutoMapperProfiles
{
    public class Profile4 :Profile
    {
        public Profile4()
        {
            CreateMap<ApplicationUser, EmployeeListVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                ;
            
        }

    }
}
