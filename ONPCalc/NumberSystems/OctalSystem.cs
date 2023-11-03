using System.Diagnostics.CodeAnalysis;

namespace OnpCalc.NumberSystems;

public class OctalSystem : INumberSystem
{
    public bool convert(string data, [NotNullWhen(true)]out int? number)
    {
        if (!data.EndsWith("o"))
        {
            number = null;
            return false;
        }

        try
        {
            number = Convert.ToInt32(data[..^1], 8);
            return true;
        }
        catch (FormatException)
        {
            Console.WriteLine("not octal");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Too big number");
        }

        number = null;
        return false;
    }
}