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
    public class SeatingPositionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SeatingPositions
        public ActionResult Index()
        {
            return View(db.SeatingPositions.ToList());
        }

        // GET: SeatingPositions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatingPosition seatingPosition = db.SeatingPositions.Find(id);
            if (seatingPosition == null)
            {
                return HttpNotFound();
            }
            return View(seatingPosition);
        }

        // GET: SeatingPositions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeatingPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeatingPositionID,Name")] SeatingPosition seatingPosition)
        {
            if (ModelState.IsValid)
            {
                db.SeatingPositions.Add(seatingPosition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seatingPosition);
        }

        // GET: SeatingPositions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatingPosition seatingPosition = db.SeatingPositions.Find(id);
            if (seatingPosition == null)
            {
                return HttpNotFound();
            }
            return View(seatingPosition);
        }

        // POST: SeatingPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeatingPositionID,Name")] SeatingPosition seatingPosition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seatingPosition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seatingPosition);
        }

        // GET: SeatingPositions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeatingPosition seatingPosition = db.SeatingPositions.Find(id);
            if (seatingPosition == null)
            {
                return HttpNotFound();
            }
            return View(seatingPosition);
        }

        // POST: SeatingPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeatingPosition seatingPosition = db.SeatingPositions.Find(id);
            db.SeatingPositions.Remove(seatingPosition);
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
