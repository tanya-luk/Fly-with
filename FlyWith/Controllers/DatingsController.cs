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

    public class DatingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Datings
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            var person = db.PersonalDetails.FirstOrDefault(e => (e.AspNetUserId.Equals(currentUserId)));
            if (currentUserId == null)
                return Redirect("/Account/Login");
            if (person == null)
                return Redirect("PersonalDetails/Create");
            var datings = db.Datings.Include(d => d.PersonalDetails).Include(d => d.Sex);
            return View(datings.ToList());
        }

        // GET: Datings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dating dating = db.Datings.Find(id);
            if (dating == null)
            {
                return HttpNotFound();
            }
            return View(dating);
        }

        // GET: Datings/Create
        public ActionResult Create()
        {
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName");
            ViewBag.SexID = new SelectList(db.Sexes, "SexID", "Name");
            return View();
        }

        // POST: Datings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonalDetailsID,FromAge,ToAge,SexID")] Dating dating)
        {
            if (ModelState.IsValid)
            {
                db.Datings.Add(dating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", dating.PersonalDetailsID);
            ViewBag.SexID = new SelectList(db.Sexes, "SexID", "Name", dating.SexID);
            return View(dating);
        }

        // GET: Datings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dating dating = db.Datings.Find(id);
            if (dating == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", dating.PersonalDetailsID);
            ViewBag.SexID = new SelectList(db.Sexes, "SexID", "Name", dating.SexID);
            return View(dating);
        }

        // POST: Datings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonalDetailsID,FromAge,ToAge,SexID")] Dating dating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", dating.PersonalDetailsID);
            ViewBag.SexID = new SelectList(db.Sexes, "SexID", "Name", dating.SexID);
            return View(dating);
        }

        // GET: Datings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dating dating = db.Datings.Find(id);
            if (dating == null)
            {
                return HttpNotFound();
            }
            return View(dating);
        }

        // POST: Datings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dating dating = db.Datings.Find(id);
            db.Datings.Remove(dating);
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
