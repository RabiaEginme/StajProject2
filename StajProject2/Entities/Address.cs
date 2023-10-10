using Azure;

namespace StajProject2.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } //bir öğrenci birden fazla bu tabloda bulunabilir.
       
    }
}
