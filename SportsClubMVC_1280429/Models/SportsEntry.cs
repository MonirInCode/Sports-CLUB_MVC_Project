using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SportsClubMVC_1280429.Models
{
    public partial class SportsEntry
    {
        [Key]
        public int SportsEntriesId { get; set; }
        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        [ForeignKey("Sport")]
        public int SportsId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Sport Sport { get; set; }
    }
}