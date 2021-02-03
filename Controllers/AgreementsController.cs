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
    public class AgreementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Agreements
        public ActionResult Index()
        {
            var agreements = db.Agreements.Include(a => a.BondTransfer).Include(a => a.Defendant).Include(a => a.Indemnitor).Include(a => a.Jail).Include(a => a.ProvidingAgency).Include(a => a.RequestingAgency);
            return View(agreements.ToList());
        }

        // GET: Agreements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agreement agreement = db.Agreements.Find(id);
            if (agreement == null)
            {
                return HttpNotFound();
            }
            return View(agreement);
        }

        // GET: Agreements/Create
        public ActionResult Create()
        {
            ViewBag.BondTransferId = new SelectList(db.BondTransfers, "Id", "SerialNumber");
            ViewBag.DefendantId = new SelectList(db.Defendants, "Id", "LastName");
            ViewBag.IndemnitorId = new SelectList(db.Indemnitors, "Id", "FirstName");
            ViewBag.JailId = new SelectList(db.Jails, "Id", "Name");
            ViewBag.ProvidingAgencyId = new SelectList(db.ProvidingAgencies, "Id", "AgentName");
            ViewBag.RequestingAgencyId = new SelectList(db.RequestingAgencies, "Id", "AgencyName");
            return View();
        }

        // POST: Agreements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProvidingAgencyId,JailId,BondTransferId,RequestingAgencyId,DefendantId,IndemnitorId,AdditionalInformation")] Agreement agreement)
        {
            if (ModelState.IsValid)
            {
                db.Agreements.Add(agreement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BondTransferId = new SelectList(db.BondTransfers, "Id", "SerialNumber", agreement.BondTransferId);
            ViewBag.DefendantId = new SelectList(db.Defendants, "Id", "LastName", agreement.DefendantId);
            ViewBag.IndemnitorId = new SelectList(db.Indemnitors, "Id", "FirstName", agreement.IndemnitorId);
            ViewBag.JailId = new SelectList(db.Jails, "Id", "Name", agreement.JailId);
            ViewBag.ProvidingAgencyId = new SelectList(db.ProvidingAgencies, "Id", "AgentName", agreement.ProvidingAgencyId);
            ViewBag.RequestingAgencyId = new SelectList(db.RequestingAgencies, "Id", "AgencyName", agreement.RequestingAgencyId);
            return View(agreement);
        }

        // GET: Agreements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agreement agreement = db.Agreements.Find(id);
            if (agreement == null)
            {
                return HttpNotFound();
            }
            ViewBag.BondTransferId = new SelectList(db.BondTransfers, "Id", "SerialNumber", agreement.BondTransferId);
            ViewBag.DefendantId = new SelectList(db.Defendants, "Id", "LastName", agreement.DefendantId);
            ViewBag.IndemnitorId = new SelectList(db.Indemnitors, "Id", "FirstName", agreement.IndemnitorId);
            ViewBag.JailId = new SelectList(db.Jails, "Id", "Name", agreement.JailId);
            ViewBag.ProvidingAgencyId = new SelectList(db.ProvidingAgencies, "Id", "AgentName", agreement.ProvidingAgencyId);
            ViewBag.RequestingAgencyId = new SelectList(db.RequestingAgencies, "Id", "AgencyName", agreement.RequestingAgencyId);
            return View(agreement);
        }

        // POST: Agreements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProvidingAgencyId,JailId,BondTransferId,RequestingAgencyId,DefendantId,IndemnitorId,AdditionalInformation")] Agreement agreement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agreement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BondTransferId = new SelectList(db.BondTransfers, "Id", "SerialNumber", agreement.BondTransferId);
            ViewBag.DefendantId = new SelectList(db.Defendants, "Id", "LastName", agreement.DefendantId);
            ViewBag.IndemnitorId = new SelectList(db.Indemnitors, "Id", "FirstName", agreement.IndemnitorId);
            ViewBag.JailId = new SelectList(db.Jails, "Id", "Name", agreement.JailId);
            ViewBag.ProvidingAgencyId = new SelectList(db.ProvidingAgencies, "Id", "AgentName", agreement.ProvidingAgencyId);
            ViewBag.RequestingAgencyId = new SelectList(db.RequestingAgencies, "Id", "AgencyName", agreement.RequestingAgencyId);
            return View(agreement);
        }

        // GET: Agreements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agreement agreement = db.Agreements.Find(id);
            if (agreement == null)
            {
                return HttpNotFound();
            }
            return View(agreement);
        }

        // POST: Agreements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agreement agreement = db.Agreements.Find(id);
            db.Agreements.Remove(agreement);
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
