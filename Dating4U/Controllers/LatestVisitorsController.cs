using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer.DatabaseContext;
using DataLayer.Models;
using Dating4U.Models;

namespace Dating4U.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //ApiController för att sköta tillägandet och hämtandet av senaste besökarna
    //på en profil
    public class LatestVisitorsController : ControllerBase
    {
        private readonly UserDbContext _context;

        public LatestVisitorsController(UserDbContext context)
        {
            _context = context;
        }

        // GET: api/LatestVisitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LatestVisitors>>> GetLatestVisitors()
        {
            return await _context.LatestVisitors.ToListAsync();
        }

        // GET: api/LatestVisitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LatestVisitors>> GetLatestVisitors(int id)
        {
            var latestVisitors = await _context.LatestVisitors.FindAsync(id);

            if (latestVisitors == null)
            {
                return NotFound();
            }

            return latestVisitors;
        }

        // PUT: api/LatestVisitors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLatestVisitors(int id, LatestVisitors latestVisitors)
        {
            if (id != latestVisitors.Id)
            {
                return BadRequest();
            }

            _context.Entry(latestVisitors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LatestVisitorsExists(id))
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

        // POST: api/LatestVisitors
        //Tar emot ett Json-objekt som skickas från javascript functionen "addLatestVisitor()" i Details-vyn
        //Objektets har två int värden som lagras i variablar som sen skickas som parameter till CreateLatestVisitorObject-metoden.
        [Route("AddLatestVisitor")]
        public async Task ConvertJson([FromBody] LatestVisitorJson latestVisitorJson)
        {
            int profileVisited = latestVisitorJson.ProfileVisited;
            int visitedBy = latestVisitorJson.VisitedBy;
            await CreateLatestVisitorObject(profileVisited, visitedBy);
        }

        //En metod som skapar LatestVisitors-objektet som behövs som parameter till PostLatestVisitor-metoden.
        public async Task CreateLatestVisitorObject(int ProfileVisited, int VisitedBy)
        {
            using (_context)
            {
                //Skapar LatestVisitor-objektet och tilldelar egenskaperna
                User profileVisited = new User();
                foreach (var item in _context.User)
                {
                    if (item.Id == ProfileVisited)
                    {
                        profileVisited = item;
                    }
                }

                User visitedBy = new User();
                foreach (var item in _context.User)
                {
                    if (item.Id == VisitedBy)
                    {
                        visitedBy = item;
                    }
                }

                LatestVisitors latestVisitors = new LatestVisitors();
                latestVisitors.ProfileVisited = profileVisited;
                latestVisitors.VisitedBy = visitedBy;

                //Skickar med Friends-objektet till PostFriend-metoden
                await PostLatestVisitor(latestVisitors);
            }
        }

        //Lagra objektet i databasen
        [HttpPost]
        public async Task<ActionResult<LatestVisitors>> PostLatestVisitor(LatestVisitors latestVisitors)
        {
            _context.LatestVisitors.Add(latestVisitors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLatestVisitors", new { id = latestVisitors.Id }, latestVisitors);
        }

        // DELETE: api/LatestVisitors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLatestVisitors(int id)
        {
            var latestVisitors = await _context.LatestVisitors.FindAsync(id);
            if (latestVisitors == null)
            {
                return NotFound();
            }

            _context.LatestVisitors.Remove(latestVisitors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LatestVisitorsExists(int id)
        {
            return _context.LatestVisitors.Any(e => e.Id == id);
        }
    }
}
