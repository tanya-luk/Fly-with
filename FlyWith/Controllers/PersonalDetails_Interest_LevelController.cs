using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FlyWith.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace FlyWith.Controllers
{
    [Authorize(Roles = "User")]
    public class PersonalDetails_Interest_LevelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonalDetails_Interest_Level
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            var person = db.PersonalDetails.FirstOrDefault(e => (e.AspNetUserId.Equals(currentUserId)));
            if (currentUserId == null)
                return Redirect("/Account/Login");
            if (person == null)
                return RedirectToAction("Create", "PersonalDetails");
            var interests = db.Interests.Select(i=>i.InterestID).ToList();
            var levelId = db.Levels.Where(l=>l.Name.Equals("0")).Select(l => l.LevelID);
            if (interests.ToList().Count > 0)
            {
                
                foreach (var inter in interests.ToList())
                {
                    var exist = db.PersonalDetails_Interest_Level.Where(p => p.InterestID.Equals(inter) && p.PersonalDetailsID.Equals(person.PersonalDetailsID)).ToList();
                    if (exist.Count == 0)
                    {
                        PersonalDetails_Interest_Level record = new PersonalDetails_Interest_Level
                        {
                            PersonalDetailsID = person.PersonalDetailsID,
                            InterestID = inter,
                            LevelID = levelId.First()
                        };
                        db.PersonalDetails_Interest_Level.Add(record);
                        db.SaveChanges();
                    }
                }
                
            }
            ViewBag.Categories = db.InterestGroups.ToList();
            var personalDetails_Interest_Level = db.PersonalDetails_Interest_Level.Include(p => p.Interest).Include(p => p.Level).Include(p => p.PersonalDetails);
            return View(personalDetails_Interest_Level.ToList());
        }

        // GET: PersonalDetails_Interest_Level/Details/5
        public ActionResult Details(int? PersonalDetailsID,int? InterestID)
        {
            if (PersonalDetailsID == null || InterestID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_Interest_Level personalDetails_Interest_Level = db.PersonalDetails_Interest_Level.Find(PersonalDetailsID, InterestID);
            if (personalDetails_Interest_Level == null)
            {
                return HttpNotFound();
            }
            return View(personalDetails_Interest_Level);
        }

        // GET: PersonalDetails_Interest_Level/Create
        public ActionResult Create()
        {
            ViewBag.InterestID = new SelectList(db.Interests, "InterestID", "Name");
            ViewBag.LevelID = new SelectList(db.Levels, "LevelID", "Name");
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName");
            return View();
        }

        // POST: PersonalDetails_Interest_Level/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonalDetailsID,InterestID,LevelID")] PersonalDetails_Interest_Level personalDetails_Interest_Level)
        {
            if (ModelState.IsValid)
            {
                db.PersonalDetails_Interest_Level.Add(personalDetails_Interest_Level);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InterestID = new SelectList(db.Interests, "InterestID", "Name", personalDetails_Interest_Level.InterestID);
            ViewBag.LevelID = new SelectList(db.Levels, "LevelID", "Name", personalDetails_Interest_Level.LevelID);
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", personalDetails_Interest_Level.PersonalDetailsID);
            return View(personalDetails_Interest_Level);
        }

        // GET: PersonalDetails_Interest_Level/Edit/5
        public ActionResult Edit(int? PersonalDetailsID, int? InterestID)
        {
            if (PersonalDetailsID == null || InterestID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_Interest_Level personalDetails_Interest_Level = db.PersonalDetails_Interest_Level.Find(PersonalDetailsID, InterestID);
            if (personalDetails_Interest_Level == null)
            {
                return HttpNotFound();
            }
            ViewBag.InterestID = new SelectList(db.Interests, "InterestID", "Name", personalDetails_Interest_Level.InterestID);
            ViewBag.LevelID = new SelectList(db.Levels, "LevelID", "Name", personalDetails_Interest_Level.LevelID);
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", personalDetails_Interest_Level.PersonalDetailsID);
            return View(personalDetails_Interest_Level);
        }

        // POST: PersonalDetails_Interest_Level/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonalDetailsID,InterestID,LevelID")] PersonalDetails_Interest_Level personalDetails_Interest_Level)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalDetails_Interest_Level).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InterestID = new SelectList(db.Interests, "InterestID", "Name", personalDetails_Interest_Level.InterestID);
            ViewBag.LevelID = new SelectList(db.Levels, "LevelID", "Name", personalDetails_Interest_Level.LevelID);
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", personalDetails_Interest_Level.PersonalDetailsID);
            return View(personalDetails_Interest_Level);
        }

        // GET: PersonalDetails_Interest_Level/Delete/5
        public ActionResult Delete(int? PersonalDetailsID, int? InterestID)
        {
            if (PersonalDetailsID == null || InterestID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_Interest_Level personalDetails_Interest_Level = db.PersonalDetails_Interest_Level.Find(PersonalDetailsID, InterestID);
            if (personalDetails_Interest_Level == null)
            {
                return HttpNotFound();
            }
            return View(personalDetails_Interest_Level);
        }

        // POST: PersonalDetails_Interest_Level/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int PersonalDetailsID, int InterestID)
        {
            PersonalDetails_Interest_Level personalDetails_Interest_Level = db.PersonalDetails_Interest_Level.Find(PersonalDetailsID, InterestID);
            db.PersonalDetails_Interest_Level.Remove(personalDetails_Interest_Level);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
