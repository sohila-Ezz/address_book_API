using address_book_API.DTOs;
using address_book_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace address_book_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartmentsAsync()
        {
            var Departments = await _context.Departments.ToListAsync();
            return Ok(Departments);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentByIdAsync(int id)
        {
            var Department = await _context.Departments.FindAsync(id);

            if (Department == null)
            {
                return NotFound($"No Department was found with ID {id}");
            }

            return Ok(Department);
        }
        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartmentAsync([FromBody] CreateJopDTO Department)
        {
            var myDepartment = new Department { Name = Department.Name };
            await _context.AddAsync(myDepartment);
            _context.SaveChanges();
            return CreatedAtAction("CreateDepartment", new { id = myDepartment.Id }, myDepartment);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartmentAsync(int id, CreateDepartmentDTO Department)
        {
            var Dept = await _context.Departments.FindAsync(id);
            if (Dept == null)
            {
                return NotFound($"No Department was found with ID {id}");
            }
            Dept.Name = Department.Name;
            await _context.SaveChangesAsync();
            return Ok(Dept);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentAsync(int id)
        {
            var Dept = await _context.Departments.FindAsync(id);
            if (Dept == null)
            {
                return NotFound($"No Department was found with ID {id}");
            }

            _context.Remove(Dept);
            await _context.SaveChangesAsync();

            return Ok(Dept);
        }
    }
}
