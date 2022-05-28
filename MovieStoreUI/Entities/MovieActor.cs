using Microsoft.EntityFrameworkCore;

namespace MovieStoreUI.Entities
{
     [Keyless]
    public class MovieActor
    {
        public int ID { get; set; }
        public int MovieId { get; set; }
        
        public int ActorId { get; set; }
        
        public Movie Movie { get; set; }
        
        public Actor Actor { get; set; }
        
        
    }
}