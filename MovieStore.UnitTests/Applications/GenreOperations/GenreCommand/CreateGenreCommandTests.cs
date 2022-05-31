using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.GenreOperations.Commands.CreateGenre;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.GenreOperations.GenreCommand
{
    public class CreateGenreCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateGenreCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenAllReadyExistInputGiven_ErrorResult_ShouldBeReturn()
        {
             //arrenge
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = new CreateGenreViewModel
            {
                Name = "Drama"
            };

            // act 
            var result = FluentActions.Invoking(()=> command.Handle()).Invoke();

            // assert

            result.Message.Should().Be("Bu tür adı daha önce kayıt edilmiş");
            result.Success.Should().BeFalse();
        }

        [Fact]
        public void WhenAllReadyExistInputGiven_Genre_ShouldBeCreated()
        {
             //arrenge
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = new CreateGenreViewModel
            {
                Name = "Komedi"
            };

            // act 
            var result = FluentActions.Invoking(()=> command.Handle()).Invoke();

            // assert

            result.Message.Should().Be("Tür Adı Kaydedildi");
            result.Success.Should().BeTrue();
        }

    }
}