using StajProject2.Entities;
using System.Text.Json.Serialization;

namespace StajProject2.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        //[JsonIgnore]
        //public Address Address { get; set; }

    }
}
