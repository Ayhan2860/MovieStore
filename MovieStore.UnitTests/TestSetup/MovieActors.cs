using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStore.UnitTests.TestSetup
{
    public static class MovieActors
    {
        public static void AddMovieActors(this MovieStoreDbContext context)
        {
            context.AddRange(
                new MovieActor {ActorId = 2, MovieId = 2},
                new MovieActor {ActorId = 1, MovieId = 2},
                new MovieActor {ActorId = 3, MovieId = 4},
                new MovieActor {ActorId = 5, MovieId = 3},
                new MovieActor {ActorId = 1, MovieId = 5}
            );
        }
    }
}