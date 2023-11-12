namespace OnpCalc.MathOperators;

public class SubtractionMathOperator : IMathOperator
{
    public string Identity => "-";
    public double Execute(double op1, double op2)
    {
        return op1 - op2;
    }
}