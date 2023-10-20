using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using StajProject2.DAL;
using StajProject2.Data;
using StajProject2.Dtos;
using StajProject2.Entities;

namespace StajProject2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;
        public LessonController(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;

        }
        [HttpGet]
        public IEnumerable<Lesson> Get()
        {
            return _lessonRepository.GetLessons();
        }


        [HttpGet("{id}")]
        public IActionResult GetLesson(int id)
        {
            var lesson = _lessonRepository.GetLessonByID(id);

            if (lesson == null)
            {
                return NotFound(); 
            }

            return Ok(lesson); 
        }



        //POST api/<LessonController>
        [HttpPost]
        public void Post([FromBody] LessonDto value)
        {
            Lesson lesson = _mapper.Map<Lesson>(value);

            _lessonRepository.InsertLesson(lesson);
            _lessonRepository.Save();
        }
        //PUT 
        [HttpPut("id")]
        public void Put(int id, [FromBody] Lesson value)
        {
            var lesson = _lessonRepository.GetLessonByID(id);
            if (lesson== null)
            {
                lesson.LessonName = value.LessonName;
                lesson.LessonCode = value.LessonCode;
                lesson.Theoric = value.Theoric;
                lesson.Practical = value.Practical;
                lesson.Credit = value.Credit;

               _lessonRepository.UpdateLesson(lesson);
               _lessonRepository.Save();

            }
            
        }
        //DELETE
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var lesson = (_lessonRepository.GetLessonByID(id));
            _lessonRepository.DeleteLesson(id);
            _lessonRepository.Save();
            //var lesson = _schoolContext.Lessons.FirstOrDefault(k => k.Id == id);
            //_schoolContext.Lessons.Remove(lesson);
            //_schoolContext.SaveChanges();
        }
    }
}
