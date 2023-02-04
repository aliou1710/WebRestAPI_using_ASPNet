using WebAppAPI.DataModels;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApp_API.Repositories
{
    public class SQLStudentRepository : IStudentRepository
    {
        //implement interface
        private readonly StudentAdminContext context;
        public SQLStudentRepository(StudentAdminContext context)
        {
            this.context = context;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
           
                //return context.Students.ToList();

                //Include(nameof(Gender)): this is ad the details of gender who is associated to the students
                return await context.Students.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
  

        }

        public async Task<Student> GetOneStudentAsync(Guid studentId)
        {

            
            return await context.Students.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(x=>x.ID ==studentId);


        }

        /*public List<Address> GetAddresses()
         {
             return context.Address.ToList();
         }*/
    }
}
