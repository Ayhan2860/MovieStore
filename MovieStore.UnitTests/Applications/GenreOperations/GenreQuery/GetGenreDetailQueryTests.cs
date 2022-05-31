using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.GenreOperations.Queries.GetGenreDetail;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.GenreOperations.GenreQuery
{
    public class GetGenreDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenreDetailQueryTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenAllReadyExistGenreIdInputGiven_ErrorResult_ShouldBeReturn()
        {
            //arrenge
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreId = 0;
            
            // act
            var result = FluentActions.Invoking(()=> query.Handle()).Invoke();

            //assert
            result.Message.Should().Be("Bu isimde böyle bir tür bulunamadı");
            result.Data.Should().BeNull();
            result.Success.Should().BeFalse();
        }

         [Fact]
        public void WhenAllReadyExistGenreIdInputGiven_Genre_ShouldBeReturn()
        {
            //arrenge
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreId = 1;
            
            // act
            var result = FluentActions.Invoking(()=> query.Handle()).Invoke();

            //assert
            result.Message.Should().Be("Tür Adı Bulundu");
            result.Data.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }
}