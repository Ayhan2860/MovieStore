using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.MovieOperations.Queries.GetMovies;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.MovieOperations.MovieQuery
{
    public class GetMoviesQueriesTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMoviesQueriesTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenAllGenresAreRequested_ErrorResult_ShouldBeReturn()
        {
                //arrenge
                GetMoviesQueries queries = new GetMoviesQueries(_context, _mapper);
                var movies = _context.Movies.ToList();
                _context.Movies.RemoveRange(movies);
                _context.SaveChanges();
               
               //act
               var result = FluentActions.Invoking(()=>queries.Handle()).Invoke();

               //assert
               result.Data.Should().BeNull();
               result.Message.Should().Be("Film verisi bulunamadı!");
               result.Success.Should().BeFalse();

        }

        [Fact]
         public void WhenAllGenresAreRequested_Genre_ShouldBeReturn()
        {
             GetMoviesQueries queries = new GetMoviesQueries(_context, _mapper);

               //act
               var result = FluentActions.Invoking(()=>queries.Handle()).Invoke();

               //assert
               var movies = _context.Movies.ToList();
               result.Data.Should().NotBeNull();
               result.Success.Should().BeTrue();
               Assert.True(movies.Count == result.Data.Count);
        }
    }
}