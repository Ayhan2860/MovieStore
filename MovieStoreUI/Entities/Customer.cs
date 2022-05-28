using System;
using System.Collections.Generic;

namespace MovieStoreUI.Entities
{
    public class Customer:Person
    {
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }

        public ICollection<Order> OrderMovies { get; set; }

        public ICollection<CustomerFavoritGenre> CustomerFavoritGenres { get; set; }
     }
}