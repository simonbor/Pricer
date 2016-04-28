using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LandingPage.Models
{
    public class ContributorViewModel
    {
        public Contributor Contributor { get; set; }
        public IQueryable<Content> Content { get; set; }
    }
}