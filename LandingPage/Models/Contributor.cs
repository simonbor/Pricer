using LandingPage.TierBll;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LandingPage.Models
{
    public class Contributor
    {
        public int ContributorId { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public DateTime DateStamp { get; set; } = DateTime.Now;
        public string Referer { get; set; }
        public Culture Culture { get; set; }
        public string Ip { get; set; }
        public string Language { get; set; }
        public string Browser { get; set; }
        public string Os { get; set; }
    }
}