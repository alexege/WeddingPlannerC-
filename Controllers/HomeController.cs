using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
		// here we can "inject" our context service into the constructor
		public HomeController(MyContext context)
		{
			dbContext = context;
		}

        [HttpPost("Register")]
        public IActionResult Register(Guest newGuest)
        {
            if(ModelState.IsValid)
            {
                bool notUnique = dbContext.Guests.Any(a => a.Email == newGuest.Email);

                if(notUnique)
                {
                    ModelState.AddModelError("Email", "Email already in use. Please use a new one");
                    return View("Index");
                }

                PasswordHasher<Guest> hasher = new PasswordHasher<Guest>();
                string hash = hasher.HashPassword(newGuest, newGuest.Password);
                newGuest.Password = hash;

                dbContext.Guests.Add(newGuest);
                dbContext.SaveChanges();

                var last_added_Guest = dbContext.Guests.Last().GuestId;
                HttpContext.Session.SetInt32("GuestId", last_added_Guest);
            
                return RedirectToAction("Dashboard");
            }
        return View("Index");
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            // checked to see if user is in session or not. If not, redirec to index.
            if(HttpContext.Session.GetInt32("GuestId") == null){
                return View("Index");
            }


            int? GuestId = HttpContext.Session.GetInt32("GuestId");
            if(GuestId == null)
            {
                return View("Index");
            }

            var current_user = dbContext.Guests.First(usr => usr.GuestId == GuestId);
            ViewBag.FirstName = current_user.FirstName;

            ViewBag.Logged_in_user_id = HttpContext.Session.GetInt32("GuestId");

            var weddings = dbContext.Weddings
                        .Include(w => w.Creator)
                        .Include(w => w.RSVPs)
                            .ThenInclude(r => r.Guest)
                        .ToList();
            return View("Dashboard", weddings);
        }

        [HttpGet("show/{WeddingId}")]
        public IActionResult Show(int WeddingId)
        {
            var weddings = dbContext.Weddings
            .Include(w => w.Creator)
            .Include(w => w.RSVPs)
                .ThenInclude(r => r.Guest)
            .FirstOrDefault(wed => wed.WeddingId == WeddingId);
            return View("ShowWedding", weddings);
        }

        [HttpPost("Login")]
        public IActionResult Login(LogUser logUser)
        {
            var found_user = dbContext.Guests.FirstOrDefault(user => user.Email == logUser.LogEmail);

            if(found_user == null)
            {
                ModelState.AddModelError("LogEmail", "Incorrect Email or Password");
                return View("Index");
            }

            PasswordHasher<LogUser> Hasher = new PasswordHasher<LogUser>();
            var user_verified = Hasher.VerifyHashedPassword(logUser, found_user.Password, logUser.LogPassword);

            if(user_verified == 0)
            {
                ModelState.AddModelError("LogEmail", "Email already in use. Please use a new one");
                return View("Index");
            }

            var current_user = dbContext.Guests.Last().GuestId;

            HttpContext.Session.SetInt32("GuestId", dbContext.Guests.Last().GuestId);
            
            return RedirectToAction("Dashboard");
        }

        [HttpGet("wedding/remove/{WeddingId}")]
        public IActionResult removeWedding(int WeddingId)
        {
            var wedding = dbContext.Weddings.Include(w => w.RSVPs).First(w => w.WeddingId == WeddingId);
            var weddingRSVPs = wedding.RSVPs.ToList();
            foreach(var rsvp in weddingRSVPs)
            {
                dbContext.RSVPs.Remove(rsvp);   
            }
            dbContext.Weddings.Remove(wedding);
            dbContext.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        [HttpGet("rsvp/add/{WeddingId}")]
        public IActionResult RSVP(int WeddingId)
        {
           RSVP rsvp = new RSVP(WeddingId, (int)HttpContext.Session.GetInt32("GuestId"));
           var guest = dbContext.Weddings.FirstOrDefault(wed => wed.WeddingId == rsvp.WeddingId);
           dbContext.RSVPs.Add(rsvp);
           dbContext.SaveChanges();
           guest.RSVPs.Add(dbContext.RSVPs.Last());
           dbContext.SaveChanges();
           return RedirectToAction("Dashboard");
        }
        
        [HttpGet("rsvp/remove/{WeddingId}")]
        public IActionResult removeRSVP(int WeddingId)
        {
           var wedRSVP = dbContext.RSVPs.Where(r => r.WeddingId == WeddingId).ToList();
           var remove = wedRSVP.FirstOrDefault(r => r.GuestId == HttpContext.Session.GetInt32("GuestId"));
           dbContext.RSVPs.Remove(remove);
           dbContext.SaveChanges();
           return RedirectToAction("Dashboard");
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            //Destroy Session
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        //Render New Wedding Page
        [HttpGet("wedding/new")]
        public IActionResult NewWedding()
        {
            return View();
        }

        //Create a new wedding, taking in a new instance of a wedding.
        [HttpPost("wedding/new")]
        public IActionResult AddWedding(Wedding newWedding)
        {
            if(ModelState.IsValid)
            {
                newWedding.Creator = dbContext.Guests.First(guest => guest.GuestId == HttpContext.Session.GetInt32("GuestId"));
                dbContext.Weddings.Add(newWedding);
                dbContext.SaveChanges();
                ViewBag.GuestId = HttpContext.Session.GetInt32("GuestId");

                return RedirectToAction("Dashboard");
            }
            return View("NewWedding");
        }

        public IActionResult Index()
        {
            return View();
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
