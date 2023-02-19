using address_book_API.DTOs;
using address_book_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
namespace address_book_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonsAsync()
        {
            var Persons = await _context.Persons.ToListAsync();
            return Ok(Persons);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonByIdAsync(int id)
        {
            var Person = await _context.Persons.FindAsync(id);

            if (Person == null)
            {
                return NotFound($"No Person was found with ID {id}");
            }

            return Ok(Person);
        }
        [HttpGet("{Name}")]
        public async Task<ActionResult<Person>> GetPersonByNameAsync(string name)
        {
            var Person = await _context.Persons.FirstOrDefaultAsync(x => x.Name == name);

            if (Person == null)
            {
                return NotFound($"No Person was found with ID {name}");
            }

            return Ok(Person);
        }
        [HttpPost]
        public async Task<ActionResult<Person>> CreatePersonAsync([FromBody] CreatePersonDTO person)
        {
            var Person = new Person {
                Name = person.Name,
               
                mobileNumber=person.mobileNumber,
                dateOfBirth = person.dateOfBirth,
                Address = person.Address,
                Email = person.Email,
                Password = person.Password,
                Photo= person.Photo,
                Age= person.Age,
                Department_Id = person.Department_Id,
                Job_Id= person.Job_Id


            };
            
            await _context.AddAsync(Person);
            _context.SaveChanges();
            return CreatedAtAction("AddPerson", new { id = Person.Id }, Person);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonAsync(int id, [FromBody] CreatePersonDTO person)
        {
            var Person = await _context.Persons.FindAsync(id);
            if (Person == null)
            {
                return NotFound($"No Person was found with ID {id}");
            }

            Person.Name = person.Name;
           
            Person.mobileNumber = person.mobileNumber;
            Person.dateOfBirth = person.dateOfBirth;
            Person.Address = person.Address;
            Person.Email = person.Email;
            Person.Password = person.Password;
            Person.Photo = person.Photo;
            Person.Age = person.Age;
            Person.Department_Id = person.Department_Id;
            Person.Job_Id = person.Job_Id;
            await _context.SaveChangesAsync();
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonAsync(int id)
        {
            var Person = await _context.Persons.FindAsync(id);
            if (Person == null)
            {
                return NotFound($"No Person was found with ID {id}");
            }

            _context.Remove(Person);
            await _context.SaveChangesAsync();

            return Ok(Person);
        }
    }
}
