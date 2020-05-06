using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClubManagement.Models
{
    public interface IClubRepository
    {
        IEnumerable<Club> Clubs { get; }
        void SaveClub(Club club);
        Club DeleteClub(int clubID);
        IEnumerable<Player> clubPlayers(int clubID);
        Player GetPlayer(int playerID);
        void SavePlayer(Player Player);
        Player DeletePlayer(int playerID);
        string GetClubName(int clubID);
    }
}
