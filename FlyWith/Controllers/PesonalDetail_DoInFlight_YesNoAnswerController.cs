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
using Microsoft.Ajax.Utilities;

namespace FlyWith.Controllers
{
    [Authorize(Roles = "User")]
    public class PesonalDetail_DoInFlight_YesNoAnswerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PesonalDetail_DoInFlight_YesNoAnswer
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            var person = db.PersonalDetails.FirstOrDefault(e => (e.AspNetUserId.Equals(currentUserId)));
            if (currentUserId == null)
                return Redirect("/Account/Login");
            if (person == null)
                return RedirectToAction("Create", "PersonalDetails");

            var doInFlight = db.DoInFlights.Select(d => d.DoInFlightID).ToList();
            var YesNoAnswer = db.YesNoAnswers.Where(y => y.Name.Equals("No")).Select(y => y.YesNoAnswerID);
            if (doInFlight.ToList().Count > 0)
            {

                foreach (var inter in doInFlight.ToList())
                {
                    var exist = db.PesonalDetail_DoInFlight_YesNoAnswer.Where(p => p.DoInFlightID.Equals(inter) && p.PersonalDetailsID.Equals(person.PersonalDetailsID)).ToList();
                    if (exist.Count == 0)
                    {
                        PesonalDetail_DoInFlight_YesNoAnswer record = new PesonalDetail_DoInFlight_YesNoAnswer
                        {
                            PersonalDetailsID = person.PersonalDetailsID,
                            DoInFlightID = inter,
                            YesNoAnswerID = YesNoAnswer.First()
                        };
                        db.PesonalDetail_DoInFlight_YesNoAnswer.Add(record);
                        db.SaveChanges();
                    }
                }

            }

