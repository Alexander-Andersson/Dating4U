using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer.DatabaseContext;
using DataLayer.Models;
using Dating4U.Models;
using Microsoft.AspNetCore.Identity;

namespace Dating4U.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserDbContext _context;

        public UsersController(UserDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            UserView uv = new UserView();
            uv.Users = await _context.User.ToListAsync();
            uv.Friends = await _context.Friends.ToListAsync();
            uv.Messages = await _context.UserWall.ToListAsync();
            uv.FriendRequests = await _context.FriendRequests.ToListAsync();
            return View(uv);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            User loggedInUser = new User();
            foreach(var item in _context.User)
{
                if (User.Identity.Name.Equals(item.UserName))
                {
                    loggedInUser = item;
                }
            }
            if (id == null)
            {
                return NotFound();
            }

            

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            

            UserDetails userDetails = new UserDetails();
            userDetails.Id = user.Id;
                if(loggedInUser.Id == userDetails.Id)
                {
                    return RedirectToAction(nameof(Index));
                }
            userDetails.UserName = user.UserName;
            userDetails.FirstName = user.FirstName;
            userDetails.LastName = user.LastName;
            userDetails.Age = user.Age;
            userDetails.Gender = user.Gender;
            userDetails.Description = user.Description;
            userDetails.ProfilePicture = user.ProfilePicture;
            userDetails.Messages = await _context.UserWall.ToListAsync();
            userDetails.Users = await _context.User.ToListAsync();
            userDetails.FriendRequests = await _context.FriendRequests.ToListAsync();
            userDetails.Friends = await _context.Friends.ToListAsync();
            return View(userDetails);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,FirstName,LastName,Age,Gender,Description,ProfilePicture,IsNotSearchable")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,FirstName,LastName,Age,Gender,Description,ProfilePicture,IsNotSearchable")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
