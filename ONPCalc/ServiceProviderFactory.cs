using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnpCalc.MathOperators;

namespace OnpCalc;

public static class ServiceProviderFactory
{
    //Microsoft documentation on using Dependency Injection (Inversion) (kontener zależności) 
    public static IServiceProvider CreateServiceProvider()
    {
        var host = Host
            .CreateDefaultBuilder()
            .UseConsoleLifetime()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IRpnCalculator, OnpCalculator>();
                services.AddSingleton<IMathOperator, AdditionMathOperator>();
                services.AddSingleton<IMathOperator, SubtractionMathOperator>();
                services.AddSingleton<IMathOperator, ModuloMathOperator>();
                services.AddSingleton<IMathOperator, MultiplicationMathOperator>();
                services.AddSingleton<IMathOperator, DivisionMathOperator>();
                
            })
            .Build();
        return host.Services;
    }
}