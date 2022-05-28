using System.Collections.Generic;

namespace MovieStoreUI.Entities
{
     public class Actor:Person
    {
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}