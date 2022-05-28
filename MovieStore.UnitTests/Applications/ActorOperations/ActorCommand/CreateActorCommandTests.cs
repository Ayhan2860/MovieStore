using System;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using MovieStore.UnitTests.TestSetup;
using MovieStoreUI.Application.ActorOperations.Commands.CreateActor;
using MovieStoreUI.Common.Results;
using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;
using Xunit;

namespace MovieStore.UnitTests.Applications.ActorOperations.ActorCommand
{
    public class CreateActorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateActorCommandTests(CommonTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;

        }
       
        [Fact]
        public void WhenAllReadyExistActorInputGiven_ErrorResult_ShouldBeReturn()
        {
            //arrenge
            var actor = new Actor{FirstName = "Ayhan", LastName = "Karaman"};
            _context.Actors.Add(actor);
            _context.SaveChanges();
            
            // act
            CreateActorCommand command  = new CreateActorCommand(_context, _mapper);
            command.Model = new CreateActorViewModel {FirstName = actor.FirstName, LastName = actor.LastName};
            var result = command.Handle();
            //assert
            Assert.Equal("Bu Aktör Daha Önce Kayıt Edilmiş", result.Message);

        }

        [Fact]
        public void WhenInputGiven_Actor_ShouldBeCreated()
        {
             //arrenge
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            CreateActorViewModel viewModel = new CreateActorViewModel(){
                FirstName = "Ayhan",
                LastName  = "KARAMAN"
            };
            command.Model = viewModel;

            //act
            var result =FluentActions
             .Invoking(() => command.Handle()).Invoke();

            //assert
            var actor = _context.Actors.SingleOrDefault(x=>x.FirstName == viewModel.FirstName && x.LastName == viewModel.LastName);
            actor.Should().NotBeNull();
            result.Message.Should().Be("Aktör kaydedildi...");

        }

    }
}