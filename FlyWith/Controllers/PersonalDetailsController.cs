using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FlyWith.Models;
using Microsoft.AspNet.Identity;

namespace FlyWith.Controllers
{
    public class PersonalDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonalDetails
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            var person = db.PersonalDetails.FirstOrDefault(e => (e.AspNetUserId.Equals(currentUserId)));
            if (person != null)
                return Redirect("PersonalDetails/Details/" + person.PersonalDetailsID);
            return Redirect("PersonalDetails/Create");
            //var personalDetails = db.PersonalDetails.Include(p => p.AspNetUser).Include(p => p.Country).Include(p => p.MealType).Include(p => p.Occupation).Include(p => p.Sex);
            //return View(personalDetails.ToList());
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
            //ViewBag.AspNetUserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name");
            ViewBag.MealTypeID = new SelectList(db.MealTypes, "MealTypeID", "Name");
            ViewBag.OccupationID = new SelectList(db.Occupations, "OccupationID", "Name");
            ViewBag.SexID = new SelectList(db.Sexes, "SexID", "Name");
            return View();
        }

        // POST: PersonalDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonalDetailsID,AspNetUserId,FirstName,LastName,Birthday,MealTypeID,CountryID,SexID,OccupationID")] PersonalDetails personalDetails)
        {
            if (ModelState.IsValid)
            {
                personalDetails.AspNetUserId = User.Identity.GetUserId();
                db.PersonalDetails.Add(personalDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.AspNetUserId = new SelectList(db.ApplicationUsers, "Id", "Email", personalDetails.AspNetUserId);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", personalDetails.CountryID);
            ViewBag.MealTypeID = new SelectList(db.MealTypes, "MealTypeID", "Name", personalDetails.MealTypeID);
            ViewBag.OccupationID = new SelectList(db.Occupations, "OccupationID", "Name", personalDetails.OccupationID);
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
            //ViewBag.AspNetUserId = new SelectList(db.ApplicationUsers, "Id", "Email", personalDetails.AspNetUserId);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", personalDetails.CountryID);
            ViewBag.MealTypeID = new SelectList(db.MealTypes, "MealTypeID", "Name", personalDetails.MealTypeID);
            ViewBag.OccupationID = new SelectList(db.Occupations, "OccupationID", "Name", personalDetails.OccupationID);
            ViewBag.SexID = new SelectList(db.Sexes, "SexID", "Name", personalDetails.SexID);
            return View(personalDetails);
        }

        // POST: PersonalDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonalDetailsID,AspNetUserId,FirstName,LastName,Birthday,MealTypeID,CountryID,SexID,OccupationID")] PersonalDetails personalDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.AspNetUserId = new SelectList(db.ApplicationUsers, "Id", "Email", personalDetails.AspNetUserId);
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", personalDetails.CountryID);
            ViewBag.MealTypeID = new SelectList(db.MealTypes, "MealTypeID", "Name", personalDetails.MealTypeID);
            ViewBag.OccupationID = new SelectList(db.Occupations, "OccupationID", "Name", personalDetails.OccupationID);
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
