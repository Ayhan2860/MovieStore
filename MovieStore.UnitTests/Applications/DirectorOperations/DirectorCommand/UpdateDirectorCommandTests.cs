using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.DirectorOperations.Commands.UpdateDirector;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.DirectorOperations.DirectorCommand
{
    public class UpdateDirectorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        
        public UpdateDirectorCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void WhenAllReadyExistDirectorIdInputGiven_ErrorResult_ShouldBeReturn()
        {
             // arrenge
              UpdateDirectorCommand command  =  new UpdateDirectorCommand(_context);
              command.DirectorId  = 6;

              // act
              var result = FluentActions.Invoking(()=> command.Handle()).Invoke();
            
             //
             Assert.Equal("Yönetmen bulunamadı", result.Message);
             Assert.False(result.Success);
              
        }

        [Fact]
        public void WhenAllReadyExistDirectorIdInputGiven_Director_ShouldBeUpdated()
        {
             // arrenge
              UpdateDirectorCommand command  =  new UpdateDirectorCommand(_context);
              command.DirectorId  = 1;
              command.Model = new UpdateDirectorViewModel
              {
                  FirstName = "Hatice",
                  LastName = "Karaman"
              };

              // act
              var result = FluentActions.Invoking(()=> command.Handle()).Invoke();
            
             //
             Assert.Equal("Yönetmen Güncellendi...", result.Message);
             Assert.True(result.Success);
              
        }
    }
}