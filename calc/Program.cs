using System;

Help();

while (true)
{
    Console.Write("Enter an expression: ");
    string input = Input();

    if (string.Equals(input, "Exit", StringComparison.OrdinalIgnoreCase))
        break;

    if (string.Equals(input, "Help", StringComparison.OrdinalIgnoreCase))
    {
        Help();
        continue;
    }

    double result = ProcessInput(input);
    Console.WriteLine($"Result: {result}\n");
}

static string Input()
{
    string input = Console.ReadLine().Trim();
    return input;
}

static void Help()
{
    Console.WriteLine("Enter expressions like: \"5 + 3\" or \"2 ^ 4\".");
    Console.WriteLine("Type \"Help\" for instructions or \"Exit\" to quit.\n");
    Console.WriteLine("Enter expressions in the format: operand1 operator operand2");
    Console.WriteLine("Supported operators: +, -, *, /, %, ^");
    Console.WriteLine("Type \"Exit\" to quit.\n");
}

static double ProcessInput(string input)
{
    string[] parts = input.Split(' ');

    double operand1 = double.Parse(parts[0]);
    char operatorSymbol = char.Parse(parts[1]);
    double operand2 = double.Parse(parts[2]);

    return Calculate(operand1, operatorSymbol, operand2);
}

static double Calculate(double a, char op, double b)
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

static double Add(double a, double b) => a + b;

static double Subtract(double a, double b) => a - b;

static double Multiply(double a, double b) => a * b;

static double Divide(double a, double b) => a / b;

static double Modulo(double a, double b) => a % b;

static double Power(double a, double b) => Math.Pow(a, b);