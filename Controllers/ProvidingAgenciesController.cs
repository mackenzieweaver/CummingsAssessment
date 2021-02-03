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
    public class ProvidingAgenciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProvidingAgencies
        public ActionResult Index()
        {
            return View(db.ProvidingAgencies.ToList());
        }

        // GET: ProvidingAgencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvidingAgency providingAgency = db.ProvidingAgencies.Find(id);
            if (providingAgency == null)
            {
                return HttpNotFound();
            }
            return View(providingAgency);
        }

        // GET: ProvidingAgencies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvidingAgencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AgentName,AgencyName,Date,MobileNumber,City,State,Country")] ProvidingAgency providingAgency)
        {
            if (ModelState.IsValid)
            {
                db.ProvidingAgencies.Add(providingAgency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(providingAgency);
        }

        // GET: ProvidingAgencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvidingAgency providingAgency = db.ProvidingAgencies.Find(id);
            if (providingAgency == null)
            {
                return HttpNotFound();
            }
            return View(providingAgency);
        }

        // POST: ProvidingAgencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AgentName,AgencyName,Date,MobileNumber,City,State,Country")] ProvidingAgency providingAgency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providingAgency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(providingAgency);
        }

        // GET: ProvidingAgencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvidingAgency providingAgency = db.ProvidingAgencies.Find(id);
            if (providingAgency == null)
            {
                return HttpNotFound();
            }
            return View(providingAgency);
        }

        // POST: ProvidingAgencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProvidingAgency providingAgency = db.ProvidingAgencies.Find(id);
            db.ProvidingAgencies.Remove(providingAgency);
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
