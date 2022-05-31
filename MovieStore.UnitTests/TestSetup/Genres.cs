using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStore.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this MovieStoreDbContext context)
        {
             context.AddRange(
                new Genre{Name = "Drama"},
                new Genre{Name = "Comedy"},
                new Genre{Name = "Action"},
                new Genre{Name = "Animation"},
                new Genre{Name = "Romance"}
             );
        }
    }
}