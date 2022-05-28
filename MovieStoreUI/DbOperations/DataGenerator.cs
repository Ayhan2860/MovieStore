using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MovieStoreUI.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if(context.Actors.Any())
                    return;
                else
                 context.Actors.AddRange(MovieStoreDatas.GetActors());


                if (context.Directors.Any())
                    return;
                context.Directors.AddRange(MovieStoreDatas.GetDirectors());

                if(context.Genres.Any())
                    return;
                context.Genres.AddRange(MovieStoreDatas.GetGenres());

                if(context.Movies.Any())
                    return;
                context.Movies.AddRange(MovieStoreDatas.GetMovies());

                if(context.MovieActors.Any()) 
                    return;
                context.MovieActors.AddRange(MovieStoreDatas.GetMovieActors());
                
                if(context.Customers.Any())
                    return;
                context.Customers.AddRange(MovieStoreDatas.GetCustomers());

                if(context.Orders.Any())
                    return;
                context.Orders.AddRange(MovieStoreDatas.GetOrders());
                if(context.CustomerFavoritGenres.Any())
                    return;
                context.CustomerFavoritGenres.AddRange(MovieStoreDatas.GetCustomerFavoritGenres());

                
                context.SaveChanges();
            }
        }
    }
}