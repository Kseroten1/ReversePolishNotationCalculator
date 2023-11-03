using OnpCalc.MathOperators;
using OnpCalc.NumberSystems;

namespace OnpCalc;

public class OnpCalculator : IRpnCalculator
{
    private readonly Dictionary<string, IMathOperator> _operators = new();
    private List<INumberSystem> _numberSystems = new ();
    
    public OnpCalculator(IEnumerable<IMathOperator> operators)
    {
        foreach (var mathOperator in operators)
        {
            _operators.Add(mathOperator.Identity, mathOperator);
        }
        _numberSystems.Add(new BinarySystem());
        _numberSystems.Add(new DecimalSystem());
        _numberSystems.Add(new OctalSystem());
        _numberSystems.Add(new SasinSystem());
    }
    public int Calculate(string input)
    {
        var tokens = input.Split();
        var stack = new Stack<int>();
        foreach (var token in tokens)
        {
            if (_operators.TryGetValue(token, out var mathOperator)) 
            {
                if (stack.Count < 2)
                {
                    throw new Exception("not enough integers");
                }

                var op1 = stack.Pop();
                var op2 = stack.Pop();

                var result = mathOperator.Execute(op1, op2);
                stack.Push(result);
            }
            else
            {
                foreach (var numberSystem in _numberSystems)
                {
                    if (numberSystem.convert(token, out var number))
                    {
                        stack.Push(number.Value);
                    }
                }
            }
        }
        
        if (stack.Count != 1)
        {
            var stackContent = stack.ToArray();
            throw new Exception($"something went wrong, stack Count = {stackContent.Length}, stack content: {string.Join(',', stackContent)}");
        }

        var resultFinal = stack.Pop();
        Console.WriteLine($"Result: {resultFinal}");
        return resultFinal;
    }
}