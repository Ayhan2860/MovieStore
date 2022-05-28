using System.Linq;
using AutoMapper;
using MovieStoreUI.Application.ActorOperations.Commands.CreateActor;
using MovieStoreUI.Application.ActorOperations.Queries.GetActorDetail;
using MovieStoreUI.Application.ActorOperations.Queries.GetActors;
using MovieStoreUI.Application.CustomerOperations.Commands.CreateCustomer;
using MovieStoreUI.Application.CustomerOperations.Queries.GetCustomerDetail;
using MovieStoreUI.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreUI.Application.DirectorOperations.Queries.GetDirectorDetail;
using MovieStoreUI.Application.DirectorOperations.Queries.GetDirectors;
using MovieStoreUI.Application.GenreOperations.Commands.CreateGenre;
using MovieStoreUI.Application.GenreOperations.Queries.GetAllGenres;
using MovieStoreUI.Application.GenreOperations.Queries.GetGenreDetail;
using MovieStoreUI.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreUI.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStoreUI.Application.MovieOperations.Queries.GetMovies;
using MovieStoreUI.Application.OrderOperations.Commands.CreateOrder;
using MovieStoreUI.Application.OrderOperations.Queries.GetByCustomerIdOrderDetail;
using MovieStoreUI.Application.OrderOperations.Queries.GetDetailOrder;
using MovieStoreUI.Entities;

namespace MovieStoreUI.Common.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            /* Actor Mapping Operations Start */
            CreateMap<Actor, ActorsViewModel>().ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src =>  $"{src.FirstName}  {src.LastName}"))
             .ForMember(dest=>dest.Movies, opt=>opt.MapFrom(src=>src.MovieActors.Select(ma => ma.Movie).ToList()));
             CreateMap<Movie, ActorsViewModel.MovieActorViewModel>();

            CreateMap<Actor, ActorDetailViewModel>().ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src =>  $"{src.FirstName}  {src.LastName}"))
            .ForMember(dest=>dest.Movies, opt=>opt.MapFrom(src=>src.MovieActors.Select(ma => ma.Movie).ToList()));
            CreateMap<Movie, ActorDetailViewModel.MovieActorViewModel>();
            CreateMap<CreateActorViewModel, Actor>();
            /* Actor Mapping Operations End */


            /* Director Mapping Operations Start */
            CreateMap<CreateDirectorViewModel, Director>();
            CreateMap<Director, DirectorDetailViewModel>().ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src =>  $"{src.FirstName}  {src.LastName}"))
            .ForMember(dest=>dest.Movies, opt=>opt.MapFrom(src =>src.Movies.ToList()));
            CreateMap<Movie, DirectorDetailViewModel.MovieList>();

            CreateMap<Director, GetDirectorsViewModel>().ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src =>  $"{src.FirstName}  {src.LastName}"))
            .ForMember(dest => dest.Movies, opt=>opt.MapFrom(src =>src.Movies.ToList()));
            CreateMap<Movie, GetDirectorsViewModel.MovieList>();
            /* Director Mapping Operations End */

            /* Movie Mapping Operations Start */
            CreateMap<CreateMovieViewModel, Movie>();

            CreateMap<Movie, GetMoviesViewModel>()
            .ForMember(dest=> dest.Director, opt=>opt.MapFrom(src => $"{src.Director.FirstName} {src.Director.LastName}"))
            .ForMember(dest=> dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.MovieActors, opt=> opt.MapFrom(src=>src.MovieActors.Select(ma=>ma.Actor).ToList()));

            CreateMap<Actor, GetMoviesViewModel.Actors>()
            .ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src=> $"{src.FirstName}  {src.LastName}"));



            CreateMap<Movie, GetMovieViewModel>()
            .ForMember(dest=> dest.Director, opt=>opt.MapFrom(src => $"{src.Director.FirstName} {src.Director.LastName}"))
            .ForMember(dest=> dest.Genre, opt=>opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.MovieActors,opt=>opt.MapFrom(src=>src.MovieActors.Select(ma=>ma.Actor).ToList()));

            CreateMap<Actor, GetMovieViewModel.Actors>()
            .ForMember(dest=>dest.FullName, opt=>opt.MapFrom(src=> $"{src.FirstName}  {src.LastName}"));
            /* Movie Mapping Operations End */
            

            /* Customer Mapping Operations Start */
            CreateMap<CreateCustomerViewModel, Customer>();
   
            
            CreateMap<Customer, CustomerDetailViewModel>()
            .ForMember(dest => dest.FavoritGenres, opt=>opt.MapFrom(src=>src.CustomerFavoritGenres.Select(fg =>fg.Genre).ToList()))
            .ForMember(dest => dest.OrderVMs, opt => opt.MapFrom(src => src.OrderMovies.ToList()))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>  $"{src.FirstName}  {src.LastName}"));

            
            CreateMap<Genre, CustomerDetailViewModel.CustomerFavoritGenreVM>();
            CreateMap<Order, CustomerDetailViewModel.OrderVM>();
            CreateMap<Movie, CustomerDetailViewModel.MovieDetailVM>();

            /* Customer Mapping Operations End */

            /* Order Operations Start */
            CreateMap<CreateOrderViewModel, Order>();

            CreateMap<Order, OrderDetailViewModel>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => $"{src.Customer.FirstName}  {src.Customer.LastName}"))
            .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Title));
            CreateMap<Order, GetByCustomerIdOrderDetailViewModel>()
            .ForMember(dest=> dest.Movie, opt=>opt.MapFrom(src=>src.Movie.Title));
            /* Order Operations End */

            /* Genre Mapping Operations Start */
             CreateMap<CreateGenreViewModel, Genre>();
             CreateMap<Genre, GetAllGenresViewModel>();
             CreateMap<Genre, GetGenreDetailViewModel>();
             /* Genre Mapping Operations End */
        }
    }
}