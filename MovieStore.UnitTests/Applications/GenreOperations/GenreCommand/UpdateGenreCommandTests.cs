using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.GenreOperations.Commands.UpdateGenre;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.GenreOperations.GenreCommand
{
    public class UpdateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateGenreCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void WhenAllReadyExistGenreIdInputGiven_ErrorResult_ShouldBeErrors()
        {
            //arrenge
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 0;
            command.Model = new UpdateGenreViewModel
            {
                Name = "Korku"
            };
            
            // act
            var result = FluentActions.Invoking(()=> command.Handle()).Invoke();

            // assert
            result.Message.Should().Be("Tür sistemde kayıtlı değil");
            result.Success.Should().BeFalse();
        }
        
        [Fact]
         public void WhenAllReadyExistGenreIdInputGiven_Genre_ShouldBeUpdated()
        {
            //arrenge
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 1;
            command.Model = new UpdateGenreViewModel
            {
                Name = "Korku"
            };
            
            // act
            var result = FluentActions.Invoking(()=> command.Handle()).Invoke();

            // assert
            result.Message.Should().Be("Tür Adı Güncellendi");
            result.Success.Should().BeTrue();
        }
    }
}