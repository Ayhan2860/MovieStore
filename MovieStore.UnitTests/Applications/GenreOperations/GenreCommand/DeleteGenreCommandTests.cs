using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.GenreOperations.Commands.DeletGenre;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.GenreOperations.GenreCommand
{
    public class DeleteGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
      
        public DeleteGenreCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
           
        }

        [Fact]
        public void WhenAllReadyExistGenreIdInputGiven_ErrorResult_ShouldBeReturn()
        {
             //arrenge
             DeleteGenreCommand command = new DeleteGenreCommand(_context);
             command.GenreId = 0;
             
             // act
             var result  = FluentActions.Invoking(()=> command.Handle()).Invoke();

             // assert
             result.Message.Should().Be("Böyle bir tür adı bulunamadı");
             result.Success.Should().BeFalse();
        }

        [Fact]
        public void WhenAllReadyExistGenreIdInputGiven_Genre_ShouldBeDeleted()
        {
             //arrenge
             DeleteGenreCommand command = new DeleteGenreCommand(_context);
             command.GenreId = 1;
             
             // act
             var result  = FluentActions.Invoking(()=> command.Handle()).Invoke();

             // assert
             result.Message.Should().Be("Tür Adı Silindi");
             result.Success.Should().BeTrue();
        }
    }
}