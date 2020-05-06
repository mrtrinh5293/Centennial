using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SoccerClubManagement.Models
{
    public class Club
    {
        //[Key]
        public int ClubID { get; set; }
        [Required(ErrorMessage = "Please enter Club Name")]
        public string ClubName { get; set; }
        [Required(ErrorMessage = "Please enter Club Email")]
        public string ClubEmail { get; set; }
        [Required(ErrorMessage = "Please enter Contact Number")]
        public string ClubPhoneNumber { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}
