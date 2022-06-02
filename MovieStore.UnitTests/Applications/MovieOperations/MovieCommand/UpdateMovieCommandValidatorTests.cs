using System;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.MovieOperations.Commands.UpdateMovie;
using Xunit;

namespace MovieStore.UnitTests.Applications.MovieOperations.MovieCommand
{
    public class UpdateMovieCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        // WhenInvalidInputActorIdAreGiven_Validator_ShouldBeErrors
        // WhenValidInputActorIdAreGiven_Validator_ShouldNotBeReturnErrors

        [Theory]
        [InlineData(null, null, null, null)]
        public void WhenInvalidInputActorIdAreGiven_Validator_ShouldBeErrors(string title, double price, int genreId, int directorId)
        {
             // arrenge
            UpdateMovieCommand command = new UpdateMovieCommand(null);
            command.MovieId = 1;
            UpdateMovieViewModel model = new UpdateMovieViewModel
            {
                Title = title,
                ReleaseDate = DateTime.Now.Date.AddYears(-1),
                Price = price,
                GenreId = genreId,
                DirectorId = directorId
            };
            command.Model = model;
            UpdateMovieValidator validator = new UpdateMovieValidator();
            //act
            var result = FluentActions.Invoking(()=>validator.Validate(command)).Invoke();
            // assert
            Assert.True(result.Errors.Count > 0);

        }

        [Fact]
          public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeErrors()
        {
             //arrenge
            UpdateMovieCommand command = new UpdateMovieCommand(null);
            command.MovieId = 2;
            command.Model = new UpdateMovieViewModel
            {
                Title = "Çağrı",
                ReleaseDate = DateTime.Now.Date,
                Price = 12.90,
                GenreId = 1,
                DirectorId = 2

            };
            UpdateMovieValidator validator = new UpdateMovieValidator();
            //act
            var result = FluentActions.Invoking(()=>validator.Validate(command)).Invoke();

            //assert
            Assert.True(result.Errors.Count > 0);

        }


         [Fact]
          public void WhenValidInputActorIdAreGiven_Validator_ShouldNotBeReturnErrors()
        {
             //arrenge
            UpdateMovieCommand command = new UpdateMovieCommand(null);
            command.MovieId = 3;
            command.Model = new UpdateMovieViewModel
            {
                Title = "Çağrı",
                ReleaseDate = DateTime.Now.Date.AddYears(-1),
                Price = 12.90,
                GenreId = 1,
                DirectorId = 2

            };
            UpdateMovieValidator validator = new UpdateMovieValidator();
            //act
            var result = FluentActions.Invoking(()=>validator.Validate(command)).Invoke();

            //assert
            Assert.True(result.Errors.Count <= 0);

        }
    }
}