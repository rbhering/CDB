using CDB.Domain.Entities;

namespace CDB.Domain.Tests;

public class MesesImpostoTest
{
    [Fact]
    public void MesesImposto_ValidInput()
    {
        // Arrange
        int mesesImpostoId = 1;
        int qtdMeses = 12;
        decimal porcentagemImposto = 1000.00m;

        // Act
        MesesImposto mesesImposto = new MesesImposto() 
        { MesesImpostoId = mesesImpostoId, QtdMeses = qtdMeses, PorcentagemImposto = porcentagemImposto};

        // Assert
        Assert.Equal(mesesImpostoId, mesesImposto.MesesImpostoId);
        Assert.Equal(qtdMeses, mesesImposto.QtdMeses);
        Assert.Equal(porcentagemImposto, mesesImposto.PorcentagemImposto);
    }

}