            ViewBag.DoInFlight = db.DoInFlights.ToList();
            var pesonalDetail_DoInFlight_YesNoAnswer = db.PesonalDetail_DoInFlight_YesNoAnswer.Include(p => p.DoInFlight).Include(p => p.PersonalDetails).Include(p => p.YesNoAnswer);
            return View(pesonalDetail_DoInFlight_YesNoAnswer.ToList());
        }

        // GET: PesonalDetail_DoInFlight_YesNoAnswer/Details/5
        public ActionResult Details(int? personDetailsID, int? doInFlightID)
        {
            if (personDetailsID == null || doInFlightID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesonalDetail_DoInFlight_YesNoAnswer pesonalDetail_DoInFlight_YesNoAnswer = db.PesonalDetail_DoInFlight_YesNoAnswer.Find(personDetailsID, doInFlightID);
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
        public ActionResult Edit(int? personalDetailsID, int? doInFlightID)
        {
            if (personalDetailsID == null || doInFlightID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesonalDetail_DoInFlight_YesNoAnswer pesonalDetail_DoInFlight_YesNoAnswer = db.PesonalDetail_DoInFlight_YesNoAnswer.Find(personalDetailsID, doInFlightID);
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

                //check if user is in the dating mood
                string currentUserId = User.Identity.GetUserId();
                PersonalDetails person = db.PersonalDetails.Where(p => p.AspNetUserId.Equals(currentUserId)).First();

                var answer = pesonalDetail_DoInFlight_YesNoAnswer.YesNoAnswerID;
                var mood = pesonalDetail_DoInFlight_YesNoAnswer.DoInFlightID;
                var datingMood = db.DoInFlights.Where(d => d.Name.Equals("Dating")).Select(d => d.DoInFlightID);
                var DatingMood = datingMood.First();

                var Yes_answer = db.YesNoAnswers.Where(y => y.Name.Equals("Yes")).Select(y => y.YesNoAnswerID);
                var yes_answer = Yes_answer.First();
                var No_answer = db.YesNoAnswers.Where(y => y.Name.Equals("No")).Select(y => y.YesNoAnswerID);
                var no_answer = No_answer.First();
                if (DatingMood.Equals(mood))
                {
                    if (yes_answer.Equals(answer))
                    {
                        var person_dating = db.Datings.Where(d => d.PersonalDetailsID.Equals(person.PersonalDetailsID));
                        if (person_dating.Count() < 1)
                        {
                            return RedirectToAction("Create","Datings");

                        }
                        else
                        {

                            return RedirectToAction("Edit","Datings", new { id = person.PersonalDetailsID });

                        }
                    }   
                }

                //check if user is in the silence mood
                var silence_mood = db.DoInFlights.Where(d => d.Name.Equals("Silence")).First();
                var Silence_mood = silence_mood.DoInFlightID;
                var personal_details = pesonalDetail_DoInFlight_YesNoAnswer.PersonalDetailsID;
                var this_person_mood_no_silenceMood = db.PesonalDetail_DoInFlight_YesNoAnswer.Where(p => p.DoInFlightID != Silence_mood && p.PersonalDetailsID.Equals(person.PersonalDetailsID)).ToList();
                var this_person_mood_silenceMood = db.PesonalDetail_DoInFlight_YesNoAnswer.Where(p => p.DoInFlightID.Equals(Silence_mood) && p.PersonalDetailsID.Equals(person.PersonalDetailsID) && p.YesNoAnswerID.Equals(yes_answer)).ToList();
                if (mood.Equals(Silence_mood))

                {
                    if (answer.Equals(yes_answer))
                    {
                        foreach (var p in this_person_mood_no_silenceMood)
                        {
                            p.YesNoAnswerID = no_answer;
                            db.Entry(pesonalDetail_DoInFlight_YesNoAnswer).State = EntityState.Modified;
                            db.SaveChanges();
                        }

                    }
                }
                //if we are in the silence mood and trying to do yes to another mood
                else
                {
                    if (answer.Equals(yes_answer))
                    {
                        if (this_person_mood_silenceMood.Count() > 0)
                        {
                            this_person_mood_silenceMood.First().YesNoAnswerID = no_answer;
                            db.Entry(pesonalDetail_DoInFlight_YesNoAnswer).State = EntityState.Modified;
                            db.SaveChanges(); ;
                            return RedirectToAction("Index");

                        }
                    }

                }

                return RedirectToAction("Index");
            }
            ViewBag.DoInFlightID = new SelectList(db.DoInFlights, "DoInFlightID", "Name", pesonalDetail_DoInFlight_YesNoAnswer.DoInFlightID);
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", pesonalDetail_DoInFlight_YesNoAnswer.PersonalDetailsID);
            ViewBag.YesNoAnswerID = new SelectList(db.YesNoAnswers, "YesNoAnswerID", "Name", pesonalDetail_DoInFlight_YesNoAnswer.YesNoAnswerID);

            return View(pesonalDetail_DoInFlight_YesNoAnswer);
        }

        // GET: PesonalDetail_DoInFlight_YesNoAnswer/Delete/5
        public ActionResult Delete(int? personalDetailsID, int? doInFlightID)
        {
            if (personalDetailsID == null || doInFlightID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PesonalDetail_DoInFlight_YesNoAnswer pesonalDetail_DoInFlight_YesNoAnswer = db.PesonalDetail_DoInFlight_YesNoAnswer.Find(personalDetailsID, doInFlightID);
            if (pesonalDetail_DoInFlight_YesNoAnswer == null)
            {
                return HttpNotFound();
            }
            return View(pesonalDetail_DoInFlight_YesNoAnswer);
        }

        // POST: PesonalDetail_DoInFlight_YesNoAnswer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? personalDetailsID, int? doInFlightID)
        {
            PesonalDetail_DoInFlight_YesNoAnswer pesonalDetail_DoInFlight_YesNoAnswer = db.PesonalDetail_DoInFlight_YesNoAnswer.Find(personalDetailsID, doInFlightID);
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
