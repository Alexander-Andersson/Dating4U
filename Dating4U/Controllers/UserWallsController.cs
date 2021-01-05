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
    public class UserWallsController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UserWallsController(UserDbContext context)
        {
            _context = context;
        }

        // GET: api/UserWalls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserWall>>> GetUserWall()
        {
            return await _context.UserWall.ToListAsync();
        }

        // GET: api/UserWalls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserWall>> GetUserWall(int id)
        {
            
            var userWall = await _context.UserWall.FindAsync(id);

            if (userWall == null)
            {
                return NotFound();
            }

            return userWall;
        }

        // PUT: api/UserWalls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserWall(int id, UserWall userWall)
        {
            if (id != userWall.Id)
            {
                return BadRequest();
            }

            _context.Entry(userWall).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserWallExists(id))
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
        [Route("PostMessage")]
        public async Task ConvertJson([FromBody] MessageJson messageJson)
        {
            int sender = messageJson.Sender;
            int receiver = messageJson.Receiver;
            string message = messageJson.Message;
            await CreateUserWallObject(sender, receiver, message);
        }

        public async Task CreateUserWallObject(int Sender, int Receiver, string Message)
        {
            using (_context) {
                User sender = new User();
                foreach (var item in _context.User)
                {
                    if (item.Id == Sender)
                    {
                        sender = item;
                    }
                }

                User receiver = new User();
                foreach (var item in _context.User)
                {
                    if (item.Id == Receiver)
                    {
                        receiver = item;
                    }
                }

                UserWall userWall = new UserWall();
                userWall.Sender = sender;
                userWall.Receiver = receiver;
                userWall.Message = Message;
                //UserWall userWall1 = new UserWall();
                //userWall1 = userWall;

                await PostUserWall(userWall);
            }
        }

        // POST: api/UserWalls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserWall>> PostUserWall(UserWall userWall)
        {
            _context.UserWall.Add(userWall);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserWall", new { id = userWall.Id }, userWall);
        }

        // DELETE: api/UserWalls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserWall(int id)
        {
            var userWall = await _context.UserWall.FindAsync(id);
            if (userWall == null)
            {
                return NotFound();
            }

            _context.UserWall.Remove(userWall);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserWallExists(int id)
        {
            return _context.UserWall.Any(e => e.Id == id);
        }
    }
}
