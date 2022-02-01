using Microsoft.EntityFrameworkCore;
using Mission5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieContext : DbContext
    {
        // Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            // leave blank for now
        }

        public DbSet<ApplicationResponse> responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Seed data


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category { CategoryID = 1, CategoryName="Action"},
                    new Category { CategoryID = 2, CategoryName = "American Sports Drama" },
                    new Category { CategoryID = 3, CategoryName = "Romance" },
                    new Category { CategoryID = 4, CategoryName = "Comedy" },
                    new Category { CategoryID = 5, CategoryName = "Horror" }
                );


            mb.Entity<ApplicationResponse>().HasData(
                    new ApplicationResponse
                    {
                        ApplicationId = 1,
                        CategoryID = 1,
                        Title = "Star Wars Revenge of the Sith",
                        Year = 2005,
                        Director = "George Lucas",
                        Rating = "PG-13",
                        Edited = true,
                        LentTo = "Mitch",
                        Notes = "Solid Movie"
                    },
                    new ApplicationResponse
                    {
                        ApplicationId = 2,
                        CategoryID = 1,
                        Title = "Star Wars Return of the Jedi",
                        Year = 1983,
                        Director = "Richard Marquand",
                        Rating = "PG",
                        Edited = true,
                        LentTo = "Max",
                        Notes = "A Classic"
                    },
                    new ApplicationResponse
                    {
                        ApplicationId = 3,
                        CategoryID = 2,
                        Title = "Rocky",
                        Year = 1976,
                        Director = "John G. Avildsen",
                        Rating = "PG",
                        Edited = false,
                        LentTo = "Glenn",
                        Notes = "The greatest"
                    }
                );
        }
    }
}
