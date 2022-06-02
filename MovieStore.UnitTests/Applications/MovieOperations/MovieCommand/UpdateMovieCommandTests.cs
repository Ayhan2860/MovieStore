using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.MovieOperations.Commands.UpdateMovie;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.MovieOperations.MovieCommand
{
    public class UpdateMovieCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateMovieCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void WhenAllReadyExistMovieIdGiven_ErrorResult_ShouldBeReturn()
        {
            //arrenge
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            command.MovieId = 0;
            
            //act
            var result = FluentActions.Invoking(()=>command.Handle()).Invoke();

            //assert
            result.Message.Should().Be("Güncellenecek film bulunamadı");
            result.Success.Should().BeFalse();
        }


        [Fact]
        public void WhenAllReadyExistMovieIdGiven_Movie_ShouldBeUpdated()
        {
            //arrenge
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            command.MovieId = 4;
            UpdateMovieViewModel model= new UpdateMovieViewModel
            {
                Title = "Belgesel",
                ReleaseDate = new DateTime(2017), 
                Price = 24.99, 
                GenreId =1, 
                DirectorId = 3
            };
            command.Model = model;
            //act
            var result = FluentActions.Invoking(()=>command.Handle()).Invoke();

            //assert
            var movie = _context.Movies.SingleOrDefault(x => x.Id == 4);
            movie.Should().NotBeNull();
            movie.Title.Should().Be(model.Title);
            movie.ReleaseDate.Should().Be(model.ReleaseDate);
            movie.GenreId.Should().Be(model.GenreId);
            movie.Price.Should().Be(model.Price);
            movie.DirectorId.Should().Be(model.DirectorId);
            result.Message.Should().Be("Film Güncellendi");
            result.Success.Should().BeTrue();
        }
    }
}