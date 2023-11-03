using System.Diagnostics.CodeAnalysis;

namespace OnpCalc.NumberSystems;

public interface INumberSystem
{
    bool convert(string data, [NotNullWhen(true)]out int? number);
}