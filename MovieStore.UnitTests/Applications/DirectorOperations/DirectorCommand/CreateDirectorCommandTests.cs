using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.DirectorOperations.DirectorCommand
{
    public class CreateDirectorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateDirectorCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void WhenAllReadyExistDirectorInputGiven_ErrorResult_ShouldBeReturn()
        {
             // arrenge
            CreateDirectorCommand command  =new CreateDirectorCommand(_context, _mapper);
            CreateDirectorViewModel model= new CreateDirectorViewModel
            {
                FirstName = "Linus",
                LastName = "Potts"
            };
            command.Model = model;
            // act
            var result = FluentActions.Invoking(() => command.Handle() ).Invoke();

            // assert
            result.Message.Should().Be("Yönetmen daha önce kayıt edilmiş");
            result.Success.Should().BeFalse();

        }

        [Fact]
        public void WhenAllReadyExistDirectorInputGiven_Director_ShouldBeCreated()
        {
             // arrenge
            CreateDirectorCommand command  =new CreateDirectorCommand(_context, _mapper);
            CreateDirectorViewModel model= new CreateDirectorViewModel
            {
                FirstName = "Ayhan",
                LastName = "Karaman"
            };
            command.Model = model;
            // act
            var result = FluentActions.Invoking(() => command.Handle() ).Invoke();

            // assert
            result.Message.Should().Be("Yönetmen Kaydı yapıldı");
            result.Success.Should().BeTrue();

        }
    }
}