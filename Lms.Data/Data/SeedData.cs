using Lms.Core.Enteties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.FakeDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lms.Data.Data
{
   
    public class SeedData
    {
        private static LmsApiContext db = default!;

        public static async Task InitAsync(LmsApiContext context)
        {
            if (context is null) throw new ArgumentNullException(nameof(context));

            db = context;

            if (await db.Tournament.AnyAsync()) return;

            var tournament1 = GetTournament(1);
            var tournament2 = GetTournament(2);
            var tournament3 = GetTournament(3);

            await db.AddAsync(tournament1);
            await db.AddAsync(tournament2);
            await db.AddAsync(tournament3);

            await db.SaveChangesAsync();

            //var gymClasses = GetGymClasses(20);
            //await db.AddRangeAsync(gymClasses);
            
            //var tournamentClasses = GetTournament(5);
            //object value = await Db.AddRangeAsync(tournamentClasses);

        }

      
        public static Tournament GetTournament(int n)
        {
            return new Tournament
            {
                Title = $"Tournament {n}",
                StartDate = DateTime.Now,
                Games = new List<Game>
                {
                    new Game { Title = "Game 1" },
                    new Game { Title = "Game 2" },
                    new Game { Title = "Game 3" },
                    new Game { Title = "Game 4" },
                    new Game { Title = "Game 5" },
                }
            };
        }

        //ModelBuilder.Entity<Tournament>()
        //    .HasData(new Tournament { GameId = 1, Name = "Game1",  });
    }
}
