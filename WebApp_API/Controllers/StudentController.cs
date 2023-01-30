using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApp_API.DomainModels;
using WebApp_API.Repositories;

namespace WebApp_API.Controllers
{
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        public StudentController(IStudentRepository studentRepository,IMapper mapper)
        {this.studentRepository = studentRepository;
            this.mapper = mapper;

        }



        [HttpGet]
        [Route("[controller]")]
        public IActionResult getAllStudents()
        {
            var students = studentRepository.GetStudents();

            /* var domainModelStudents = new List<Student>();

             foreach(var student in students)
             {
                 domainModelStudents.Add(new Student 
                 {
                     ID = student.ID,
                     FirstName = student.FirstName,
                     LastName = student.LastName,
                     DateOfBirth = student.DateOfBirth,
                     Email = student.Email,
                     Mobile  = student.Mobile,
                     ProfileImageUrl =   student.ProfileImageUrl,
                     GenderId = student.GenderId,
                     address = new Address()
                     {
                         Id = student.address.Id,
                         PhysicalAddress= student.address.PhysicalAddress,  
                         PostalAddress= student.address.PostalAddress
                     },
                     Gender = new Gender()
                     {
                         Id = student.Gender.Id,
                         Description = student.Gender.Description
                     }

                 });
             } return Ok(domainModelStudents);*/
            return Ok(mapper.Map<List<Student>>(students));
        }


       /* [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAddresses()
        {
            var addresses = studentRepository.GetAddresses();

            return Ok(mapper.Map<List<Address>>(addresses));
        }*/
    }
}
