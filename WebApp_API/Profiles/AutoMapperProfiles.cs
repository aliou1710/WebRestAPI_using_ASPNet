using AutoMapper;
using WebApp_API.DomainModels;
using DataModels=WebAppAPI.DataModels;

namespace WebApp_API.Profiles
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModels.Student, Student>().ReverseMap();
            CreateMap<DataModels.Address, Address>().ReverseMap();
            CreateMap<DataModels.Gender, Gender>().ReverseMap();
        }
    }
}
