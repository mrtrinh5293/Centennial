using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerClubManagement.Models;
using Microsoft.AspNetCore.Authorization;
using SoccerClubManagement.Models.ViewModels;

namespace SoccerClubManagement.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IClubRepository repository;
        public AdminController(IClubRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("ClubDetailsViews", repository.Clubs.OrderBy(c => c.ClubID));
        }
        public IActionResult ClubListViews(int clubID)
        {
            if (ModelState.IsValid)
            {
                return View("ClubDetailsViews", repository.Clubs.Where(c => c.ClubID == clubID));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult ClubDetailsViews(int clubID)
        {

            if (clubID == 0)
            {
                return View("ClubDetailsViews", repository.Clubs);
            }
            else
            {
                return View("ClubDetailsViews", repository.Clubs.Where(c => c.ClubID == clubID));
            }

        }
        public ViewResult AddClubViews()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddClubViews(Club club)
        {
            repository.SaveClub(club);
            return View("ClubDetailsViews", repository.Clubs.OrderBy(c => c.ClubName));
        }
        public ViewResult UpdateViews(int clubId) =>
             View(repository.Clubs
             .FirstOrDefault(c => c.ClubID == clubId));

        [HttpPost]
        public IActionResult UpdateViews(Club club)
        {
            if (ModelState.IsValid)
            {
                repository.SaveClub(club);
                TempData["message"] = $"{club.ClubName} updated information has been saved";
                return RedirectToAction("ClubDetailsViews");
            }
            else
            {
                // there is something wrong with the data values
                return View(club);
            }
        }

        [HttpPost]
        public IActionResult DeleteClub(int clubID)
        {
            Club deletedClub = repository.DeleteClub(clubID);
            if (deletedClub != null)
            {
                TempData["message"] = $"{deletedClub.ClubName} was deleted";
            }
            return RedirectToAction("ClubDetailsViews");
        }

        [HttpGet]
        public ViewResult PlayerManagement(int playerID, int clubID)
        {
            List<Club> clubList = new List<Club> { new Club { ClubID = 0, ClubName = "Select..." } };
            clubList.AddRange(repository.Clubs);
            ViewBag.ListOfClubs = clubList;

            if (playerID == 0)
            {
                Player player = new Player { ClubID = clubID };
                return View("PlayerManagement", player);
            }
            else
            {
                return View("PlayerManagement", repository.GetPlayer(playerID));
            }
        }

        [HttpPost]
        public IActionResult PlayerManagement(Player player)
        {
            List<Club> clubList = new List<Club> { new Club { ClubID = 0, ClubName = "Select..." } };
            clubList.AddRange(repository.Clubs);
            ViewBag.ListOfClubs = clubList;

            if (ModelState.IsValid)
            {
                repository.SavePlayer(player);
                TempData["message"] = $"{player.PlayerName} has been saved";
                return RedirectToAction("ClubDetailsViews", repository.Clubs.FirstOrDefault(c => c.ClubID == player.ClubID));
            }
            else
            {
                return View("ClubDetailsViews", repository.Clubs.FirstOrDefault(c => c.ClubID == player.ClubID));
            }
        }
        [HttpGet]
        public IActionResult EditPlayers(int playerID, int clubID)
        {
            List<Club> clubList = new List<Club> { new Club { ClubID = 0, ClubName = "Select..." } };
            clubList.AddRange(repository.Clubs);
            ViewBag.ListOfClubs = clubList;

            if (playerID == 0)
            {
                Player player = new Player { ClubID = clubID };
                return View("PlayerManagement", player);

            }
            else
            {
                return View("PlayerManagement", repository.GetPlayer(playerID));
            }
        }

        [HttpPost]
        public IActionResult EditPlayers(Player player)
        {
            List<Club> clubList = new List<Club> { new Club { ClubID = 0, ClubName = "Select..." } };
            clubList.AddRange(repository.Clubs);
            ViewBag.ListOfClubs = clubList;

            if (ModelState.IsValid)
            {
                repository.SavePlayer(player);
                TempData["message"] = $"{player.PlayerName} has been saved";
                return RedirectToAction("ClubDetailsViews", repository.Clubs.FirstOrDefault(c => c.ClubID == player.ClubID));
            }
            else
            {
                return View("ClubDetailsViews", repository.Clubs.FirstOrDefault(c => c.ClubID == player.ClubID));
            }
        }
        public IActionResult DeletePlayer(int PlayerId)
        {
            Player deletedPlayer = repository.DeletePlayer(PlayerId);
            if (deletedPlayer != null)
            {
                TempData["message"] = $"{deletedPlayer.PlayerName} was deleted";
            }
            return RedirectToAction("ClubDetailsViews", repository.Clubs.Where(c => c.ClubID == deletedPlayer.ClubID));
        }
    }
}

