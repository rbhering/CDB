using CDB.Application.Dtos;
using CDB.Application.Interfaces;
using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using Moq;

namespace CDB.Application.Tests.Mocks
{
    public static class MockCdbRequesDtoService
    {
        //public static Mock<ICalculoCdbService> GetCalculoCdbService()
        //{
        //    CdbRequestDto cdbRequestDtoMock = Mock<CdbRequestDto>();

        //    var mockRepo = new Mock<ICalculoCdbService>();

        //    // Fix for CS1501: Provide a Task return value for ReturnsAsync  
        //    //mockRepo.Setup(r => r.PopulateMesesImpostoAsync());
        //    //mockRepo.Setup(r => r.PopulateTbCdiAsync()).Returns(Task.CompletedTask);

        //    mockRepo.Setup(r => r.CalcularCdb(cdbRequestDtoMock)).Returns((CdbResponseDto cdbResponseDto) =>
        //    {
        //        return cdbResponseDto;
        //    });

        //    return mockRepo;
        //}
    }
}
    
