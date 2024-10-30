using SportsClubMVC_1280429.Models.ViewModels;
using SportsClubMVC_1280429.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SportsClubMVC_1280429.Controllers
{
    public class PlayerController : Controller
    {
        private AppDBContext db = new AppDBContext();
        public ActionResult Index()
        {
            var players = db.Players.Include(c => c.SportsEntries.Select(b => b.Sport)).OrderByDescending(x => x.PlayerId).ToList();
            return View(players);
        }
        public ActionResult AddNewSports(int? id)
        {
            ViewBag.sports = new SelectList(db.Sports.ToList(), "SportsId", "SportsTitle", (id != null) ? id.ToString() : "");
            return PartialView("_AddNewSports");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SportsViewModel sportsViewModel, int[] SportsId)
        {
            if (ModelState.IsValid)
            {
                Player player = new Player()
                {
                    PlayerName = sportsViewModel.PlayerName,
                    DateOfBirth = sportsViewModel.DateOfBirth,
                    Age = sportsViewModel.Age,
                    Salary=sportsViewModel.Salary,
                    Status = sportsViewModel.Status
                };
                HttpPostedFileBase file = sportsViewModel.PicturePath;
                if (file != null)
                {
                    string fileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine("/Images", fileName);
                    file.SaveAs(Server.MapPath(filePath));
                    player.Picture = filePath;
                }
                foreach (var item in SportsId)
                {
                    SportsEntry sportsEntry = new SportsEntry()
                    {
                        Player = player,
                        PlayerId = player.PlayerId,
                        SportsId = item
                    };
                    db.SportsEntries.Add(sportsEntry);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? id)
        {
            Player player = db.Players.First(x => x.PlayerId == id);
            var playerSports = db.SportsEntries.Where(x => x.PlayerId == id).ToList();
            SportsViewModel sportsViewModel = new SportsViewModel()
            {
                PlayerId = player.PlayerId,
                PlayerName = player.PlayerName,
                Age = player.Age,
                DateOfBirth = player.DateOfBirth,
                Salary=player.Salary,
                Picture = player.Picture,
                Status = player.Status
            };
            if (playerSports.Count() > 0)
            {
                foreach (var item in playerSports)
                {
                    sportsViewModel.SportsList.Add(item.SportsId);
                }
            }
            return View(sportsViewModel);
        }
        [HttpPost]
        public ActionResult Edit(SportsViewModel sportsViewModel, int[] SportsId)
        {
            if (ModelState.IsValid)
            {
                Player player = new Player()
                {
                    PlayerId = sportsViewModel.PlayerId,
                    PlayerName = sportsViewModel.PlayerName,
                    DateOfBirth = sportsViewModel.DateOfBirth,
                    Age = sportsViewModel.Age,
                    Salary=sportsViewModel.Salary,
                    Status = sportsViewModel.Status
                };
                HttpPostedFileBase file = sportsViewModel.PicturePath;
                if (file != null)
                {
                    string fileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(file.FileName);
                    string filePath = Path.Combine("/Images", fileName);
                    file.SaveAs(Server.MapPath(filePath));
                    player.Picture = filePath;
                }
                else
                {
                    player.Picture = sportsViewModel.Picture;
                }
                var existsSportsEntry = db.SportsEntries.Where(x => x.PlayerId == player.PlayerId).ToList();
                foreach (var sportsEntry in existsSportsEntry)
                {
                    db.SportsEntries.Remove(sportsEntry);
                }
                foreach (var item in SportsId)
                {
                    SportsEntry sportsEntry = new SportsEntry()
                    {
                        Player = player,
                        PlayerId = player.PlayerId,
                        SportsId = item
                    };
                    db.SportsEntries.Add(sportsEntry);
                }
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int? id)
        {
            var player = db.Players.Find(id);
            var existsSportsEntry = db.SportsEntries.Where(x => x.PlayerId == player.PlayerId).ToList();
            foreach (var sportsEntry in existsSportsEntry)
            {
                db.SportsEntries.Remove(sportsEntry);
            }
            db.Entry(player).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PlayerList(string sortOrder,string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var player = from p in db.Players select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                player = player.Where(p => p.PlayerName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    player = player.OrderByDescending(p => p.PlayerName);
                        break;
                case "Date":
                    player = player.OrderBy(p => p.DateOfBirth);
                    break;
                case "date_desc":
                    player = player.OrderByDescending(p => p.DateOfBirth);
                    break;
                default:
                    player = player.OrderBy(p => p.PlayerName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(player.ToPagedList(pageNumber,pageSize));
        }
    }
}