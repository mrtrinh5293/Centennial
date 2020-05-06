using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClubManagement.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Clubs.Any())
            {
                context.Clubs.AddRange(
                new Club
                {
                    ClubName = "FC Barcelona",
                    ClubEmail = "Barcelona@email.com",
                    ClubPhoneNumber = "1234566789",
                    Players = new List<Player>
                    {
                        new Player
                    {
                        PlayerName = "Ronaldo",
                        PlayerAge = 21,
                        PlayerHeight = 180,
                        PlayerWeight = 80
                    }, new Player
                    {
                        PlayerName = "Messi",
                        PlayerAge = 20,
                        PlayerHeight = 180,
                        PlayerWeight = 80
                    }
                    }
                },
                new Club
                {
                    ClubName = "Real Madrid C.F.",
                    ClubEmail = "Barcelona@email.com",
                    ClubPhoneNumber = "1234566789",
                    Players = new List<Player>
                    {
                        new Player
                    {
                        PlayerName = "Neymar",
                        PlayerAge = 21,
                        PlayerHeight = 180,
                        PlayerWeight = 80
                    }, new Player
                    {
                        PlayerName = "Rooney",
                        PlayerAge = 20,
                        PlayerHeight = 180,
                        PlayerWeight = 80
                    }
                    }
                }, 
                new Club
                {
                    ClubName = "FC Bayern Munich",
                    ClubEmail = "Bayermunich@email.com",
                    ClubPhoneNumber = "1234566789",
                    Players = new List<Player>
                    {
                        new Player
                    {
                        PlayerName = "Zidane",
                        PlayerAge = 21,
                        PlayerHeight = 180,
                        PlayerWeight = 80
                    }, new Player
                    {
                        PlayerName = "Messi",
                        PlayerAge = 20,
                        PlayerHeight = 180,
                        PlayerWeight = 80
                    }
                    }
                }, 
                new Club
                {
                    ClubName = "Juventus F.C.",
                    ClubEmail = "Juventus@email.com",
                    ClubPhoneNumber = "1234566789",
                }, 
                new Club
                {
                    ClubName = "Manchester City F.C.",
                    ClubEmail = "Manchestercity@email.com",
                    ClubPhoneNumber = "1234566789",
                }, 
                new Club
                {
                    ClubName = "Manchester United F.C.",
                    ClubEmail = "Manchesterunited@email.com",
                    ClubPhoneNumber = "1234566789",
                }, 
                new Club
                {
                    ClubName = "Atlético Madrid",
                    ClubEmail = "Atleticomadrid@email.com",
                    ClubPhoneNumber = "1234566789",
                }, 
                new Club
                {
                    ClubName = "Chelsea F.C.",
                    ClubEmail = "Chelseafc@email.com",
                    ClubPhoneNumber = "1234566789",
                }
                );
                context.SaveChanges();
            }

            //    if (!context.Players.Any())
            //    {
            //        context.Players.AddRange(
            //        new Player
            //        {
            //            PlayerName = "Ronaldo",
            //            PlayerAge = 21,
            //            PlayerHeight = 180,
            //            PlayerWeight = 80
            //        }, new Player
            //        {
            //            PlayerName = "Messi",
            //            PlayerAge = 20,
            //            PlayerHeight = 180,
            //            PlayerWeight = 80
            //        }, new Player
            //        {
            //            PlayerName = "Neymar",
            //            PlayerAge = 20,
            //            PlayerHeight = 180,
            //            PlayerWeight = 80
            //        }, new Player
            //        {
            //            PlayerName = "Rooney",
            //            PlayerAge = 20,
            //            PlayerHeight = 180,
            //            PlayerWeight = 80
            //        }, new Player
            //        {
            //            PlayerName = "Ibrahimovic",
            //            PlayerAge = 20,
            //            PlayerHeight = 180,
            //            PlayerWeight = 80
            //        }, new Player
            //        {
            //            PlayerName = "Zidane",
            //            PlayerAge = 20,
            //            PlayerHeight = 180,
            //            PlayerWeight = 80
            //        }
            //        );
            //        context.SaveChanges();
            //    }
        }
    }
}
