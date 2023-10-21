namespace OnpCalc.MathOperators;

public class DivisionMathOperator : IMathOperator
{
    public string Identity => "/";
    public int Execute(int op1, int op2)
    {
        return op1 / op2;
    }
}