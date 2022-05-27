using Inoxie.Tools.Excel.Models;

namespace Inoxie.Tools.Excel.Tests;

internal class NpoiMemoryStreamTests
{
    [Test]
    public void NpoiMemoryShouldNotBeClosed_WhenAllowCloseSetToFalse()
    {
        //Arrange
        var ms = new NpoiMemoryStream()
        {
            AllowClose = false
        };

        //Act
        ms.Close();

        //Assert    
        Assert.That(ms.CanRead, Is.True);
    }

    [Test]
    public void NpoiMemoryShouldBeClosed_WhenDefault()
    {
        //Arrange
        var ms = new NpoiMemoryStream();

        //Act
        ms.Close();

        //Assert    
        Assert.That(ms.CanRead, Is.False);
    }
}