using System.Collections.Immutable;

namespace OnpCalc.MathOperators;

public class ModuloMathOperator : IMathOperator
{
    public string Identity => "%";
    public double Execute(double op1, double op2)
    {
        return op1 % op2;
    }
}