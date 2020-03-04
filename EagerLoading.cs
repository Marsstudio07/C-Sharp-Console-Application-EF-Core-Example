using EFCoreProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreProject
{
    class EagerLoading
    {
        public async Task load() 
        {
            var team = await loadTeamsAsync();
            show(team);
        }

        public async Task<List<Team>> loadTeamsAsync()
        {
            using (var context = new SchoolContext()) {
                return await context.teams.
                    Include(team => (team as Team).Players).
                        ThenInclude(play => (play as Player).Addresses).
                    ToListAsync();
                
            };
        }
        public void show(List<Team> teams)
        {
            Console.WriteLine("result:");
            foreach (var team in teams)
            {
                Console.WriteLine("team :{0}", team.Name);
                foreach (var player in team.Players)
                {
                    Console.WriteLine("player :{0}", player.Name);
                    foreach (var address in player.Addresses)
                    {
                        Console.WriteLine("telephone:{0}, location:{1}", address.Telephone, address.Location);
                    }
                }
            }
        }
    }
}
