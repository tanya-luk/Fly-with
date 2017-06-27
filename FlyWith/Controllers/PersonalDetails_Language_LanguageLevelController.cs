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
    public class PersonalDetails_Language_LanguageLevelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonalDetails_Language_LanguageLevel
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            var person = db.PersonalDetails.FirstOrDefault(e => (e.AspNetUserId.Equals(currentUserId)));
            if (currentUserId == null)
                return Redirect("/Account/Login");
            if (person == null)
                return RedirectToAction("Create", "PersonalDetails");
            ViewBag.Languages = db.Languages.ToList();
            var personalDetails_Language_LanguageLevel = db.PersonalDetails_Language_LanguageLevel.Include(p => p.Language).Include(p => p.LanguageLevel).Include(p => p.PersonalDetails);
            return View(personalDetails_Language_LanguageLevel.ToList());
        }

        // GET: PersonalDetails_Language_LanguageLevel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_Language_LanguageLevel personalDetails_Language_LanguageLevel = db.PersonalDetails_Language_LanguageLevel.Find(id);
            if (personalDetails_Language_LanguageLevel == null)
            {
                return HttpNotFound();
            }
            return View(personalDetails_Language_LanguageLevel);
        }

        // GET: PersonalDetails_Language_LanguageLevel/Create
        public ActionResult Create()
        {
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "Name");
            ViewBag.LevelID = new SelectList(db.LanguageLevels, "LanguageLevelID", "Name");
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName");
            return View();
        }

        // POST: PersonalDetails_Language_LanguageLevel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonalDetailsID,LanguageID,LevelID")] PersonalDetails_Language_LanguageLevel personalDetails_Language_LanguageLevel)
        {
            if (ModelState.IsValid)
            {
                db.PersonalDetails_Language_LanguageLevel.Add(personalDetails_Language_LanguageLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "Name", personalDetails_Language_LanguageLevel.LanguageID);
            ViewBag.LevelID = new SelectList(db.LanguageLevels, "LanguageLevelID", "Name", personalDetails_Language_LanguageLevel.LevelID);
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", personalDetails_Language_LanguageLevel.PersonalDetailsID);
            return View(personalDetails_Language_LanguageLevel);
        }

        // GET: PersonalDetails_Language_LanguageLevel/Edit/5
        public ActionResult Edit(int? PersonalDetailsID, int? LanguageID)
        {
            if (PersonalDetailsID == null || LanguageID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_Language_LanguageLevel personalDetails_Language_LanguageLevel = db.PersonalDetails_Language_LanguageLevel.Find(PersonalDetailsID,LanguageID);
            if (personalDetails_Language_LanguageLevel == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "Name", personalDetails_Language_LanguageLevel.LanguageID);
            ViewBag.LevelID = new SelectList(db.LanguageLevels, "LanguageLevelID", "Name", personalDetails_Language_LanguageLevel.LevelID);
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", personalDetails_Language_LanguageLevel.PersonalDetailsID);
            return View(personalDetails_Language_LanguageLevel);
        }

        // POST: PersonalDetails_Language_LanguageLevel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonalDetailsID,LanguageID,LevelID")] PersonalDetails_Language_LanguageLevel personalDetails_Language_LanguageLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalDetails_Language_LanguageLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageID = new SelectList(db.Languages, "LanguageID", "Name", personalDetails_Language_LanguageLevel.LanguageID);
            ViewBag.LevelID = new SelectList(db.LanguageLevels, "LanguageLevelID", "Name", personalDetails_Language_LanguageLevel.LevelID);
            ViewBag.PersonalDetailsID = new SelectList(db.PersonalDetails, "PersonalDetailsID", "FirstName", personalDetails_Language_LanguageLevel.PersonalDetailsID);
            return View(personalDetails_Language_LanguageLevel);
        }

        // GET: PersonalDetails_Language_LanguageLevel/Delete/5
        public ActionResult Delete(int? PersonalDetailsID, int? LanguageID)
        {
            if (PersonalDetailsID == null || LanguageID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalDetails_Language_LanguageLevel personalDetails_Language_LanguageLevel = db.PersonalDetails_Language_LanguageLevel.Find(PersonalDetailsID,LanguageID);
            if (personalDetails_Language_LanguageLevel == null)
            {
                return HttpNotFound();
            }
            return View(personalDetails_Language_LanguageLevel);
        }

        // POST: PersonalDetails_Language_LanguageLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? PersonalDetailsID, int? LanguageID)
        {
            PersonalDetails_Language_LanguageLevel personalDetails_Language_LanguageLevel = db.PersonalDetails_Language_LanguageLevel.Find(PersonalDetailsID,LanguageID);
            db.PersonalDetails_Language_LanguageLevel.Remove(personalDetails_Language_LanguageLevel);
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
