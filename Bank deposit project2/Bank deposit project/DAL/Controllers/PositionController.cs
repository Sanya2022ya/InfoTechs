using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Deposit_project.DAL.Controllers
{
    [ApiController]
    [Route("/Position")]
    public class PositionController : ControllerBase
    {
        ApplicationContext db;
        public PositionController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> Get()
        {
            return await db.Positions.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> Get(int Number)
        {
            Position position = await db.Positions.FirstOrDefaultAsync(x => x.PositionId == Number);
            if (position == null)
                return NotFound();
            return new ObjectResult(position);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Position>> Post(Position position)
        {
            if (position == null)
            {
                return BadRequest();
            }

            db.Positions.Add(position);
            await db.SaveChangesAsync();
            return Ok(position);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Position>> Put(Position position)
        {
            if (position == null)
            {
                return BadRequest();
            }
            

            db.Update(position);
            await db.SaveChangesAsync();
            return Ok(position);
        }

        // DELETE api/users/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Position>> Delete(int Id)
        {
            Position position = db.Positions.FirstOrDefault(x => x.PositionId == Id);
            if (position == null)
            {
                return NotFound();
            }
            db.Positions.Remove(position);
            await db.SaveChangesAsync();
            return Ok(position);
        }
    }
}

