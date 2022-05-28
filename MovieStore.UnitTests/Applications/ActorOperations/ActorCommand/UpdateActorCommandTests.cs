using System.Linq;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.ActorOperations.Commands.UpdateActor;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.ActorOperations.ActorCommand
{
    public class UpdateActorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public UpdateActorCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void WhenAllReadyExistUpdateActorIdGiven_ErrorResult_ShouldBeReturn()
        {
            // arrenge
            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.ActorId  = 0;

            //act
            var result = FluentActions.Invoking(()=> command.Handle()).Invoke();

            //assert
            result.Message.Should().Be("Güncellenecek Aktör bulunamadı");

        }

        [Fact]
        public void WhenAllReadyExistActorIdGiven_Actor_ShouldBeUpdate()
        {
             // arrenge
             UpdateActorCommand command = new UpdateActorCommand(_context);
             command.ActorId = 1;
             UpdateActorViewModel viewModel = new UpdateActorViewModel{
                FirstName = "Ayhan",
                LastName = "Karaman"
             };
             command.Model = viewModel;

             // act
             var result = FluentActions.Invoking(()=> command.Handle()).Invoke();

             // assert
             var actor = _context.Actors.SingleOrDefault(x => x.Id == 1);
             actor.Should().NotBeNull();
             actor.FirstName.Should().Be(viewModel.FirstName);
             actor.LastName.Should().Be(viewModel.LastName);
             result.Message.Should().Be("Aktör güncellendi...");
        }
        
    }
}