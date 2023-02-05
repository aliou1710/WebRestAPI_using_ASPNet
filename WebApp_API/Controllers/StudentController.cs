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
        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
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
        [Route("[controller]/{studentId:guid}"),ActionName("getStudentAsynch")]
        public async Task<IActionResult> getStudentAsynch([FromRoute] Guid studentId)
        {
            //fetch student details
            var student = await studentRepository.GetOneStudentAsync(studentId);

            //return this student
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mapper.Map<Student>(student));
            }

        }


        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
            //fetch student details
            //si l'element à l'id exist (c'ad == à true)
            if (await studentRepository.Exists(studentId))
            {
                //update Details
                var updateStudent = await studentRepository.UpdateStudent(studentId, mapper.Map<WebAppAPI.DataModels.Student>(request));
                if (updateStudent != null)
                {
                    return Ok(mapper.Map<DomainModels.Student>(updateStudent));
                }
            }

            return NotFound();


        }


        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentRequest request)
        {
           var student =await studentRepository.AddStudent(mapper.Map<WebAppAPI.DataModels.Student>(request));
            return CreatedAtAction(nameof(getStudentAsynch),new { studentId = student.ID},mapper.Map<Student>(student));
        }
    }
}
