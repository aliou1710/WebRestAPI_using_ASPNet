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

        public async Task<List<Gender>> GetGendersAsync()
        {
            return await context.Gender.ToListAsync();
        }

        public async Task<bool> Exists(Guid studentId)
        {
          return await context.Students.AnyAsync(x => x.ID == studentId);
           
        }

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            var existingStudent = await GetOneStudentAsync(studentId);
            if(existingStudent != null)
            {
                existingStudent.FirstName = request.FirstName;
                existingStudent.LastName = request.LastName;
                existingStudent.DateOfBirth = request.DateOfBirth;
                existingStudent.Email = request.Email;
                existingStudent.Mobile = request.Mobile;
                existingStudent.GenderId = request.GenderId;
                existingStudent.Address.PhysicalAddress = request.Address.PhysicalAddress;
                existingStudent.Address.PostalAddress=request.Address.PostalAddress;

                await context.SaveChangesAsync();
                return existingStudent;
                
            }
            return null;
        }



        public async Task<Student> AddStudent(Student request)
        {
            var student = await context.Students.AddAsync(request);
            await context.SaveChangesAsync();
            return student.Entity;
        }

        public async Task<Student> DeleteStudent(Guid studentId)
        {
            throw new NotImplementedException();
        }


    }
}
