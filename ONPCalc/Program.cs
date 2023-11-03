using Microsoft.Extensions.DependencyInjection;
using OnpCalc;

var sp = ServiceProviderFactory.CreateServiceProvider();
var input = Console.ReadLine();
var calculator = sp.GetService<IRpnCalculator>();
Console.WriteLine(calculator.Calculate(input));
