using AutoMapper;
using WebApp_API.DomainModels;

namespace WebApp_API.Profiles.AfterMaps
{
   

  public class AddStudentRequestAfterMaps : IMappingAction<AddStudentRequest, WebAppAPI.DataModels.Student>
  {
            public void Process(AddStudentRequest source, WebAppAPI.DataModels.Student destination, ResolutionContext context)
            {
            destination.ID = Guid.NewGuid();
            //pour  eviter que la valeur ProfileImageUrl soit NULL
            destination.ProfileImageUrl = "-";
            destination.Address = new WebAppAPI.DataModels.Address()
            {

                    Id = Guid.NewGuid(),
                    PhysicalAddress = source.PhysicalAddress,
                    PostalAddress = source.PostalAddress
             
            };

            }
        }
    
}
