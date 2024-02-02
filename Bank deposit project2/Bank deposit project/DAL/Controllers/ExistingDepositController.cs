using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Deposit_project.DAL.Controllers
{
    [ApiController]
    [Route("/ExistingDeposit")]
    public class ExistingDepositController : ControllerBase
    {
        ApplicationContext db;
        public ExistingDepositController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExistingDeposit>>> Get()
        {
            return await db.ExistingDeposits.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExistingDeposit>> Get(int Number)
        {
            ExistingDeposit existingdeposit = await db.ExistingDeposits.FirstOrDefaultAsync(x => x.AgreementId == Number);
            if (existingdeposit == null)
                return NotFound();
            return new ObjectResult(existingdeposit);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<ExistingDeposit>> Post(ExistingDeposit existingdeposit)
        {
            if (existingdeposit == null)
            {
                return BadRequest();
            }

            db.ExistingDeposits.Add(existingdeposit);
            await db.SaveChangesAsync();
            return Ok(existingdeposit);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<ExistingDeposit>> Put(ExistingDeposit existingdeposit)
        {
            if (existingdeposit == null)
            {
                return BadRequest();
            }
            

            db.Update(existingdeposit);
            await db.SaveChangesAsync();
            return Ok(existingdeposit);
        }

        // DELETE api/users/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<ExistingDeposit>> Delete(int Id)
        {
            ExistingDeposit existingdeposit = db.ExistingDeposits.FirstOrDefault(x => x.AgreementId == Id);
            if (existingdeposit == null)
            {
                return NotFound();
            }
            db.ExistingDeposits.Remove(existingdeposit);
            await db.SaveChangesAsync();
            return Ok(existingdeposit);
        }
    }
}