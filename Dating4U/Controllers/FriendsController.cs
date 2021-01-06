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
    public class FriendsController : ControllerBase
    {
        private readonly UserDbContext _context;

        public FriendsController(UserDbContext context)
        {
            _context = context;
        }

        // GET: api/Friends
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Friends>>> GetFriends()
        {
            return await _context.Friends.ToListAsync();
        }

        // GET: api/Friends/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Friends>> GetFriends(int id)
        {
            var friends = await _context.Friends.FindAsync(id);

            if (friends == null)
            {
                return NotFound();
            }

            return friends;
        }

        // PUT: api/Friends/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriends(int id, Friends friends)
        {
            if (id != friends.Id)
            {
                return BadRequest();
            }

            _context.Entry(friends).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendsExists(id))
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

        //Tar emot ett Json-objekt som skickas från javascript functionen "confirmFriendRequest()" i vyn
        //Objektets har två int värden som lagras i variablar som sen skickas som parameter till CreateFriendsObject-metoden.
        [Route("AddFriends")]
        public async Task ConvertJson([FromBody] FriendsJson friendsJson)
        {
            int friend_1 = friendsJson.Friend_1;
            int friend_2 = friendsJson.Friend_2;
            await CreateFriendsObject(friend_1, friend_2);
        }

        //En metod som skapar Friends objektet som behövs som parameter till PostFriends-metoden.
        public async Task CreateFriendsObject(int friend_1, int friend_2)
        {
            using (_context)
            {
                //Loopar för att hitta vilken User som har id:et som är det samma som parametrarna
                //Resultatet lagras i variablar av typen User.
                User Friend_1 = new User();
                foreach (var item in _context.User)
                {
                    if (item.Id == friend_1)
                    {
                        Friend_1 = item;
                    }
                }

                User Friend_2 = new User();
                foreach (var item in _context.User)
                {
                    if (item.Id == friend_2)
                    {
                        Friend_2 = item;
                    }
                }
                
                //Skapar Friends objektet och tilldelar egenskaperna
                Friends friends = new Friends();
                friends.Friend_1 = Friend_1;
                friends.Friend_2 = Friend_2;

                //Skickar med Friends-objektet till PostFriend-metoden
                await PostFriends(friends);
            }
        }

        // POST: api/Friends
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Friends>> PostFriends(Friends friends)
        {
            _context.Friends.Add(friends);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFriends", new { id = friends.Id }, friends);
        }

        // DELETE: api/Friends/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFriends(int id)
        {
            var friends = await _context.Friends.FindAsync(id);
            if (friends == null)
            {
                return NotFound();
            }

            _context.Friends.Remove(friends);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FriendsExists(int id)
        {
            return _context.Friends.Any(e => e.Id == id);
        }
    }
}
