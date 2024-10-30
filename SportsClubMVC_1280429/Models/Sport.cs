using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsClubMVC_1280429.Models
{
    public partial class Sport
    {
        public Sport()
        {
            this.SportsEntries = new List<SportsEntry>();
        }
        [Key]
        public int SportsId { get; set; }
        [Required,StringLength(50),Display(Name ="Sports Name")]
        public string SportsTitle { get; set; }
        public virtual ICollection<SportsEntry> SportsEntries { get; set; }
    }
}