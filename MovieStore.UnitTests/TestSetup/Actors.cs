using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStore.UnitTests.TestSetup
{
    public static class Actors
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
            context.AddRange(
                new Actor{ FirstName = "Alexander",LastName = "Pittman"},
	            new Actor{FirstName = "Laurel",LastName = "Hines"},
	            new Actor{FirstName = "Nyssa",LastName = "Long"},
	            new Actor{FirstName = "Hanae",LastName = "Guzman"},
	            new Actor{FirstName = "Keegan",LastName = "Lara"}
            );
        }
    }
}