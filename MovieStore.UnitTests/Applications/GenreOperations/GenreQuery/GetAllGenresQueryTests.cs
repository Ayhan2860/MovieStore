using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.GenreOperations.Queries.GetAllGenres;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.GenreOperations.GenreQuery
{
    public class GetAllGenresQueryTests:IClassFixture<CommonTestFixture>
    {
         private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAllGenresQueryTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenAllGenresAreRequested_ErrorResult_ShouldBeReturn()
        {
            // arrenge
            GetAllGenresQuery query = new GetAllGenresQuery(_context, _mapper);
            var genres = _context.Genres.ToList();
            _context.Genres.RemoveRange(genres);
            _context.SaveChanges();

            // act
            var result = FluentActions.Invoking(()=> query.Handle()).Invoke();

            // assert
            result.Data.Should().BeNull();
            result.Message.Should().Be("Kayıtlı tür adları bulunamadı!!");
            result.Success.Should().BeFalse();
        }

        [Fact]
        public void WhenAllGenresAreRequested_Genre_ShouldBeReturn()
        {
            // arrenge
            GetAllGenresQuery query = new GetAllGenresQuery(_context, _mapper);

            // act
            var result = FluentActions.Invoking(()=> query.Handle()).Invoke();

            // assert
            result.Data.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }
}