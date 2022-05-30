using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.DirectorOperations.Queries.GetDirectorDetail;
using MovieStoreUI.DbOperations;
using Xunit;

namespace MovieStore.UnitTests.Applications.DirectorOperations.DirectorQuery
{
    public class GetDirectorDetailQueryTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorDetailQueryTests(CommonTestFixture fixture)
        {
            _context  = fixture.Context;
            _mapper  = fixture.Mapper;
        }

        [Fact]
        public void WhenAllReadyExistDirectorInputGiven_ErrorResult_ShouldBeReturn()
        {
             // arrenge
            GetDirectorDetailQuery query  =new GetDirectorDetailQuery(_context, _mapper);
            query.DirectorId  = 6;
            
            // act
            var result = FluentActions.Invoking(()=> query.Handle()).Invoke();

            // assert
            result.Message.Should().Be("Yönetmen Bulunamadı!");
            result.Data.Should().BeNull();
            result.Success.Should().BeFalse();

        }

        [Fact]
        public void WhenAllReadyExistDirectorInputGiven_Director_ShouldBeDirectorDetail()
        {
             // arrenge
            GetDirectorDetailQuery query  =new GetDirectorDetailQuery(_context, _mapper);
            query.DirectorId  = 2;
            
            // act
            var result = FluentActions.Invoking(()=> query.Handle()).Invoke();

            // assert
            result.Message.Should().Be("Yönetmen Bulundu");
            result.Data.Should().NotBeNull();
            result.Success.Should().BeTrue();

        }
    }
}