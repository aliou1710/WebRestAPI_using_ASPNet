using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApp_API.DomainModels;
using WebApp_API.Repositories;
using WebAppAPI.DataModels;
using Student = WebApp_API.DomainModels.Student;

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
        public async Task<IActionResult> getAllStudents()
        {
            var students = await studentRepository.GetStudentsAsync();

            return Ok(mapper.Map<List<Student>>(students));
        }


        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> getStudentAsynch([FromRoute] Guid studentId)
        {
            //fetch student details
            var student = await studentRepository.GetOneStudentAsync(studentId);

            //return this student
            if(student == null)
            {
                return NotFound();
            }
            else{
                return Ok(mapper.Map<Student>(student));
            }
            
        }
    }
}
