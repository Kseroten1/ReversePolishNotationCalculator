using System.Diagnostics.CodeAnalysis;

namespace OnpCalc.NumberSystems;

public class BinarySystem : INumberSystem
{
    public bool convert(string data, [NotNullWhen(true)]out int? number)
    {
        if (!data.EndsWith("b"))
        {
            number = null;
            return false;
        }

        try
        {
            number = Convert.ToInt32(data[..^1], 2);
            return true;
        }
        catch (FormatException)
        {
            Console.WriteLine("not binary");
        }
        catch (OverflowException)
        {
            Console.WriteLine("too big number");
        }

        number = null;
        return false;
    }
}