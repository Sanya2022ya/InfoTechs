using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Deposit_project.DAL.Controllers
{
    [ApiController]
    [Route("/Employee")]
    public class EmployeeController : ControllerBase
    {
        ApplicationContext db;
        public EmployeeController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return await db.Employees.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int Number)
        {
            Employee employee = await db.Employees.FirstOrDefaultAsync(x => x.EmployeeId == Number);
            if (employee == null)
                return NotFound();
            return new ObjectResult(employee);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            db.Employees.Add(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Employee>> Put(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            

            db.Update(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }

        // DELETE api/users/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Employee>> Delete(int Id)
        {
            Employee employee = db.Employees.FirstOrDefault(x => x.EmployeeId == Id);
            if (employee == null)
            {
                return NotFound();
            }
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return Ok(employee);
        }
    }
}