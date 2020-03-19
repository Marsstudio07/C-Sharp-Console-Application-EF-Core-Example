using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            //use lazyLoadingProxies to enable lazy loading
            optionsBuilder.
                UseLazyLoadingProxies().
                UseSqlServer("Server=.;Database=SchoolDb;Trusted_Connection=True;");
        }
    }
    //entity class Team
    public class Team
    {
        [Key]
        [Required]
        public int Id { set; get; }

        [Required(ErrorMessage = "name is required")]
        [MaxLength(20,ErrorMessage = "name is too long")]
        public string Name { set; get; }

        public virtual List<Player> Players { set; get; }
    }
    //entity class Player
    public class Player 
    {
        [Key]
        [Required]
        public int Id { set; get; }

        [Required(ErrorMessage = "name is required")]
        [MaxLength(20, ErrorMessage = "name is too long")]
        public string Name { set; get; }

        public virtual List<HomeAddress> Addresses { set; get; }
    }
    public class HomeAddress 
    { 
        [Key]
        [Required]
        public int Id { set; get; }

        [MaxLength(15, ErrorMessage = "telephone is too long")]
        public string Telephone { set; get; }

        [MaxLength(20, ErrorMessage = "location is too long")]
        public string Location { set; get; }
    }
}
