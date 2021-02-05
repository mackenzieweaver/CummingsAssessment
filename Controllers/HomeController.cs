using CummingsAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CummingsAssessment.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Agreement()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Agreement(AgreementViewModel model)
        {
            db.ProvidingAgencies.Add(model.ProvidingAgency);
            db.Jails.Add(model.Jail);
            db.BondTransfers.Add(model.BondTransfer);
            db.RequestingAgencies.Add(model.RequestingAgency);
            db.Defendants.Add(model.Defendant);
            db.Indemnitors.Add(model.Indemnitor);
            await db.SaveChangesAsync();

            db.Agreements.Add(new Agreement
            {
                ProvidingAgencyId = model.ProvidingAgency.Id,
                JailId = model.Jail.Id,
                BondTransferId = model.BondTransfer.Id,
                RequestingAgencyId = model.RequestingAgency.Id,
                DefendantId = model.Defendant.Id,
                IndemnitorId = model.Indemnitor.Id,
                AdditionalInformation = model.AdditionalInformation
            });
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Agreement));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}