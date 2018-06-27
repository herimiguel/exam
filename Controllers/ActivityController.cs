using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using exam.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace exam.Controllers{
    public class ActivityController : Controller{
        private Context _context;
        public ActivityController(Context context){
            _context = context;
        }
                [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard(){
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            if(loggedInId == null){
                return RedirectToAction("LogReg", "User");
            }
            User currUser = new User(); 
            currUser = _context.Users.Include(u => u.ActivitiesAttending).SingleOrDefault(user => user.UserId == loggedInId);
            ViewBag.currUser = currUser;
            List<int> ActivityIds = new List<int>();
            foreach(var activity in currUser.ActivitiesAttending){
            ActivityIds.Add(activity.ActivityId);
            }
            ViewBag.Attending = ActivityIds;
            ViewBag.AllActivities = _context.Activities.Include( w => w.Guests).ThenInclude(g => g.Guest).ToList();
            return View();
        }

        [HttpGet]
        [Route("Activity")]
        public IActionResult ActivityForm(){
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            if(loggedInId == null){
                return RedirectToAction("LogReg", "User");
            }
            return View();
        }

        [HttpPost]
        [Route("PostActivity")]
        public IActionResult addActivity(ActivityViewModel model){
            if(ModelState.IsValid){
                if(model.Date < DateTime.Today){
                    ModelState.AddModelError("date", "Date Cannot be set to future date!");
                    return View("Activity", model);
                }
                Activity NewActivity = new Activity{
                    Title = model.Title,
                    Date = model.Date,
                    Coordinator = model.Coordinator,
                    Description = model.Description,
                    Time = model.Time,
                    Duration = model.Duration,
                    UserId = (int) HttpContext.Session.GetInt32("CurrUser"),
                };
                _context.Add(NewActivity);
                _context.SaveChanges();
                return RedirectToAction("Activity", new {Id = NewActivity.ActivityId});
            }
            return View("ActivityForm");
        }
        
        [HttpGet]
        [Route("Activity/{Id}")]
        public IActionResult Activity(int Id){
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            if(loggedInId == null){
                return RedirectToAction("LogReg", "User");
            }
            Activity Activity = new Activity();
            Activity = _context.Activities.Include(w => w.Guests).ThenInclude(g => g.Guest).SingleOrDefault(w => w.ActivityId == Id);
            
            return View(Activity);
        }
        [HttpGet]
        [Route("delActivity/{Id}")]
        public IActionResult delActivity(int Id){
            Activity Act = _context.Activities.Where(w => w.ActivityId == Id).FirstOrDefault();
            if(Act != null)
            {
                _context.Remove(Act);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
                return RedirectToAction("Dashboard");
            
        }




        [HttpGet]
        [Route("RSVP/{Id}")]
        public IActionResult RSVP(int Id){
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            GuestConnection NewConnection = new GuestConnection{
                GuestId = (int)loggedInId,
                ActivityId =Id
            };
            _context.GuestConnections.Add(NewConnection);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        [Route("UnRSVP/{Id}")]
        public IActionResult UnRSVP(int Id){
            int? loggedInId = HttpContext.Session.GetInt32("CurrUser");
            GuestConnection retrievedConnection = _context.GuestConnections.SingleOrDefault( gc => gc.GuestId == loggedInId && gc.ActivityId == Id);
            _context.GuestConnections.Remove(retrievedConnection);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }   
}