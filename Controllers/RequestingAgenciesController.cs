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
    public class RequestingAgenciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RequestingAgencies
        public ActionResult Index()
        {
            return View(db.RequestingAgencies.ToList());
        }

        // GET: RequestingAgencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestingAgency requestingAgency = db.RequestingAgencies.Find(id);
            if (requestingAgency == null)
            {
                return HttpNotFound();
            }
            return View(requestingAgency);
        }

        // GET: RequestingAgencies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestingAgencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AgencyName,MobileNumber,City,State,Country")] RequestingAgency requestingAgency)
        {
            if (ModelState.IsValid)
            {
                db.RequestingAgencies.Add(requestingAgency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requestingAgency);
        }

        // GET: RequestingAgencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestingAgency requestingAgency = db.RequestingAgencies.Find(id);
            if (requestingAgency == null)
            {
                return HttpNotFound();
            }
            return View(requestingAgency);
        }

        // POST: RequestingAgencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AgencyName,MobileNumber,City,State,Country")] RequestingAgency requestingAgency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestingAgency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requestingAgency);
        }

        // GET: RequestingAgencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestingAgency requestingAgency = db.RequestingAgencies.Find(id);
            if (requestingAgency == null)
            {
                return HttpNotFound();
            }
            return View(requestingAgency);
        }

        // POST: RequestingAgencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestingAgency requestingAgency = db.RequestingAgencies.Find(id);
            db.RequestingAgencies.Remove(requestingAgency);
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
