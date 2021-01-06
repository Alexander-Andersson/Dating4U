using Dating4U.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.DatabaseContext;
using Microsoft.EntityFrameworkCore;


namespace Dating4U.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserDbContext _context;

        public HomeController(ILogger<HomeController> logger, UserDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            UserView uv = new UserView();
            uv.Users = await _context.User.ToListAsync();
            uv.Friends = await _context.Friends.ToListAsync();
            uv.Messages = await _context.UserWall.ToListAsync();
            uv.FriendRequests = await _context.FriendRequests.ToListAsync();
            return View(uv);
        }

        public async Task<IActionResult> Explore()
        {
            return View(await _context.User.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
