using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StajProject2.Data;
using StajProject2.Dtos;
using StajProject2.Entities;

namespace StajProject2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext _schoolContext;
        private readonly IMapper _mapper;
        public StudentController(SchoolContext context, IMapper mapper)
        {
            _schoolContext = context;
            _mapper = mapper;
        }
        //GET : api /<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _schoolContext.Students;
        }
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _schoolContext.Students.Where(k => k.Id == id ).FirstOrDefault();
        }

        //POST api/<StudentController>

        [HttpPost]
        public void Post([FromBody] StudentDto value)
        {

            Student student = _mapper.Map<Student>(value);
            //Student student = new();
            //student.Name = value.Name;
            //student.SurName = value.SurName;
            //student.Email = value.Email;

            _schoolContext.Students.Add(student);
            _schoolContext.SaveChanges();
        }
        //PUT
        [HttpPut("id")]
        public void Put(int id, [FromBody] Student value)
        {
            var _student = _schoolContext.Students.FirstOrDefault(x => x.Id == id);
            if (_student == null)
            {
                _student.Name = value.Name;
                _student.SurName = value.SurName;
                _student.Email = value.Email;
                _student.SchoolId = value.SchoolId;
                _student.PhoneNumber = value.PhoneNumber;
                _student.TC = value.TC;
                _student.Section = value.Section;
                _student.Status = value.Status;
                _schoolContext.Students.Update(_student);
                _schoolContext.SaveChanges();

            }
        }
        //DELETE 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var _student = _schoolContext.Students.FirstOrDefault(k => k.Id == id);
            _schoolContext.Students.Remove(_student);
            _schoolContext.SaveChanges();
        }

    }
}
