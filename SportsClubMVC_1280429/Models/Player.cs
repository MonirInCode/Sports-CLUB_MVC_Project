using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsClubMVC_1280429.Models
{
    public partial class Player
    {
        public Player()
        {
            this.SportsEntries = new List<SportsEntry>();
        }
        [Key]
        public int PlayerId { get; set; }
        [Required,StringLength(30),Display(Name ="Player Name")]
        public string PlayerName { get; set; }
        [Required,Display(Name ="Date Of Birth"),DataType(DataType.Date),DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Picture { get; set; }
        public bool Status { get; set; }
        public int Salary { get; set; }
        public ICollection<SportsEntry> SportsEntries { get; set; }
    }
}