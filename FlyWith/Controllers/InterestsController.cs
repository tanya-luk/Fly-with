using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlyWith.Models;
using Microsoft.AspNet.Identity;

namespace FlyWith.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InterestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Interests
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            var person = db.PersonalDetails.FirstOrDefault(e => (e.AspNetUserId.Equals(currentUserId)));
            if (currentUserId == null)
                return Redirect("/Account/Login");
            if (person == null)
                return RedirectToAction("Create", "PersonalDetails");
            var interests = db.Interests.Include(i => i.InterestGroup);
            return View(interests.ToList());
        }

        // GET: Interests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interest interest = db.Interests.Find(id);
            if (interest == null)
            {
                return HttpNotFound();
            }
            return View(interest);
        }

        // GET: Interests/Create
        public ActionResult Create()
        {
            ViewBag.InterestGroupID = new SelectList(db.InterestGroups, "InterestGroupID", "Name");
            return View();
        }

        // POST: Interests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InterestID,Name,InterestGroupID")] Interest interest)
        {
            if (ModelState.IsValid)
            {
                db.Interests.Add(interest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InterestGroupID = new SelectList(db.InterestGroups, "InterestGroupID", "Name", interest.InterestGroupID);
            return View(interest);
        }

        // GET: Interests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interest interest = db.Interests.Find(id);
            if (interest == null)
            {
                return HttpNotFound();
            }
            ViewBag.InterestGroupID = new SelectList(db.InterestGroups, "InterestGroupID", "Name", interest.InterestGroupID);
            return View(interest);
        }

        // POST: Interests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InterestID,Name,InterestGroupID")] Interest interest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InterestGroupID = new SelectList(db.InterestGroups, "InterestGroupID", "Name", interest.InterestGroupID);
            return View(interest);
        }

        // GET: Interests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Interest interest = db.Interests.Find(id);
            if (interest == null)
            {
                return HttpNotFound();
            }
            return View(interest);
        }

        // POST: Interests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Interest interest = db.Interests.Find(id);
            db.Interests.Remove(interest);
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
