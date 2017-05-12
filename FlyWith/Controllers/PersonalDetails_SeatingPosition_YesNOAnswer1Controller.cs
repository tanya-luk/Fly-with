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
    public class PersonalDetails_SeatingPosition_YesNOAnswer1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonalDetails_SeatingPosition_YesNOAnswer1
        public ActionResult Index()
        {
            ViewBag.DoInFlight = db.SeatingPositions.ToList();
            var personalDetails_SeatingPosition_YesNOAnswer = db.PersonalDetails_SeatingPosition_YesNOAnswer.Include(p => p.PersonalDetails).Include(p => p.SeatingPosition).Include(p => p.YesNoAnswer);
            return View(personalDetails_SeatingPosition_YesNOAnswer.ToList());
        }

        // GET: PersonalDetails_SeatingPosition_YesNOAnswer1/Details/5
        public ActionResult Details(int? PersonalDetailsID, int? DoInFlightID)
        {
            if (PersonalDetailsID == null || DoInFlightID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_SeatingPosition_YesNOAnswer personalDetails_SeatingPosition_YesNOAnswer = db.PersonalDetails_SeatingPosition_YesNOAnswer.Find(PersonalDetailsID, DoInFlightID);
            if (personalDetails_SeatingPosition_YesNOAnswer == null)
            {
                return HttpNotFound();
            }
            return View(personalDetails_SeatingPosition_YesNOAnswer);
        }

        // GET: PersonalDetails_SeatingPosition_YesNOAnswer1/Create
        public ActionResult Create()
        {
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "AspNetUserId");
            ViewBag.SeatingPositionID = new SelectList(db.SeatingPositions, "SeatingPositionID", "Name");
            ViewBag.YesNoAnswerID = new SelectList(db.YesNoAnswers, "YesNoAnswerID", "Name");
            return View();
        }

        // POST: PersonalDetails_SeatingPosition_YesNOAnswer1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonalDetailsID,SeatingPositionID,YesNoAnswerID")] PersonalDetails_SeatingPosition_YesNOAnswer personalDetails_SeatingPosition_YesNOAnswer)
        {
            if (ModelState.IsValid)
            {
                db.PersonalDetails_SeatingPosition_YesNOAnswer.Add(personalDetails_SeatingPosition_YesNOAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "AspNetUserId", personalDetails_SeatingPosition_YesNOAnswer.PersonalDetailsID);
            ViewBag.SeatingPositionID = new SelectList(db.SeatingPositions, "SeatingPositionID", "Name", personalDetails_SeatingPosition_YesNOAnswer.SeatingPositionID);
            ViewBag.YesNoAnswerID = new SelectList(db.YesNoAnswers, "YesNoAnswerID", "Name", personalDetails_SeatingPosition_YesNOAnswer.YesNoAnswerID);
            return View(personalDetails_SeatingPosition_YesNOAnswer);
        }

        // GET: PersonalDetails_SeatingPosition_YesNOAnswer1/Edit/5
        public ActionResult Edit(int? PersonalDetailsID, int? DoInFlightID)
        {
            if (PersonalDetailsID == null || DoInFlightID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_SeatingPosition_YesNOAnswer personalDetails_SeatingPosition_YesNOAnswer = db.PersonalDetails_SeatingPosition_YesNOAnswer.Find(PersonalDetailsID,DoInFlightID);
            if (personalDetails_SeatingPosition_YesNOAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "AspNetUserId", personalDetails_SeatingPosition_YesNOAnswer.PersonalDetailsID);
            ViewBag.SeatingPositionID = new SelectList(db.SeatingPositions, "SeatingPositionID", "Name", personalDetails_SeatingPosition_YesNOAnswer.SeatingPositionID);
            ViewBag.YesNoAnswerID = new SelectList(db.YesNoAnswers, "YesNoAnswerID", "Name", personalDetails_SeatingPosition_YesNOAnswer.YesNoAnswerID);
            return View(personalDetails_SeatingPosition_YesNOAnswer);
        }

        // POST: PersonalDetails_SeatingPosition_YesNOAnswer1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonalDetailsID,SeatingPositionID,YesNoAnswerID")] PersonalDetails_SeatingPosition_YesNOAnswer personalDetails_SeatingPosition_YesNOAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalDetails_SeatingPosition_YesNOAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "AspNetUserId", personalDetails_SeatingPosition_YesNOAnswer.PersonalDetailsID);
            ViewBag.SeatingPositionID = new SelectList(db.SeatingPositions, "SeatingPositionID", "Name", personalDetails_SeatingPosition_YesNOAnswer.SeatingPositionID);
            ViewBag.YesNoAnswerID = new SelectList(db.YesNoAnswers, "YesNoAnswerID", "Name", personalDetails_SeatingPosition_YesNOAnswer.YesNoAnswerID);
            return View(personalDetails_SeatingPosition_YesNOAnswer);
        }

        // GET: PersonalDetails_SeatingPosition_YesNOAnswer1/Delete/5
        public ActionResult Delete(int? PersonalDetailsID, int? DoInFlightID)
        {
            if (PersonalDetailsID == null || DoInFlightID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_SeatingPosition_YesNOAnswer personalDetails_SeatingPosition_YesNOAnswer = db.PersonalDetails_SeatingPosition_YesNOAnswer.Find(PersonalDetailsID,DoInFlightID);
            if (personalDetails_SeatingPosition_YesNOAnswer == null)
            {
                return HttpNotFound();
            }
            return View(personalDetails_SeatingPosition_YesNOAnswer);
        }

        // POST: PersonalDetails_SeatingPosition_YesNOAnswer1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? PersonalDetailsID, int? DoInFlightID)
        {
            PersonalDetails_SeatingPosition_YesNOAnswer personalDetails_SeatingPosition_YesNOAnswer = db.PersonalDetails_SeatingPosition_YesNOAnswer.Find(PersonalDetailsID,DoInFlightID);
            db.PersonalDetails_SeatingPosition_YesNOAnswer.Remove(personalDetails_SeatingPosition_YesNOAnswer);
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
