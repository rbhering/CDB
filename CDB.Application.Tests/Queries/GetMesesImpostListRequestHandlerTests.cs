using AutoMapper;
using CDB.Application.Queries.MesesImposto;
using CDB.Application.Common.Mocks;
using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDB.Application.Tests.Queries
{
    public class GetMesesImpostListRequestHandlerTests
    {
        private readonly Mock<IMesesImpostoRepository> _mockRepo;

        public GetMesesImpostListRequestHandlerTests()
        {
            _mockRepo = MockMesesImpostoRepository.GetMesesImpostoRepository();
        }

        [Fact]
        public async Task GetMesesImposttoListTest()
        {
            var handler = new MesesImpostoQueryHandler(_mockRepo.Object);

            var result = await handler.Handle(new MesesImpostoQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<MesesImposto>>();
        }
    }
}
