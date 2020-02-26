using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreProject.Model
{
    //context class SchoolContext
    class SchoolContext : DbContext
    {
        public DbSet<Team> teams { set; get; }
        public DbSet<Player> players { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SchoolDb;Trusted_Connection=True;");
        }
    }
    //entity class Team
    public class Team
    {
        [Key]
        [Required]
        public int id { set; get; }

        [Required(ErrorMessage = "name is required")]
        [MaxLength(20,ErrorMessage = "name is too long")]
        public string name { set; get; }

        public List<Player> players { set; get; }
    }
    //entity class Player
    public class Player 
    {
        [Key]
        [Required]
        public int id { set; get; }

        [Required(ErrorMessage = "name is required")]
        [MaxLength(20, ErrorMessage = "name is too long")]
        public string name { set; get; }

    }
}
