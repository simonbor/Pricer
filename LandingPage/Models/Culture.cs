using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LandingPage.Models
{
    public class Culture
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CultureId { get; set; }
        [StringLength(5)]
        public string CultureName { get; set; }
        public string CultureTitle { get; set; }
    }
}