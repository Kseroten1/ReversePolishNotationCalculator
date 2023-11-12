using System.Diagnostics.CodeAnalysis;

namespace OnpCalc.NumberSystems;

public class DecimalSystem : INumberSystem
{
    public bool convert(string data, [NotNullWhen(true)]out double? number)
    {
        try
        {
            number = Convert.ToInt32(data);
            return true;
        }
        catch (FormatException)
        {
            Console.WriteLine("not decimal");
        }
        catch (OverflowException)
        {
            Console.WriteLine("too big number");
        }

        number = null;
        return false;
    }
}