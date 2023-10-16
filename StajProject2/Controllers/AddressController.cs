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
        //POST api/<StudentController>

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
            var _address = _schoolContext.Addresses.FirstOrDefault(x => x.Id == id);
            if (_address == null)
            {
                _address.Street = value.Street;
                _address.District= value.District;
                _address.CityId= value.CityId;
                _address.CountryId= value.CountryId;
                _address.StudentId= value.StudentId;

                _schoolContext.Addresses.Update(_address);
                _schoolContext.SaveChanges();

            }

        }
        //DELETE 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var _address = _schoolContext.Addresses.FirstOrDefault(k => k.Id == id);
            _schoolContext.Addresses.Remove(_address);
            _schoolContext.SaveChanges();
        }
    }
}
