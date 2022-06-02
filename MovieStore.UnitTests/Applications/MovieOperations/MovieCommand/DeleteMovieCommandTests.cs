using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.MovieOperations.Commands.DeleteMovie;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.MovieOperations.MovieCommand
{
    public class DeleteMovieCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteMovieCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }
       
       [Fact]
       public void WhenAllReadyExistMovieIdGiven_ErrorResult_ShouldBeReturn()
       {
           //arrenge
           DeleteMovieCommand command = new DeleteMovieCommand(_context);
           command.MovieId = 0;
           
           // act 
           var result = FluentActions.Invoking(()=> command.Handle()).Invoke();
           //assert
           result.Message.Should().Be("Silinecek film bulunamadı");
           result.Success.Should().BeFalse();
       }

       [Fact]
       public void WhenAllReadyExistMovieIdGiven_Movie_ShouldBeDelete()
       {
           //arrenge
           DeleteMovieCommand command = new DeleteMovieCommand(_context);
           command.MovieId = 4;
           
           // act 
           var result = FluentActions.Invoking(()=> command.Handle()).Invoke();
           //assert
           result.Message.Should().Be("Film Kaydı Silindi");
           result.Success.Should().BeTrue();
       }
    }
}