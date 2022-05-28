using System.Collections.Generic;

namespace MovieStoreUI.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<CustomerFavoritGenre> CustomerFavoritGenres { get; set; }
    }
}