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
    public class BondTransfersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BondTransfers
        public ActionResult Index()
        {
            return View(db.BondTransfers.ToList());
        }

        // GET: BondTransfers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BondTransfer bondTransfer = db.BondTransfers.Find(id);
            if (bondTransfer == null)
            {
                return HttpNotFound();
            }
            return View(bondTransfer);
        }

        // GET: BondTransfers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BondTransfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Amount,SerialNumber")] BondTransfer bondTransfer)
        {
            if (ModelState.IsValid)
            {
                db.BondTransfers.Add(bondTransfer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bondTransfer);
        }

        // GET: BondTransfers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BondTransfer bondTransfer = db.BondTransfers.Find(id);
            if (bondTransfer == null)
            {
                return HttpNotFound();
            }
            return View(bondTransfer);
        }

        // POST: BondTransfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Amount,SerialNumber")] BondTransfer bondTransfer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bondTransfer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bondTransfer);
        }

        // GET: BondTransfers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BondTransfer bondTransfer = db.BondTransfers.Find(id);
            if (bondTransfer == null)
            {
                return HttpNotFound();
            }
            return View(bondTransfer);
        }

        // POST: BondTransfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BondTransfer bondTransfer = db.BondTransfers.Find(id);
            db.BondTransfers.Remove(bondTransfer);
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
