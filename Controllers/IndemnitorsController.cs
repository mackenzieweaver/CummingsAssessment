using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CummingsAssessment.Models;

namespace CummingsAssessment.Controllers
{
    public class IndemnitorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Indemnitors
        public ActionResult Index()
        {
            return View(db.Indemnitors.ToList());
        }

        // GET: Indemnitors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indemnitor indemnitor = db.Indemnitors.Find(id);
            if (indemnitor == null)
            {
                return HttpNotFound();
            }
            return View(indemnitor);
        }

        // GET: Indemnitors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Indemnitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,Middle,LastName,Alias,DOB,Gender,Ethnicity,SSN,EmailAddress,MobileNumber")] Indemnitor indemnitor)
        {
            if (ModelState.IsValid)
            {
                db.Indemnitors.Add(indemnitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(indemnitor);
        }

        // GET: Indemnitors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indemnitor indemnitor = db.Indemnitors.Find(id);
            if (indemnitor == null)
            {
                return HttpNotFound();
            }
            return View(indemnitor);
        }

        // POST: Indemnitors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,Middle,LastName,Alias,DOB,Gender,Ethnicity,SSN,EmailAddress,MobileNumber")] Indemnitor indemnitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indemnitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(indemnitor);
        }

        // GET: Indemnitors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indemnitor indemnitor = db.Indemnitors.Find(id);
            if (indemnitor == null)
            {
                return HttpNotFound();
            }
            return View(indemnitor);
        }

        // POST: Indemnitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Indemnitor indemnitor = db.Indemnitors.Find(id);
            db.Indemnitors.Remove(indemnitor);
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
