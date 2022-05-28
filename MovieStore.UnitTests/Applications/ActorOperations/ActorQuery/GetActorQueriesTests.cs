using System.Linq;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.ActorOperations.Queries.GetActors;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.ActorOperations.ActorQuery
{
    public class GetActorQueriesTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public GetActorQueriesTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

       [Fact]
        public void WhenAllReadyExist_ErrorResult_ShouldBeReturn()
        {
            // arrenge
            GetActorQueries queries = new GetActorQueries(_context, _mapper);
            var actors = _context.Actors.Include(a => a.MovieActors).ThenInclude(x =>  x.Movie).OrderBy(a => a.Id).ToList();
            _context.Actors.RemoveRange(actors);
            _context.SaveChanges();
            //act
            var result = FluentActions.Invoking(()=>queries.Handle()).Invoke();
            
            //assert
            result.Message.Should().Be("Actor Bulunamdı");
            result.Success.Should().BeFalse();
            result.Data.Should().BeNullOrEmpty();

        }
      
        [Fact]
        public void WhenAllReadyExist_Actor_ShoulBeAllActor()
        {
        // arrenge
            GetActorQueries queries = new GetActorQueries(_context, _mapper);
            //act
            var result = FluentActions.Invoking(()=>queries.Handle()).Invoke();
            
            //assert
            result.Message.Should().Be("Tüm aktörler listelendi");
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNullOrEmpty();
        }
    }
}