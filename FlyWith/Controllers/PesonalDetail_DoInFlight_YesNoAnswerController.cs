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
    public class PesonalDetail_DoInFlight_YesNoAnswerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PesonalDetail_DoInFlight_YesNoAnswer
        public ActionResult Index()
        {
            ViewBag.DoInFlight = db.DoInFlights.ToList();
            var pesonalDetail_DoInFlight_YesNoAnswer = db.PesonalDetail_DoInFlight_YesNoAnswer.Include(p => p.DoInFlight).Include(p => p.PersonalDetails).Include(p => p.YesNoAnswer);
            return View(pesonalDetail_DoInFlight_YesNoAnswer.ToList());
        }

        // GET: PesonalDetail_DoInFlight_YesNoAnswer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesonalDetail_DoInFlight_YesNoAnswer pesonalDetail_DoInFlight_YesNoAnswer = db.PesonalDetail_DoInFlight_YesNoAnswer.Find(id);
            if (pesonalDetail_DoInFlight_YesNoAnswer == null)
            {
                return HttpNotFound();
            }
            return View(pesonalDetail_DoInFlight_YesNoAnswer);
        }

        // GET: PesonalDetail_DoInFlight_YesNoAnswer/Create
        public ActionResult Create()
        {
            ViewBag.DoInFlightID = new SelectList(db.DoInFlights, "DoInFlightID", "Name");
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName");
            ViewBag.YesNoAnswerID = new SelectList(db.YesNoAnswers, "YesNoAnswerID", "Name");
            return View();
        }

        // POST: PesonalDetail_DoInFlight_YesNoAnswer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonalDetailsID,DoInFlightID,YesNoAnswerID")] PesonalDetail_DoInFlight_YesNoAnswer pesonalDetail_DoInFlight_YesNoAnswer)
        {
            if (ModelState.IsValid)
            {
                db.PesonalDetail_DoInFlight_YesNoAnswer.Add(pesonalDetail_DoInFlight_YesNoAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoInFlightID = new SelectList(db.DoInFlights, "DoInFlightID", "Name", pesonalDetail_DoInFlight_YesNoAnswer.DoInFlightID);
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", pesonalDetail_DoInFlight_YesNoAnswer.PersonalDetailsID);
            ViewBag.YesNoAnswerID = new SelectList(db.YesNoAnswers, "YesNoAnswerID", "Name", pesonalDetail_DoInFlight_YesNoAnswer.YesNoAnswerID);
            return View(pesonalDetail_DoInFlight_YesNoAnswer);
        }

        // GET: PesonalDetail_DoInFlight_YesNoAnswer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesonalDetail_DoInFlight_YesNoAnswer pesonalDetail_DoInFlight_YesNoAnswer = db.PesonalDetail_DoInFlight_YesNoAnswer.Find(id);
            if (pesonalDetail_DoInFlight_YesNoAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoInFlightID = new SelectList(db.DoInFlights, "DoInFlightID", "Name", pesonalDetail_DoInFlight_YesNoAnswer.DoInFlightID);
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", pesonalDetail_DoInFlight_YesNoAnswer.PersonalDetailsID);
            ViewBag.YesNoAnswerID = new SelectList(db.YesNoAnswers, "YesNoAnswerID", "Name", pesonalDetail_DoInFlight_YesNoAnswer.YesNoAnswerID);
            return View(pesonalDetail_DoInFlight_YesNoAnswer);
        }

        // POST: PesonalDetail_DoInFlight_YesNoAnswer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonalDetailsID,DoInFlightID,YesNoAnswerID")] PesonalDetail_DoInFlight_YesNoAnswer pesonalDetail_DoInFlight_YesNoAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pesonalDetail_DoInFlight_YesNoAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoInFlightID = new SelectList(db.DoInFlights, "DoInFlightID", "Name", pesonalDetail_DoInFlight_YesNoAnswer.DoInFlightID);
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", pesonalDetail_DoInFlight_YesNoAnswer.PersonalDetailsID);
            ViewBag.YesNoAnswerID = new SelectList(db.YesNoAnswers, "YesNoAnswerID", "Name", pesonalDetail_DoInFlight_YesNoAnswer.YesNoAnswerID);
            return View(pesonalDetail_DoInFlight_YesNoAnswer);
        }

        // GET: PesonalDetail_DoInFlight_YesNoAnswer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesonalDetail_DoInFlight_YesNoAnswer pesonalDetail_DoInFlight_YesNoAnswer = db.PesonalDetail_DoInFlight_YesNoAnswer.Find(id);
            if (pesonalDetail_DoInFlight_YesNoAnswer == null)
            {
                return HttpNotFound();
            }
            return View(pesonalDetail_DoInFlight_YesNoAnswer);
        }

        // POST: PesonalDetail_DoInFlight_YesNoAnswer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PesonalDetail_DoInFlight_YesNoAnswer pesonalDetail_DoInFlight_YesNoAnswer = db.PesonalDetail_DoInFlight_YesNoAnswer.Find(id);
            db.PesonalDetail_DoInFlight_YesNoAnswer.Remove(pesonalDetail_DoInFlight_YesNoAnswer);
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
