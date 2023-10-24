using AutoMapper;
using StajProject2.Dtos;

namespace StajProject2.Entities
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<LessonDto, Lesson>(); // LessonDto'dan Lesson'a haritalama yapılandırması
        }
    }
}
