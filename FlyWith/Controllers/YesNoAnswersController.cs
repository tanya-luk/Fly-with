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
    public class YesNoAnswersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: YesNoAnswers
        public ActionResult Index()
        {
            return View(db.YesNoAnswers.ToList());
        }

        // GET: YesNoAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YesNoAnswer yesNoAnswer = db.YesNoAnswers.Find(id);
            if (yesNoAnswer == null)
            {
                return HttpNotFound();
            }
            return View(yesNoAnswer);
        }

        // GET: YesNoAnswers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YesNoAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YesNoAnswerID,Name")] YesNoAnswer yesNoAnswer)
        {
            if (ModelState.IsValid)
            {
                db.YesNoAnswers.Add(yesNoAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yesNoAnswer);
        }

        // GET: YesNoAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YesNoAnswer yesNoAnswer = db.YesNoAnswers.Find(id);
            if (yesNoAnswer == null)
            {
                return HttpNotFound();
            }
            return View(yesNoAnswer);
        }

        // POST: YesNoAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YesNoAnswerID,Name")] YesNoAnswer yesNoAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yesNoAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yesNoAnswer);
        }

        // GET: YesNoAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YesNoAnswer yesNoAnswer = db.YesNoAnswers.Find(id);
            if (yesNoAnswer == null)
            {
                return HttpNotFound();
            }
            return View(yesNoAnswer);
        }

        // POST: YesNoAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YesNoAnswer yesNoAnswer = db.YesNoAnswers.Find(id);
            db.YesNoAnswers.Remove(yesNoAnswer);
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
