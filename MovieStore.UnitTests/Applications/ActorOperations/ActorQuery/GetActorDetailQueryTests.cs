using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.ActorOperations.Queries.GetActorDetail;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.ActorOperations.ActorQuery
{
    public class GetActorDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetActorDetailQueryTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper  = fixture.Mapper;
        }

        [Fact]
        public void WhenAllReadyExistActorIdGiven_ErrorResult_ShouldBeReturn()
        {
             //arrenge
             GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
             query.ActorId = 0;

            //act
            var result = FluentActions.Invoking(()=>query.Handle()).Invoke();
            //assert
            result.Message.Should().Be("Aktör Bulunamadı");
        }

        [Fact]
        public void WhenAllReadyExistActorIdGiven_Actor_ShoulBeActorDetail()
        {
             //arrenge
             GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
             query.ActorId = 1;

            //act
            var result = FluentActions.Invoking(()=>query.Handle()).Invoke();
            //assert
            result.Data.Should().NotBeNull();
            result.Success.Should().BeTrue();
            
        }
    }
}