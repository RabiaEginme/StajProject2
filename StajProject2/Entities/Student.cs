namespace StajProject2.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public string Email { get; set; }

        public int SchoolId { get; set; }

        public string PhoneNumber { get; set; }

        public string TC { get; set; }

        public string Section { get; set; }

        public string Status { get; set; }
        public ICollection<Address> Addresses { get; set; }  = new List<Address>();
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>(); 
    }
}
