using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.DirectorOperations.Commands.DeleteDirector;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.DirectorOperations.DirectorCommand
{
    public class DeleteDirectorCommandTests:IClassFixture<CommonTestFixture>
    {
         private readonly MovieStoreDbContext _context;
         public DeleteDirectorCommandTests(CommonTestFixture fixture)
         {
             _context = fixture.Context;
         }

         [Fact]
        public  void WhenAllReadyExistDirectorIdInputGiven_ErrorResult_ShouldBeReturn()
        {
            //arrenge
            DeleteDirectorCommand command  =new DeleteDirectorCommand(_context);
            command.DirectorId  = 0;

            //act
            var result = FluentActions.Invoking(()=> command.Handle()).Invoke();

            // assert
            Assert.Equal("Yönetmen Bulunamadı", result.Message);
            Assert.False(result.Success);
        }

        [Fact]
         public  void WhenAllReadyExistDirectorIdInputGiven_Director_ShouldBeDeleted()
        {
            //arrenge
            DeleteDirectorCommand command  =new DeleteDirectorCommand(_context);
            command.DirectorId  = 1;

            //act
            var result = FluentActions.Invoking(()=> command.Handle()).Invoke();

            // assert
            Assert.Equal("Yönetmen Silindi", result.Message);
            Assert.True(result.Success);
        }
    }
}