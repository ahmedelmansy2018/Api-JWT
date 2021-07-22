using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Jwt.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> Options):base(Options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(new Country
            { 
            CountryId=1,
            Name="Cario"
            });
            modelBuilder.Entity<Country>().HasData(new Country
            {
                CountryId = 2,
                Name = "Alex"
            });
            modelBuilder.Entity<Country>().HasData(new Country
            {
                CountryId = 3,
                Name = "Mansoura"
            });
            modelBuilder.Entity<Country>().HasData(new Country
            {
                CountryId = 4,
                Name = "Aswan"
            });
        }
    }
}
