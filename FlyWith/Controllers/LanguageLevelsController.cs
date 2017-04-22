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
    public class LanguageLevelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LanguageLevels
        public ActionResult Index()
        {
            return View(db.LanguageLevels.ToList());
        }

        // GET: LanguageLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageLevel languageLevel = db.LanguageLevels.Find(id);
            if (languageLevel == null)
            {
                return HttpNotFound();
            }
            return View(languageLevel);
        }

        // GET: LanguageLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LanguageLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LanguageLevelID,Name")] LanguageLevel languageLevel)
        {
            if (ModelState.IsValid)
            {
                db.LanguageLevels.Add(languageLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(languageLevel);
        }

        // GET: LanguageLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageLevel languageLevel = db.LanguageLevels.Find(id);
            if (languageLevel == null)
            {
                return HttpNotFound();
            }
            return View(languageLevel);
        }

        // POST: LanguageLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LanguageLevelID,Name")] LanguageLevel languageLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(languageLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(languageLevel);
        }

        // GET: LanguageLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageLevel languageLevel = db.LanguageLevels.Find(id);
            if (languageLevel == null)
            {
                return HttpNotFound();
            }
            return View(languageLevel);
        }

        // POST: LanguageLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LanguageLevel languageLevel = db.LanguageLevels.Find(id);
            db.LanguageLevels.Remove(languageLevel);
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
