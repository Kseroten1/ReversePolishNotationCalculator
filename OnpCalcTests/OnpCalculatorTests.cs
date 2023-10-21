using Microsoft.Extensions.DependencyInjection;
using OnpCalc;

namespace OnpCalcTests;

public class OnpCalculatorTests
{
    [Theory]
    [InlineData("2 1 +", 3)]
    [InlineData("-11 -1 +", -12)]
    [InlineData("2 34 %", 0)]
    [InlineData("2 34 *", 68)]
    [InlineData("2 34 /", 17)]
    public void Calculate_ShouldWork_ForGivenInput(string input, int expectedResult)
    {
        var sp = ServiceProviderFactory.CreateServiceProvider();
        var sut = sp.GetService<IRpnCalculator>();
        var result = sut.Calculate(input);
        Assert.Equal(expectedResult, result);
    }
    
}