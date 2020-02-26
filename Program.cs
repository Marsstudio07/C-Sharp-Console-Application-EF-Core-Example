using EFCoreProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new SchoolContext())
            {
                //var green = context.players.
                //    Where<Player>(p=>p.name=="Green").
                //    FirstOrDefault();
                //context.players.Remove(green);
                //context.SaveChanges();

                //var Kobe = context.players.
                //    Where<Player>(p => p.name == "Kobe").
                //    First<Player>();
                //Kobe.name = "Kobe Bean Bryant";
                //context.SaveChanges();

                //Team team_lake = new Team()
                //{
                //    name = "lake",
                //    players = new List<Player>()
                //        {
                //            new Player(){ name="Kobe"},
                //            new Player(){ name="O`Neal"},
                //            new Player(){ name="Nash"}
                //        }
                //};
                //Team team_warrior = new Team()
                //{
                //    name = "warrior",
                //    players = new List<Player>
                //        {
                //            new Player(){name="Curry"},
                //            new Player(){name="Thompson"},
                //            new Player(){name="Green"}
                //        }
                //};
                //context.teams.Add(team_lake);
                //context.teams.Add(team_warrior);
                //context.SaveChanges();

                //with an eager loading by using Microsoft.EntityFrameworkCore.Include,it's not wise.
                //but we only use it to demonstrate this demo.
                var teams = context.teams.
                    Include(team=>team.players).
                    ToList();

                foreach(var team in teams)
                {
                    Console.WriteLine("team name:{0}", team.name);
                    foreach (var player in team.players)
                    {
                        Console.WriteLine("players name:{0}", player.name);
                    }
                }

            }
        }
    }
}
