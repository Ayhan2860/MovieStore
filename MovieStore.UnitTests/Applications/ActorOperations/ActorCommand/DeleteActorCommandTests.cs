using System.Linq;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.ActorOperations.Commands.DeleteActor;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.ActorOperations.ActorCommand
{
    public class DeleteActorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteActorCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void WhenAllReadyExistDeleteActorIdGiven_ErrorResult_ShouldBeReturn()
        {
            //arrenge
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = 0;

            //act
            var result = FluentActions.Invoking(()=> command.Handle()).Invoke();

            // assert
            result.Message.Should().Be("Actor Bulunamadı");

        }
        
        [Fact]
        public void WhenAllReadyExistDeleteActorIdGiven_Actor_ShoulBeDelete()
        {
            //arrenge
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = 5;

            //act
            var result = FluentActions.Invoking(()=> command.Handle()).Invoke();

            // assert
            var actor = _context.Actors.SingleOrDefault(x => x.Id == 5);
            Assert.Null(actor);
            Assert.Equal("Aktör Başarıyla Silindi..", result.Message);

        }
    }
}