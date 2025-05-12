using CDB.Domain.Entities;

namespace CDB.Domain.Tests;

public class TbCdiTest
{
    [Fact]
    public void TbCdi_ValidInput()
    {
        // Arrange
        int tbCdiId = 1;
        decimal tb = 1.08M;
        decimal cdi = 0.009M;

        // Act
        TbCdi tbCdi = new TbCdi()
                { TbCdiId = tbCdiId, Tb = tb, Cdi = cdi };

        // Assert
        Assert.Equal(tbCdiId, tbCdi.TbCdiId);
        Assert.Equal(tb, tbCdi.Tb);
        Assert.Equal(cdi, tbCdi.Cdi);
    }
}
