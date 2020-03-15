using EFCoreProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject
{
    class ExplicitLoading
    {
        internal async Task load()
        {
            var team = await loadTeamsAsync();
            show(team);
        }
        public async Task<Team> loadTeamsAsync()
        {
            using (var context = new SchoolContext())
            {

                var lake_team =  await context.teams.Where(t => t.Name == "lake").FirstOrDefaultAsync();

                //The lake.Players is a collection navigation property, which using the Collection method.
                await context.Entry(lake_team).Collection(lake => lake.Players).
                    Query().
                    Where(p=>p.Name== "Kobe Bean Bryant").
                    LoadAsync();

                //load collection navigation property Address for each player 
                foreach (Player player in lake_team.Players) {
                    await context.Entry(player).Collection(p => p.Addresses).LoadAsync();
                }
                return lake_team;
            };
        }
        public void show(Team team)
        {
            Console.WriteLine("team name:{0}",team.Name);
            foreach (var play in team.Players) {
                Console.WriteLine("player name:{0}",play.Name);

                foreach (var address in play.Addresses) {
                    Console.WriteLine(address.Location);
                }
            }

        }
    }
}
