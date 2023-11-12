namespace OnpCalc.MathOperators;

public interface IMathOperator
{
    string Identity { get; }
    public double Execute(double op1, double op2);
}