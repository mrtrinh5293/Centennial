using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerClubManagement.Models;
using SoccerClubManagement.Models.ViewModels;


namespace SoccerClubManagement.Controllers
{
    public class HomeController : Controller
    {
        IClubRepository repository;
        public HomeController(IClubRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View();
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
    }
}
