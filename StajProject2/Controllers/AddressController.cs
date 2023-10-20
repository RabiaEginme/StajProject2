using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StajProject2.Data;
using StajProject2.Entities;

namespace StajProject2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly SchoolContext _schoolContext;
        public AddressController(SchoolContext context)
        {
            _schoolContext = context;
        }
        [HttpGet]
        public IEnumerable<Address> Get()
        {
            return _schoolContext.Addresses;
        }
        [HttpGet("{id}")]
        public Address Get(int id)
        {
            return _schoolContext.Addresses.Where(k => k.Id == id).FirstOrDefault();
        }
        //POST api/<Adress Controller>

        [HttpPost]
        public void Post([FromBody] Address value)
        {
            Address address = value;
            _schoolContext.Addresses.Add(address);
            _schoolContext.SaveChanges();
        }
        //PUT
        [HttpPut("id")]
        public void Put(int id, [FromBody] Address value)
        {
            var address = _schoolContext.Addresses.FirstOrDefault(x => x.Id == id);
            if (address == null)
            {
                address.Street = value.Street;
                address.District= value.District;
                address.CityId= value.CityId;
                address.CountryId= value.CountryId;
                address.StudentId= value.StudentId;

                _schoolContext.Addresses.Update(address);
                _schoolContext.SaveChanges();

            }

        }
        //DELETE 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var address = _schoolContext.Addresses.FirstOrDefault(k => k.Id == id);
            _schoolContext.Addresses.Remove(address);
            _schoolContext.SaveChanges();
        }
    }
}
