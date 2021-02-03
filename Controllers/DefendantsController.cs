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
    public class DefendantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Defendants
        public ActionResult Index()
        {
            return View(db.Defendants.ToList());
        }

        // GET: Defendants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Defendant defendant = db.Defendants.Find(id);
            if (defendant == null)
            {
                return HttpNotFound();
            }
            return View(defendant);
        }

        // GET: Defendants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Defendants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,DOB,SSN")] Defendant defendant)
        {
            if (ModelState.IsValid)
            {
                db.Defendants.Add(defendant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(defendant);
        }

        // GET: Defendants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Defendant defendant = db.Defendants.Find(id);
            if (defendant == null)
            {
                return HttpNotFound();
            }
            return View(defendant);
        }

        // POST: Defendants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,DOB,SSN")] Defendant defendant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defendant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defendant);
        }

        // GET: Defendants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Defendant defendant = db.Defendants.Find(id);
            if (defendant == null)
            {
                return HttpNotFound();
            }
            return View(defendant);
        }

        // POST: Defendants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Defendant defendant = db.Defendants.Find(id);
            db.Defendants.Remove(defendant);
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
