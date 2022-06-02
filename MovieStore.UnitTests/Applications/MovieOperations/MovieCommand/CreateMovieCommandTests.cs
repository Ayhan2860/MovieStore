using System;
using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.MovieOperations.MovieCommand
{
    public class CreateMovieCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateMovieCommandTests(CommonTestFixture fixture)
        {
              _context = fixture.Context;
              _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenAllReadyExistInputGiven_ErrorResult_ShouldBeReturn()
        {
              // arrenge
              CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
              command.Model = new CreateMovieViewModel
              {
                Title = "Tattoo",
                ReleaseDate = new DateTime(2012),
                Price = 12.99, 
                GenreId =5, 
                DirectorId =1
              };

              // act
              var result = FluentActions.Invoking(()=> command.Handle()).Invoke();

              // assert
              Assert.Equal(result.Message, "Bu film daha önce kayıt edilmiş");
              Assert.False(result.Success);
              
        }

         [Fact]
        public void WhenAllReadyExistInputGiven_Movie_ShouldBeCreated()
        {
              // arrenge
              CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
              command.Model = new CreateMovieViewModel
              {
                Title = "Hababam sınıfı",
                ReleaseDate = new DateTime(2012),
                Price = 15.99, 
                GenreId =3, 
                DirectorId =2
              };

              // act
              var result = FluentActions.Invoking(()=> command.Handle()).Invoke();

              // assert
              Assert.Equal(result.Message, "Film Kaydedildi");
              Assert.True(result.Success);
              
        }
    }
}