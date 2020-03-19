using EFCoreProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject
{
    class LazyLoading
    {
        internal void load()
        {
            using (var context = new SchoolContext())
            {
                //the lake has a Players navigation property
                var lake = context.teams.FirstOrDefault();

                // Players navigation property load
                var player = lake.Players.FirstOrDefault();

                //Addresses navigation property load
                var address = player.Addresses;
            }

        }
    }
}
