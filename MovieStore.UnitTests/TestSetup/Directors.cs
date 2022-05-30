using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStore.UnitTests.TestSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDbContext context)
        {
             context.AddRange(
                new Director{FirstName = "Linus",LastName = "Potts"},
	            new Director{FirstName = "Armando",LastName = "Ellis"},
	            new Director{FirstName = "Kyra",LastName = "Francis"},
	            new Director{FirstName = "Yasir",LastName = "Love"},
	            new Director{FirstName = "Shoshana",LastName = "Garner"}
             );
        }
    }
}