using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "T-34",
                        ReleaseDate = DateTime.Parse("2019-02-20"),
                        Genre = "Action",
                        Rating = "R",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Satellite",
                        ReleaseDate = DateTime.Parse("2020-08-14"),
                        Genre = "Drama Fantasy",
                        Rating = "R",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "The Gentlemen",
                        ReleaseDate = DateTime.Parse("2020-01-24"),
                        Genre = "Comedy",
                        Rating = "R",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Ice 2",
                        ReleaseDate = DateTime.Parse("2020-02-14"),
                        Genre = "Romance",
                        Rating = "R",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}