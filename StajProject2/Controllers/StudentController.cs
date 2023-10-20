using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using StajProject2.DAL;
using StajProject2.Data;
using StajProject2.Dtos;
using StajProject2.Entities;
using System.Runtime.CompilerServices;

namespace StajProject2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //private readonly SchoolContext _schoolContext;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        //GET : api /<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentRepository.GetStudents();

        }

        //repository

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentRepository.GetStudentByID(id);

            if (student == null)
            {
                return NotFound(); // Eğer öğrenci bulunamazsa 404 Not Found döner
            }

            return Ok(student); // Öğrenci bulunursa 200 OK ile öğrenci verisini döner
        }



        //[HttpGet("{id}")]
        //public Student Get(int id)
        //{
        //    return _schoolContext.Students.Where(k => k.Id == id ).FirstOrDefault();
        //}


        //POST api/<StudentController>

        [HttpPost]
        public void Post([FromBody] StudentDto value)
        {

            Student student = _mapper.Map<Student>(value);
            //Student student = new();
            //student.Name = value.Name;
            //student.SurName = value.SurName;
            //student.Email = value.Email;

            _studentRepository.InsertStudent(student);
            _studentRepository.Save();
        }

        //repository

        [HttpPost("create-student-old")]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest(); // Hatalı istek durumunda 400 Bad Request döner
            }

            _studentRepository.InsertStudent(student);

            // Eğer başarılı bir şekilde öğrenci eklendi ise 201 Created yanıtı döner
            // ve yeni oluşturulan öğrencinin URI'sini içerir
            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        //PUT
        [HttpPut("id")]
        public void Put(int id, [FromBody] Student value)
        {
            var student = _studentRepository.GetStudentByID(id);
            if (student == null)
            {
                student.Name = value.Name;
                student.SurName = value.SurName;
                student.Email = value.Email;
                student.SchoolId = value.SchoolId;
                student.PhoneNumber = value.PhoneNumber;
                student.TC = value.TC;
                student.Section = value.Section;
                student.Status = value.Status;
                _studentRepository.UpdateStudent(student);
                _studentRepository.Save();

            }
        }
        ////DELETE 
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    var student = _studentRepository.DeleteStudent(id);
        //    _studentRepository.DeleteStudent(student);
        //    _studentRepository.Save();

        //}

    }
}
