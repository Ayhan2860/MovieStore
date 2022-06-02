using System;
using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStore.UnitTests.TestSetup
{
    public static class Movies
    {
        public static void AddMovies(this MovieStoreDbContext context)
        {
            context.AddRange(
                new Movie{ Title = "Tattoo", ReleaseDate = new DateTime(2012), Price = 12.99, GenreId =5, DirectorId =1 },
                new Movie{ Title = "Little Darlings", ReleaseDate = new DateTime(12015), Price = 15.59, GenreId =1, DirectorId=1 },
                new Movie{ Title = "Beaufort", ReleaseDate = new DateTime(2019), Price = 22.79, GenreId =3, DirectorId =3 },
                new Movie{ Title = "Nana", ReleaseDate = new DateTime(2017), Price = 14.99, GenreId =2, DirectorId = 2 }
            
            );
        }
    }
}