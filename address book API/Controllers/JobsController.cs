using address_book_API.DTOs;
using address_book_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace address_book_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
       
        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJopssAsync()
        {
            var Jops = await _context.Jobs.ToListAsync();
            return Ok(Jops);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJobByIdAsync(int id)
        {
            var Job = await _context.Jobs.FindAsync(id);

            if (Job == null)
            {
                return NotFound($"No Job was found with ID {id}");
            }

            return Ok(Job);
        }
        [HttpPost]
        public async Task<ActionResult<Job>> CreateJopAsync([FromBody] CreateJopDTO job)
        {
            var myJob = new Job { Name = job.Name };
            await _context.AddAsync(myJob);
            _context.SaveChanges();
            return CreatedAtAction("CreateJob", new { id = myJob.Id }, myJob);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJopAsync(int id, CreateJopDTO job)
        {
            var JP = await _context.Jobs.FindAsync(id);
            if (JP == null)
            {
                return NotFound($"No Jop was found with ID {id}");
            }
            JP.Name = job.Name;
            await _context.SaveChangesAsync();
            return Ok(JP);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJopAsync(int id)
        {
            var JoP = await _context.Jobs.FindAsync(id);
            if (JoP == null)
            {
                return NotFound($"No Jop was found with ID {id}");
            }

            _context.Remove(JoP);
            await _context.SaveChangesAsync();

            return Ok(JoP);
        }
    }
}
