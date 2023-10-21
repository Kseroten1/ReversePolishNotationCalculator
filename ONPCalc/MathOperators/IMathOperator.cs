namespace OnpCalc.MathOperators;

public interface IMathOperator
{
    string Identity { get; }
    int Execute(int op1, int op2);
}