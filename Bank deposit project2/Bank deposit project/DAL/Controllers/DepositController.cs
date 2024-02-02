using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Deposit_project.DAL.Controllers

{
    [ApiController]
    [Route("/Deposit")]
    public class DepositController : ControllerBase
    {
        ApplicationContext db;
        public DepositController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deposit>>> Get()
        {
            return await db.Deposits.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deposit>> Get(int Number)
        {
            Deposit deposit = await db.Deposits.FirstOrDefaultAsync(x => x.DepositId == Number);
            if (deposit == null)
                return NotFound();
            return new ObjectResult(deposit);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Deposit>> Post(Deposit deposit)
        {
            if (deposit == null)
            {
                return BadRequest();
            }

            db.Deposits.Add(deposit);
            await db.SaveChangesAsync();
            return Ok(deposit);
        }

        // PUT api/users/
        [HttpPut("{Id}")]
        public async Task<ActionResult<Deposit>> Put(Deposit deposit)
        {
            if (deposit == null)
            {
                return BadRequest();
            }
            

            db.Update(deposit);
            await db.SaveChangesAsync();
            return Ok(deposit);
        }

        // DELETE api/users/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Deposit>> Delete(int Id)
        {
            Deposit deposit = db.Deposits.FirstOrDefault(x => x.DepositId == Id);
            if (deposit == null)
            {
                return NotFound();
            }
            db.Deposits.Remove(deposit);
            await db.SaveChangesAsync();
            return Ok(deposit);
        }
    }
}
