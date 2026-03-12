using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TVSeriesWebAPIw5Challenge.Models;

namespace TVSeriesWebAPIw5Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TVShowsController : ControllerBase
    {
        private readonly TVSeriesContext _context;

        public TVShowsController(TVSeriesContext context)
        {
            _context = context;
        }

        // GET: api/TVShows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TVShow>>> GetTVSeries()
        {
            return await _context.TVSeries.AsNoTracking().ToListAsync();
        }

        // GET: api/TVShows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TVShow>> GetTVShow(long id)
        {
            var tVShow = await _context.TVSeries.FindAsync(id);

            if (tVShow == null)
            {
                return NotFound();
            }

            return tVShow;
        }

        // PUT: api/TVShows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTVShow(long id, TVShow tVShow)
        {
            if (id != tVShow.Id)
            {
                return BadRequest();
            }

            _context.Entry(tVShow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TVShowExists(id))
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

        // POST: api/TVShows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TVShow>> PostTVShow(TVShow tVShow)
        {
            _context.TVSeries.Add(tVShow);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTVShow), new { id = tVShow.Id }, tVShow);
        }

        // DELETE: api/TVShows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTVShow(long id)
        {
            var tVShow = await _context.TVSeries.FindAsync(id);
            if (tVShow == null)
            {
                return NotFound();
            }

            _context.TVSeries.Remove(tVShow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TVShowExists(long id)
        {
            return _context.TVSeries.Any(e => e.Id == id);
        }
    }
}
