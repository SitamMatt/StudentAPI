using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Students.Dto;
using Students.Mappers;
using Students.Services;

namespace Students.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IStudentMapper _studentMapper; 

        public StudentController(IStudentService studentService, IStudentMapper studentMapper)
        {
            _studentService = studentService;
            _studentMapper = studentMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studentList = await _studentService.FindAll();
            var result = _studentMapper.ToDto(studentList);
            return Ok(result);
        }

        [HttpGet]
        [Route("/{pesel}")]
        public async Task<IActionResult> GetOne(long pesel)
        {
            var student = await _studentService.FindAsync(pesel);
            if (student is null)
            {
                return NotFound();
            }

            var result = _studentMapper.ToDto(student);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDto model)
        {
            var student = _studentMapper.ToDomain(model);
            var result = await _studentService.AddAsync(student);
            return Ok();
        }
    }
}