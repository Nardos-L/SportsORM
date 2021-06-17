using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            //
            ViewBag.Allwomens = _context.Leagues
                .Where(l => l.Name.Contains("Womens"))
                .ToList();
            

            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();

            ViewBag.FootballLeagues = _context.Leagues
                .Where(l => !l.Name.Contains("Football"))
                .ToList();

            ViewBag.ConferenceLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();

            ViewBag.Atlanticregion = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();

            ViewBag.DallasTeams = _context.Teams
                .Where(l => l.Location.Contains("Dallas"))
                .ToList();

            ViewBag.RaptorTeams = _context.Teams
                .Where(l => l.TeamName.Contains("Raptors"))
                .ToList();

            ViewBag.CityTeams = _context.Teams
                .Where(l => l.Location.Contains("City"))
                .ToList();

            ViewBag.NamesTeams = _context.Teams
                .Where(l => l.TeamName.StartsWith("T"))
                .ToList();

            ViewBag.LocationTeams = _context.Teams.OrderBy(l => l.Location)
                .ToList();
            
            ViewBag.ReverseTeams = _context.Teams.OrderByDescending(l => l.TeamName)
                .ToList(); 

            ViewBag.LastNameTeams = _context.Players
                .Where(l => l.LastName.Equals("Cooper"))
                .ToList();
            
            ViewBag.FirstNameTeams = _context.Players
                .Where(l => l.FirstName.Equals("Joshua"))
                .ToList();

            ViewBag.ExceptPlayers = _context.Players
                 .Where(l => l.LastName.Equals("Cooper") && l.FirstName !=("Joshua"))
                .ToList();

            ViewBag.AllPlayers = _context.Players
                .Where(l => l.FirstName.Equals("Alexander") || l.FirstName.Equals("Wyatt"))
                .ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}