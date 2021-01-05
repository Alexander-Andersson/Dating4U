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
    public class FriendRequestsController : ControllerBase
    {
        private readonly UserDbContext _context;

        public FriendRequestsController(UserDbContext context)
        {
            _context = context;
        }

        // GET: api/FriendRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendRequest>>> GetFriendRequests()
        {
            return await _context.FriendRequests.ToListAsync();
        }

        // GET: api/FriendRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FriendRequest>> GetFriendRequest(int id)
        {
            var friendRequest = await _context.FriendRequests.FindAsync(id);

            if (friendRequest == null)
            {
                return NotFound();
            }

            return friendRequest;
        }

        // PUT: api/FriendRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriendRequest(int id, FriendRequest friendRequest)
        {
            if (id != friendRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(friendRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendRequestExists(id))
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

        // POST: api/FriendRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("SendFriendRequest")]
        public async Task ConvertJson([FromBody] FriendRequestJson friendRequestJson)
        {
            int sender = friendRequestJson.Sender;
            int receiver = friendRequestJson.Receiver;
            Console.WriteLine(sender);
            Console.WriteLine(receiver);
            await CreateFriendRequestObject(sender, receiver);
        }

        public async Task CreateFriendRequestObject(int Sender, int Receiver)
        {
            using (_context)
            {
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

                FriendRequest friendRequest = new FriendRequest();
                friendRequest.Sender = sender;
                friendRequest.Receiver = receiver;

                Console.WriteLine(friendRequest);
                await PostFriendRequest(friendRequest);
            }
        }

        [HttpPost]
        public async Task<ActionResult<FriendRequest>> PostFriendRequest(FriendRequest friendRequest)
        {
            _context.FriendRequests.Add(friendRequest);
            await _context.SaveChangesAsync();

            Console.WriteLine(friendRequest);
            return CreatedAtAction("GetFriendRequests", new { id = friendRequest.Id }, friendRequest);
        }

        // DELETE: api/FriendRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFriendRequest(int id)
        {
            var friendRequest = await _context.FriendRequests.FindAsync(id);
            if (friendRequest == null)
            {
                return NotFound();
            }

            _context.FriendRequests.Remove(friendRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FriendRequestExists(int id)
        {
            return _context.FriendRequests.Any(e => e.Id == id);
        }
    }
}
