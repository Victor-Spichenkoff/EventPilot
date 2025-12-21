using EventPilot.Domain.ValueObjects;

namespace UnitTests.ValueObjects;

public class CodeTest
{
    [Fact]
    public void Should_Create_Valid_Code()
    {
        var code = Code.GenerateRandom();

        var letters = code.ToString().Split("-")[0];
        var numbers = code.ToString().Split("-")[1];
        
        Assert.Equal(2, letters.Length);
        Assert.Equal(3, numbers.Length);
    }

    [Fact]
    public void Should_Generate_Different_Codes()
    {
        var code1 = Code.GenerateRandom();
        var code2 = Code.GenerateRandom();
        
        Assert.NotEqual(code1.ToString(), code2.ToString());
    }
}