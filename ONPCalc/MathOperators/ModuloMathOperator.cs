using System.Collections.Immutable;

namespace OnpCalc.MathOperators;

public class ModuloMathOperator : IMathOperator
{
    public string Identity => "%";
    public int Execute(int op1, int op2)
    {
        return op1 % op2;
    }
}