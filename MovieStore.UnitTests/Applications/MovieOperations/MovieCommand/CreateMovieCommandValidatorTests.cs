using System;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.MovieOperations.Commands.CreateMovie;
using Xunit;

namespace MovieStore.UnitTests.Applications.MovieOperations.MovieCommand
{
    public class CreateMovieCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(null, null, null, null)]
         public void WhenInvalidInputMovieAreGiven_Validator_ShouldBeErrors(string title, double price, int genreId, int directorId)
        {
             //arrenge
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            command.Model = new CreateMovieViewModel
            {
                Title = title,
                ReleaseDate = DateTime.Now.Date.AddYears(-1),
                Price = price,
                GenreId = genreId,
                DirectorId = directorId

            };
            CreateMovieValidator validator = new CreateMovieValidator();
            //act
            var result = FluentActions.Invoking(()=>validator.Validate(command)).Invoke();

            //assert
            Assert.True(result.Errors.Count > 0);

        }

        [Fact]
          public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeErrors()
        {
             //arrenge
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            command.Model = new CreateMovieViewModel
            {
                Title = "Çağrı",
                ReleaseDate = DateTime.Now.Date,
                Price = 12.90,
                GenreId = 1,
                DirectorId = 2

            };
            CreateMovieValidator validator = new CreateMovieValidator();
            //act
            var result = FluentActions.Invoking(()=>validator.Validate(command)).Invoke();

            //assert
            Assert.True(result.Errors.Count > 0);

        }

        [Fact]
        public void WhenValidInputMovieAreGiven_Validator_ShouldNotBeReturnErrors()
        {
                //arrenge
               CreateMovieCommand command = new CreateMovieCommand(null, null);
               command.Model = new CreateMovieViewModel
               {
                    Title = "Aykut Enişte",
                    ReleaseDate = DateTime.Now.Date.AddYears(-1),
                    Price = 12.90,
                    GenreId = 1,
                    DirectorId = 2
               };

            CreateMovieValidator validator = new CreateMovieValidator();
            //act
            var result = FluentActions.Invoking(()=>validator.Validate(command)).Invoke();

            //assert
            Assert.True(result.Errors.Count <= 0);
        }

         
    }
}