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
    public class DoInFlightsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DoInFlights
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            var person = db.PersonalDetails.FirstOrDefault(e => (e.AspNetUserId.Equals(currentUserId)));
            if (currentUserId == null)
                return Redirect("/Account/Login");
            if (person == null)
                return RedirectToAction("Create", "PersonalDetails");
            return View(db.DoInFlights.ToList());
        }

        // GET: DoInFlights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoInFlight doInFlight = db.DoInFlights.Find(id);
            if (doInFlight == null)
            {
                return HttpNotFound();
            }
            return View(doInFlight);
        }

        // GET: DoInFlights/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoInFlights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoInFlightID,Name")] DoInFlight doInFlight)
        {
            if (ModelState.IsValid)
            {
                db.DoInFlights.Add(doInFlight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doInFlight);
        }

        // GET: DoInFlights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoInFlight doInFlight = db.DoInFlights.Find(id);
            if (doInFlight == null)
            {
                return HttpNotFound();
            }
            return View(doInFlight);
        }

        // POST: DoInFlights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoInFlightID,Name")] DoInFlight doInFlight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doInFlight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doInFlight);
        }

        // GET: DoInFlights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoInFlight doInFlight = db.DoInFlights.Find(id);
            if (doInFlight == null)
            {
                return HttpNotFound();
            }
            return View(doInFlight);
        }

        // POST: DoInFlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoInFlight doInFlight = db.DoInFlights.Find(id);
            db.DoInFlights.Remove(doInFlight);
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
