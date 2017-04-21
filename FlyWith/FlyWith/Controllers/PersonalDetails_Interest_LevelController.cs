using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlyWith.Models;

namespace FlyWith.Controllers
{
    public class PersonalDetails_Interest_LevelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonalDetails_Interest_Level
        public ActionResult Index()
        {
            var personalDetails_Interest_Level = db.PersonalDetails_Interest_Level.Include(p => p.Interest).Include(p => p.Level).Include(p => p.PersonalDetails);
            return View(personalDetails_Interest_Level.ToList());
        }

        // GET: PersonalDetails_Interest_Level/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_Interest_Level personalDetails_Interest_Level = db.PersonalDetails_Interest_Level.Find(id);
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_Interest_Level personalDetails_Interest_Level = db.PersonalDetails_Interest_Level.Find(id);
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_Interest_Level personalDetails_Interest_Level = db.PersonalDetails_Interest_Level.Find(id);
            if (personalDetails_Interest_Level == null)
            {
                return HttpNotFound();
            }
            return View(personalDetails_Interest_Level);
        }

        // POST: PersonalDetails_Interest_Level/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalDetails_Interest_Level personalDetails_Interest_Level = db.PersonalDetails_Interest_Level.Find(id);
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
