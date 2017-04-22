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
    public class PersonalDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonalDetails
        public ActionResult Index()
        {
            var personalDetails = db.PersonalDetails.Include(p => p.Country).Include(p => p.MealType).Include(p => p.Sex);
            return View(personalDetails.ToList());
        }

        // GET: PersonalDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails personalDetails = db.PersonalDetails.Find(id);
            if (personalDetails == null)
            {
                return HttpNotFound();
            }
            return View(personalDetails);
        }

        // GET: PersonalDetails/Create
        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name");
            ViewBag.MealTypeID = new SelectList(db.MealTypes, "MealTypeID", "Name");
            ViewBag.SexID = new SelectList(db.Sexes, "SexID", "Name");
            return View();
        }

        // POST: PersonalDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonalDetailsID,FirstName,LastName,Birthday,MealTypeID,CountryID,SexID")] PersonalDetails personalDetails)
        {
            if (ModelState.IsValid)
            {
                db.PersonalDetails.Add(personalDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", personalDetails.CountryID);
            ViewBag.MealTypeID = new SelectList(db.MealTypes, "MealTypeID", "Name", personalDetails.MealTypeID);
            ViewBag.SexID = new SelectList(db.Sexes, "SexID", "Name", personalDetails.SexID);
            return View(personalDetails);
        }

        // GET: PersonalDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails personalDetails = db.PersonalDetails.Find(id);
            if (personalDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", personalDetails.CountryID);
            ViewBag.MealTypeID = new SelectList(db.MealTypes, "MealTypeID", "Name", personalDetails.MealTypeID);
            ViewBag.SexID = new SelectList(db.Sexes, "SexID", "Name", personalDetails.SexID);
            return View(personalDetails);
        }

        // POST: PersonalDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonalDetailsID,FirstName,LastName,Birthday,MealTypeID,CountryID,SexID")] PersonalDetails personalDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", personalDetails.CountryID);
            ViewBag.MealTypeID = new SelectList(db.MealTypes, "MealTypeID", "Name", personalDetails.MealTypeID);
            ViewBag.SexID = new SelectList(db.Sexes, "SexID", "Name", personalDetails.SexID);
            return View(personalDetails);
        }

        // GET: PersonalDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails personalDetails = db.PersonalDetails.Find(id);
            if (personalDetails == null)
            {
                return HttpNotFound();
            }
            return View(personalDetails);
        }

        // POST: PersonalDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalDetails personalDetails = db.PersonalDetails.Find(id);
            db.PersonalDetails.Remove(personalDetails);
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
