using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsClubMVC_1280429.Models.ViewModels
{
    public class SportsViewModel
    {
        public SportsViewModel()
        {
            this.SportsList = new List<int>();
        }
        [Key]
        public int PlayerId { get; set; }
        [Required, StringLength(30), Display(Name = "Player Name")]
        public string PlayerName { get; set; }
        [Required, Display(Name = "Date Of Birth"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Picture { get; set; }
        public bool Status { get; set; }
        public int Salary { get; set; }
        public HttpPostedFileBase PicturePath { get; set; }
        public List<int> SportsList { get; set; }
    }
}