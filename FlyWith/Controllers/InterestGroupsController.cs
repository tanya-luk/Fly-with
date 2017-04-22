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
    public class InterestGroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InterestGroups
        public ActionResult Index()
        {
            return View(db.InterestGroups.ToList());
        }

        // GET: InterestGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestGroup interestGroup = db.InterestGroups.Find(id);
            if (interestGroup == null)
            {
                return HttpNotFound();
            }
            return View(interestGroup);
        }

        // GET: InterestGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InterestGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InterestGroupID,Name")] InterestGroup interestGroup)
        {
            if (ModelState.IsValid)
            {
                db.InterestGroups.Add(interestGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interestGroup);
        }

        // GET: InterestGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestGroup interestGroup = db.InterestGroups.Find(id);
            if (interestGroup == null)
            {
                return HttpNotFound();
            }
            return View(interestGroup);
        }

        // POST: InterestGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InterestGroupID,Name")] InterestGroup interestGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interestGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interestGroup);
        }

        // GET: InterestGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestGroup interestGroup = db.InterestGroups.Find(id);
            if (interestGroup == null)
            {
                return HttpNotFound();
            }
            return View(interestGroup);
        }

        // POST: InterestGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InterestGroup interestGroup = db.InterestGroups.Find(id);
            db.InterestGroups.Remove(interestGroup);
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
