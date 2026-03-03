using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FantasyFootballPlayersController : ControllerBase
    {
        private readonly FantasyFootballPlayerContext _context;

        public FantasyFootballPlayersController(FantasyFootballPlayerContext context)
        {
            _context = context;
        }

        // GET: api/FantasyFootballPlayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FantasyFootballPlayer>>> GetFantasyFootballPlayers()
        {
            return await _context.FantasyFootballPlayers.ToListAsync();
        }

        // GET: api/FantasyFootballPlayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FantasyFootballPlayer>> GetFantasyFootballPlayer(long id)
        {
            var fantasyFootballPlayer = await _context.FantasyFootballPlayers.FindAsync(id);

            if (fantasyFootballPlayer == null)
            {
                return NotFound();
            }

            return fantasyFootballPlayer;
        }

        // PUT: api/FantasyFootballPlayers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFantasyFootballPlayer(long id, FantasyFootballPlayer fantasyFootballPlayer)
        {
            if (id != fantasyFootballPlayer.Id)
            {
                return BadRequest();
            }

            _context.Entry(fantasyFootballPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FantasyFootballPlayerExists(id))
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

        // POST: api/FantasyFootballPlayers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FantasyFootballPlayer>> PostFantasyFootballPlayer(FantasyFootballPlayer fantasyFootballPlayer)
        {
            _context.FantasyFootballPlayers.Add(fantasyFootballPlayer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFantasyFootballPlayer), new { id = fantasyFootballPlayer.Id }, fantasyFootballPlayer);
        }

        // DELETE: api/FantasyFootballPlayers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFantasyFootballPlayer(long id)
        {
            var fantasyFootballPlayer = await _context.FantasyFootballPlayers.FindAsync(id);
            if (fantasyFootballPlayer == null)
            {
                return NotFound();
            }

            _context.FantasyFootballPlayers.Remove(fantasyFootballPlayer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FantasyFootballPlayerExists(long id)
        {
            return _context.FantasyFootballPlayers.Any(e => e.Id == id);
        }
    }
}
