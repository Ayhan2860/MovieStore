using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.MovieOperations.MovieQuery
{
    public class GetMovieDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetMovieDetailQueryTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenAllReadyExistMovieIdGiven_ErrorResult_ShouldBeReturn()
        {
            //arrenge
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
            query.MovieId = 0;

            //act
            var result = FluentActions.Invoking(()=>query.Handle()).Invoke();
            //assert
            result.Data.Should().BeNull();
            result.Message.Should().Be("Film Bulunamadı!");
            result.Success.Should().BeFalse();
            
        }

        [Fact]
        public void WhenAllReadyExistMovieIdGiven_Movie_ShouldBeMovie()
        {
            //arrenge
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
            query.MovieId = 4;

            //act
            var result = FluentActions.Invoking(()=>query.Handle()).Invoke();
            //assert
            result.Data.Should().NotBeNull();
            result.Success.Should().BeTrue();
            
        }
    }
}