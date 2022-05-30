using System.Linq;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.DirectorOperations.Queries.GetDirectors;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.DirectorOperations.DirectorQuery
{
    public class GetDirectorsQueriesTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorsQueriesTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }
        [Fact]
        public void WhenAllReadyExistDirectorGetAll_ErrorResult_ShouldBeReturn()
        {
            // arrenge
             GetDirectorsQueries queries = new GetDirectorsQueries(_context, _mapper);
            var directors = _context.Directors.Include(a => a.Movies).ThenInclude(x =>  x.MovieActors).OrderBy(a => a.Id).ToList();
            _context.Directors.RemoveRange(directors);
            _context.SaveChanges();

            // act
            var result = FluentActions.Invoking(()=> queries.Handle()).Invoke();
            // assert
            Assert.Null(result.Data);
            Assert.Equal("Yönetmen Bulunamadı", result.Message);
            Assert.False(result.Success);
        }

        [Fact]
        public void WhenAllReadyExistDirectorGetAll_Director_ShouldBeDirectors()
        {
            // arrenge
             GetDirectorsQueries queries = new GetDirectorsQueries(_context, _mapper);

            // act
            var result = FluentActions.Invoking(()=> queries.Handle()).Invoke();
            // assert
            Assert.NotNull(result.Data);
            Assert.Equal("Tüm Yönetmenler Listelendi...", result.Message);
            Assert.True(result.Success);
        }
    }
}