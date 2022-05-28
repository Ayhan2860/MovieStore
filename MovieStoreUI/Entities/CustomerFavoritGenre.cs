using Microsoft.EntityFrameworkCore;

namespace MovieStoreUI.Entities
{
    [Keyless]
    public class CustomerFavoritGenre
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}