using EventPilot.Domain.ValueObjects;
using Shouldly;

namespace UnitTests.ValueObjects;

public class CodeTest
{
    [Fact]
    public void Should_Create_Valid_Code()
    {
        var code = Code.GenerateRandom();

        var letters = code.ToString().Split("-")[0];
        var numbers = code.ToString().Split("-")[1];
        
        letters.Length.ShouldBe(2);
        numbers.Length.ShouldBe(3);
    }

    [Fact]
    public void Should_Generate_Different_Codes()
    {
        var code1 = Code.GenerateRandom();
        var code2 = Code.GenerateRandom();
        
        code1.ToString().ShouldNotBe(code2.ToString());
    }
}