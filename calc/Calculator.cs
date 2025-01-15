namespace calc;

using MyNewLogger;

public class Calculator
{
    private readonly ILogger _logger;

    public Calculator(ILogger logger)
    {
        _logger = logger;
    }

    public string Input()
    {
        string input = Console.ReadLine().Trim();
        _logger.LogInformation(input);
        return input;
    }

    public void Help()
    {
        Console.WriteLine("Enter expressions like: \"5 + 3\" or \"2 ^ 4\".");
        Console.WriteLine("Type \"Help\" for instructions or \"Exit\" to quit.\n");
        Console.WriteLine("Enter expressions in the format: operand1 operator operand2");
        Console.WriteLine("Supported operators: +, -, *, /, %, ^");
        Console.WriteLine("Type \"Exit\" to quit.\n");
    }

    public double ProcessInput(string input)
    {
        string[] parts = input.Split(' ');

        double operand1 = double.Parse(parts[0]);
        char operatorSymbol = char.Parse(parts[1]);
        double operand2 = double.Parse(parts[2]);


        return Calculate(operand1, operatorSymbol, operand2);
    }

    public double Calculate(double a, char op, double b)
    {
        var operations = new Dictionary<char, Func<double, double, double>>()
        {
            { '+', Add },
            { '-', Subtract },
            { '*', Multiply },
            { '/', Divide },
            { '%', Modulo },
            { '^', Power }
        };
        return operations[op](a, b);
    }

    public double Add(double a, double b)
    {
        var result = a + b;
        _logger.LogInformation($"{result}");
        return result;
    }

    public double Subtract(double a, double b)
    {
        var result = a - b;
        _logger.LogInformation($"{result}");
        return result;
    }

    public double Multiply(double a, double b)
    {
        var result = a * b;
        _logger.LogInformation($"{result}");
        return result;
    }

    public double Divide(double a, double b)
    {
        try
        {
            var result = a / b;
            _logger.LogInformation($"{result}");
            return result;
        }
        catch (DivideByZeroException exc)
        {
            _logger.LogError(exc);
            throw;
        }
        
    }

    public double Modulo(double a, double b)
    {
        var result = a % b;
        _logger.LogInformation($"{result}");
        return result;
    }

    public double Power(double a, double b)
    {
        var result = Math.Pow(a, b);
        _logger.LogInformation($"{result}");
        return result;
    }
}