using System.ComponentModel.DataAnnotations.Schema;

namespace LandingPage.Models
{
    public class Content
    {
        public int ContentId { get; set; }
        public int CultureId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public virtual Culture Culture { get; set; }
    }
}