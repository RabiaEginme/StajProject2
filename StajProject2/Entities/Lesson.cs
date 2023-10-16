using System.Collections;

namespace StajProject2.Entities
{
    public class Lesson : IEntity
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public int LessonCode { get; set; }
        public string Theoric { get; set; }
        public string Practical { get; set; }
        public int Credit { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>(); //N-N ilişki

       
    }
}
