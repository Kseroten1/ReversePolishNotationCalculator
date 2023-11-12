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
    [InlineData("10b 01b +", 3)]
    [InlineData("73o 21o +", 76)]
    [InlineData("1ś 1ś +", 140_000_000)]
    [InlineData("1ś 10b +", 70_000_002)]
    [InlineData("0.1ś 0101.101b +", 70_000_002)]
    public void Calculate_ShouldWork_ForGivenInput(string input, double expectedResult)
    {
        var sp = ServiceProviderFactory.CreateServiceProvider();
        var sut = sp.GetService<IRpnCalculator>();
        var result = sut.Calculate(input);
        Assert.Equal(expectedResult, result);
    }
    
}