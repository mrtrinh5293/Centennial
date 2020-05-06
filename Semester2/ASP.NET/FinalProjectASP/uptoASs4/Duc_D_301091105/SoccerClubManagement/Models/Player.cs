using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClubManagement.Models
{
    public class Player
    {
        //public ICollection<PlayerList> pList { get; set; }
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public int PlayerAge { get; set; }
        public int PlayerWeight { get; set; }
        public int PlayerHeight { get; set; }
        public int ClubID { set; get; }
    }
}
