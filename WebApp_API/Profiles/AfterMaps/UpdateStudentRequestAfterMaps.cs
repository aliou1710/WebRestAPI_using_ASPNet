using AutoMapper;
using System.Net.NetworkInformation;
using WebApp_API.DomainModels;

namespace WebApp_API.Profiles.AfterMaps
{
    public class UpdateStudentRequestAfterMaps : IMappingAction<UpdateStudentRequest, WebAppAPI.DataModels.Student>
    {
        public void Process(UpdateStudentRequest source, WebAppAPI.DataModels.Student destination, ResolutionContext context)
        {
            destination.Address = new WebAppAPI.DataModels.Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
         
        }
    }

}
