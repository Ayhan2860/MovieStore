using System;
using System.Collections.Generic;
using System.Linq;
using MovieStoreUI.Entities;

namespace MovieStoreUI.DbOperations
{
    public static class MovieStoreDatas
    {
        public static List<Actor> _actors;
        public static List<Director> _directors;
        public static List<Genre> _genries;
        public static List<Movie> _movies;
        public static List<MovieActor> _movieActors;
        public static List<Customer> _customers;
        public static List<Order> _orders;
        public static List<CustomerFavoritGenre> _favoritGenres;
        private static byte[] PasswordHash = {109, 113, 161, 170, 96, 205, 218, 192, 159, 108, 97, 196, 210, 33, 87, 101, 10, 191, 99, 186, 38, 231, 145, 137, 2,
        13, 66, 224, 22, 181, 69, 14, 66, 31, 158, 38, 133, 113, 140, 16, 243, 92, 160, 218, 118, 101, 129, 7, 88, 222, 84, 69, 229, 120, 218, 158, 214, 95, 131, 136, 114, 219, 208, 108};
        private static byte[] PasswordSalt = {147, 148, 186,  167, 85, 41, 233, 209, 34, 36, 44, 183, 197, 13, 243, 112, 212, 156, 241, 114, 4, 82, 95, 144, 164};

        
        static MovieStoreDatas()
        {
             _actors = new List<Actor>
            {
                new  Actor{ FirstName = "Alexander",LastName = "Pittman"},
	            new Actor{FirstName = "Laurel",LastName = "Hines"},
	            new Actor{FirstName = "Nyssa",LastName = "Long"},
	            new Actor{FirstName = "Hanae",LastName = "Guzman"},
	            new Actor{FirstName = "Keegan",LastName = "Lara"}
            };
            _directors = new List<Director>
            {
                new Director{FirstName = "Linus",LastName = "Potts"},
	            new Director{FirstName = "Armando",LastName = "Ellis"},
	            new Director{FirstName = "Kyra",LastName = "Francis"},
	            new Director{FirstName = "Yasir",LastName = "Love"},
	            new Director{FirstName = "Shoshana",LastName = "Garner"}
            };
            _genries = new List<Genre>
            {
                new Genre{Name = "Drama"},
                new Genre{Name = "Comedy"},
                new Genre{Name = "Action"},
                new Genre{Name = "Animation"},
                new Genre{Name = "Romance"}

            };
            _movies = new List<Movie>
            {
                new Movie{ Title = "Tattoo", ReleaseDate = new DateTime(2012), Price = 12.99, GenreId =5, DirectorId =1 },
                new Movie{ Title = "Little Darlings", ReleaseDate = new DateTime(12015), Price = 15.59, GenreId =1, DirectorId=1 },
                new Movie{ Title = "Beaufort", ReleaseDate = new DateTime(2019), Price = 22.79, GenreId =3, DirectorId =3 },
                new Movie{ Title = "Nana", ReleaseDate = new DateTime(2017), Price = 14.99, GenreId =2, DirectorId = 2 },
                new Movie{ Title = "Tattoo", ReleaseDate = new DateTime(2012), Price = 12.89, GenreId =1, DirectorId = 2 },
            };

            _movieActors = new List<MovieActor>
            {
                new MovieActor {ActorId = 2, MovieId = 2},
                new MovieActor {ActorId = 1, MovieId = 2},
                new MovieActor {ActorId = 3, MovieId = 4},
                new MovieActor {ActorId = 5, MovieId = 3},
                new MovieActor {ActorId = 1, MovieId = 5}
               
            };

            _customers = new List<Customer>
            {
                new Customer {FirstName ="Ayhan", LastName="Karaman", Email= "ayhan@gmail.com", PasswordHash = PasswordHash, PasswordSalt = PasswordSalt },
                new Customer {FirstName ="Yasin", LastName="Şahin", Email= "yasin@gmail.com", PasswordHash = PasswordHash, PasswordSalt = PasswordSalt },
                new Customer {FirstName ="Okan", LastName="Ünal", Email= "okan@gmail.com", PasswordHash = PasswordHash, PasswordSalt = PasswordSalt }
            };
            _orders = new List<Order>
            {
                new Order{ MovieId = 1, CustomerId = 1, OrderDate = new DateTime(2019, 10, 10), OrderPrice = 23.28},
                new Order{ MovieId = 4, CustomerId = 3, OrderDate = new DateTime(2020, 06, 05), OrderPrice = 28.28},
                new Order{ MovieId = 2, CustomerId = 3, OrderDate = new DateTime(2020, 06, 05), OrderPrice = 78.28}
            };

            _favoritGenres = new List<CustomerFavoritGenre>
            {
                new CustomerFavoritGenre{ GenreId = 2, CustomerId = 1},
                new CustomerFavoritGenre{ GenreId = 3, CustomerId = 1},
                new CustomerFavoritGenre{ GenreId = 5, CustomerId = 1},
                new CustomerFavoritGenre{ GenreId = 1, CustomerId = 2},
                new CustomerFavoritGenre{ GenreId = 4, CustomerId = 2},
            };

        }

        public static List<Actor> GetActors()
        {
            return _actors.ToList();
        }

        public static List<Director> GetDirectors()
        {
            return _directors.ToList();

        }

        public static List<Genre> GetGenres()
        {
            return _genries.ToList();
        }

        public static List<Movie> GetMovies()
        {
            return _movies.ToList();
        }

        public static List<MovieActor> GetMovieActors()
        {
            return _movieActors;
        }
       
       public static List<Customer> GetCustomers()
       {
           return _customers;
       }

       public static List<CustomerFavoritGenre> GetCustomerFavoritGenres()
       {
           return _favoritGenres;
       }
      
       public static List<Order> GetOrders()
       {
           return _orders;
       }

    }
}