using AutoMapper;
using StajProject2.Dtos;
using StajProject2.Entities;

namespace StajProject2.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            _ = CreateMap<Student, StudentDto>().ReverseMap();
        }
        
    }
}
