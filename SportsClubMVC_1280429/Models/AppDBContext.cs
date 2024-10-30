using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SportsClubMVC_1280429.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext() : base("AppDBContext")
        {}
        public DbSet<Player> Players { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<SportsEntry> SportsEntries { get; set; }
    }
}