using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApp_API.DomainModels;
using WebApp_API.Repositories;

namespace WebApp_API.Controllers
{
    [ApiController]
    public class GendersController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        public GendersController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;

        }


        [HttpGet]
        [Route("[controller]")]

        public async Task<IActionResult> GetAllGenders()
        {
            var genderList =  await studentRepository.GetGendersAsync();
            if( genderList == null || !genderList.Any())
            {
                return NotFound();
            }
            else
            {
                return Ok(mapper.Map<List<Gender>>(genderList));
            }
          
        }
    }
}
