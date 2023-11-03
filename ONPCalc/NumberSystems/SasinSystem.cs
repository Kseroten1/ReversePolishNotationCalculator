using System.Diagnostics.CodeAnalysis;

namespace OnpCalc.NumberSystems;

public class SasinSystem : INumberSystem
{
    public bool convert(string data, [NotNullWhen(true)]out int? number)
    {
        if (!data.EndsWith("ś"))
        {
            number = null;
            return false;
        }
        try
        {
            number = Convert.ToInt32(data[..^1]) * 70_000_000;
            return true;
        }
        catch (FormatException)
        {
            Console.WriteLine("not sasin");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Too big number");
        }

        number = null;
        return false;
    }
}