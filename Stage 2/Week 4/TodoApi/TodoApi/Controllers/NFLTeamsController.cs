using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NFLTeamsController : ControllerBase
    {
        private readonly NFLTeamContext _context;

        public NFLTeamsController(NFLTeamContext context)
        {
            _context = context;
        }

        // GET: api/NFLTeams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NFLTeam>>> GetNFLTeams()
        {
            return await _context.NFLTeams.AsNoTracking().ToListAsync();
        }

        // GET: api/NFLTeams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NFLTeam>> GetNFLTeam(long id)
        {
            var nFLTeam = await _context.NFLTeams.FindAsync(id);

            if (nFLTeam == null)
            {
                return NotFound();
            }

            return nFLTeam;
        }

        // PUT: api/NFLTeams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNFLTeam(long id, NFLTeam nFLTeam)
        {
            if (id != nFLTeam.Id)
            {
                return BadRequest();
            }

            _context.Entry(nFLTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NFLTeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NFLTeams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NFLTeam>> PostNFLTeam(NFLTeam nFLTeam)
        {
            _context.NFLTeams.Add(nFLTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNFLTeam), new { id = nFLTeam.Id }, nFLTeam);
        }

        // DELETE: api/NFLTeams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNFLTeam(long id)
        {
            var nFLTeam = await _context.NFLTeams.FindAsync(id);
            if (nFLTeam == null)
            {
                return NotFound();
            }

            _context.NFLTeams.Remove(nFLTeam);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NFLTeamExists(long id)
        {
            return _context.NFLTeams.Any(e => e.Id == id);
        }
    }
}
