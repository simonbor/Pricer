using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LandingPage.TierDal;
using LandingPage.Models;
using LandingPage.TierBll;

namespace LandingPage.Controllers
{
    public class ContributorController : Controller
    {
        private readonly LpContext _db = new LpContext();
        IContributorSubmitter contributorSubmitter;
        private const string DEF_CULTURE = "en-us";

        public ContributorController()
        {
            contributorSubmitter = new EmailContributorSubmitter(_db.Owners.Select(i => i.Email).ToList());
        }

        public ActionResult Index(string cultureName = DEF_CULTURE)
        {
            // cultureName input validation
            if (_db.Cultures.Count(r => r.CultureName == cultureName) < 1)
                cultureName = DEF_CULTURE;            

            var contents = _db.GetContent(cultureName, HttpContext.Cache);
            var contributorViewModel = new ContributorViewModel {Content = contents};

            return View(contributorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Email")] Contributor contributor)
        {
            contributor.Ip = Request.UserHostAddress;
            contributor.Browser = Request.Browser.Type;
            contributor.Os = Request.Browser.Platform;
            contributor.Language = Request.UserLanguages != null ? Request.UserLanguages.First() : DEF_CULTURE;
            contributor.Referer = Request.ServerVariables["HTTP_REFERER"];

            var contents = _db.GetContent(contributor.Language, HttpContext.Cache);
            var contributorViewModel = new ContributorViewModel { Contributor = contributor, Content = contents};

            // register the new contributor
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Contributors.Add(contributorViewModel.Contributor);
                    _db.SaveChanges();
                    contributorSubmitter.SubmitOrder(contributor, _db.Contributors.ToList());
                }
                catch {}
            }

            return View("Thanks", contributorViewModel);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
