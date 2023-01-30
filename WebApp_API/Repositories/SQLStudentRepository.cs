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

        public List<Student> GetStudents()
        {
           
                //return context.Students.ToList();

                //Include(nameof(Gender)): this is ad the details of gender who is associated to the students
                return context.Students.Include(nameof(Gender)).Include(nameof(Address)).ToList();
  

        } 

       /*public List<Address> GetAddresses()
        {
            return context.Address.ToList();
        }*/
    }
}
