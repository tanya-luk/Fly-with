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
    [Authorize(Roles = "User")]
    public class PersonalDetails_SeatingPosition_YesNOAnswerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonalDetails_SeatingPosition_YesNOAnswer
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            var person = db.PersonalDetails.FirstOrDefault(e => (e.AspNetUserId.Equals(currentUserId)));
            if (currentUserId == null)
                return Redirect("/Account/Login");
            if (person == null)
                return RedirectToAction("Create", "PersonalDetails");
            var SeatingPositions = db.SeatingPositions.Select(s => s.SeatingPositionID).ToList();
            var YesNoAnswer = db.YesNoAnswers.Where(i => i.Name.Equals("No")).Select(i => i.YesNoAnswerID);
            if (SeatingPositions.ToList().Count > 0)
            {

                foreach (var inter in SeatingPositions.ToList())
                {
                    var exist = db.PersonalDetails_SeatingPosition_YesNOAnswer.Where(p => p.SeatingPositionID.Equals(inter) && p.PersonalDetailsID.Equals(person.PersonalDetailsID)).ToList();
                    if (exist.Count == 0)
                    {
                        PersonalDetails_SeatingPosition_YesNOAnswer record = new PersonalDetails_SeatingPosition_YesNOAnswer
                        {
                            PersonalDetailsID = person.PersonalDetailsID,
                            SeatingPositionID = inter,
                            YesNoAnswerID = YesNoAnswer.First()
                        };
                        db.PersonalDetails_SeatingPosition_YesNOAnswer.Add(record);
                        db.SaveChanges();
                    }
                }

            }
            ViewBag.SeatingPositions = db.SeatingPositions.ToList();
            var personalDetails_SeatingPosition_YesNOAnswer = db.PersonalDetails_SeatingPosition_YesNOAnswer.Include(p => p.PersonalDetails).Include(p => p.SeatingPosition).Include(p => p.YesNoAnswer);
            return View(personalDetails_SeatingPosition_YesNOAnswer.ToList());
        }

        // GET: PersonalDetails_SeatingPosition_YesNOAnswer/Details/5
        public ActionResult Details(int? PersonalDetailsID, int? SeatingPositionID)
        {
            if (PersonalDetailsID == null || SeatingPositionID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_SeatingPosition_YesNOAnswer personalDetails_SeatingPosition_YesNOAnswer = db.PersonalDetails_SeatingPosition_YesNOAnswer.Find(PersonalDetailsID, SeatingPositionID);
            if (personalDetails_SeatingPosition_YesNOAnswer == null)
            {
                return HttpNotFound();
            }
            return View(personalDetails_SeatingPosition_YesNOAnswer);
        }

        // GET: PersonalDetails_SeatingPosition_YesNOAnswer/Create
        public ActionResult Create()
        {
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName");
            ViewBag.SeatingPositionID = new SelectList(db.SeatingPositions, "SeatingPositionID", "Name");
            ViewBag.YesNoAnswerID = new SelectList(db.YesNoAnswers, "YesNoAnswerID", "Name");
            return View();
        }

        // POST: PersonalDetails_SeatingPosition_YesNOAnswer/Create
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

            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", personalDetails_SeatingPosition_YesNOAnswer.PersonalDetailsID);
            ViewBag.SeatingPositionID = new SelectList(db.SeatingPositions, "SeatingPositionID", "Name", personalDetails_SeatingPosition_YesNOAnswer.SeatingPositionID);
            ViewBag.YesNoAnswerID = new SelectList(db.YesNoAnswers, "YesNoAnswerID", "Name", personalDetails_SeatingPosition_YesNOAnswer.YesNoAnswerID);
            return View(personalDetails_SeatingPosition_YesNOAnswer);
        }

        // GET: PersonalDetails_SeatingPosition_YesNOAnswer/Edit/5
        public ActionResult Edit(int? PersonalDetailsID, int? SeatingPositionID)
        {
            if (PersonalDetailsID == null || SeatingPositionID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_SeatingPosition_YesNOAnswer personalDetails_SeatingPosition_YesNOAnswer = db.PersonalDetails_SeatingPosition_YesNOAnswer.Find(PersonalDetailsID, SeatingPositionID);
            if (personalDetails_SeatingPosition_YesNOAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", personalDetails_SeatingPosition_YesNOAnswer.PersonalDetailsID);
            ViewBag.SeatingPositionID = new SelectList(db.SeatingPositions, "SeatingPositionID", "Name", personalDetails_SeatingPosition_YesNOAnswer.SeatingPositionID);
            ViewBag.YesNoAnswerID = new SelectList(db.YesNoAnswers, "YesNoAnswerID", "Name", personalDetails_SeatingPosition_YesNOAnswer.YesNoAnswerID);
            return View(personalDetails_SeatingPosition_YesNOAnswer);
        }

        // POST: PersonalDetails_SeatingPosition_YesNOAnswer/Edit/5
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
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", personalDetails_SeatingPosition_YesNOAnswer.PersonalDetailsID);
            ViewBag.SeatingPositionID = new SelectList(db.SeatingPositions, "SeatingPositionID", "Name", personalDetails_SeatingPosition_YesNOAnswer.SeatingPositionID);
            ViewBag.YesNoAnswerID = new SelectList(db.YesNoAnswers, "YesNoAnswerID", "Name", personalDetails_SeatingPosition_YesNOAnswer.YesNoAnswerID);
            return View(personalDetails_SeatingPosition_YesNOAnswer);
        }

        // GET: PersonalDetails_SeatingPosition_YesNOAnswer/Delete/5
        public ActionResult Delete(int? PersonalDetailsID, int? SeatingPositionID)
        {
            if (PersonalDetailsID == null || SeatingPositionID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_SeatingPosition_YesNOAnswer personalDetails_SeatingPosition_YesNOAnswer = db.PersonalDetails_SeatingPosition_YesNOAnswer.Find(PersonalDetailsID,SeatingPositionID);
            if (personalDetails_SeatingPosition_YesNOAnswer == null)
            {
                return HttpNotFound();
            }
            return View(personalDetails_SeatingPosition_YesNOAnswer);
        }

        // POST: PersonalDetails_SeatingPosition_YesNOAnswer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? PersonalDetailsID, int? SeatingPositionID)
        {
            PersonalDetails_SeatingPosition_YesNOAnswer personalDetails_SeatingPosition_YesNOAnswer = db.PersonalDetails_SeatingPosition_YesNOAnswer.Find(PersonalDetailsID,SeatingPositionID);
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
