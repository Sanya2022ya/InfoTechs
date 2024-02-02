using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Deposit_project.DAL.Controllers
{
    [ApiController]
    [Route("/Factoftreatment")]
    public class FactoftreatmentController : ControllerBase

    {
        ApplicationContext db;
        public FactoftreatmentController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factoftreatment>>> Get()
        {
            return await db.Factoftreatments.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factoftreatment>> Get(int Number)
        {
            Factoftreatment factoftreatment = await db.Factoftreatments.FirstOrDefaultAsync(x => x.TreatmentId == Number);
            if (factoftreatment == null)
                return NotFound();
            return new ObjectResult(factoftreatment);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Factoftreatment>> Post(Factoftreatment factoftreatment)
        {
            if (factoftreatment == null)
            {
                return BadRequest();
            }

            db.Factoftreatments.Add(factoftreatment);
            await db.SaveChangesAsync();
            return Ok(factoftreatment);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Factoftreatment>> Put(Factoftreatment factoftreatment)
        {
            if (factoftreatment == null)
            {
                return BadRequest();
            }
           

            db.Update(factoftreatment);
            await db.SaveChangesAsync();
            return Ok(factoftreatment);
        }

        // DELETE api/users/5
        [HttpDelete("{number}")]
        public async Task<ActionResult<Factoftreatment>> Delete(int Id)
        {
            Factoftreatment factoftreatment = db.Factoftreatments.FirstOrDefault(x => x.TreatmentId == Id);
            if (factoftreatment == null)
            {
                return NotFound();
            }
            db.Factoftreatments.Remove(factoftreatment);
            await db.SaveChangesAsync();
            return Ok(factoftreatment);
        }
    }
}