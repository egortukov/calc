using System;
using calc;
using MyNewLogger;

List<ILogger> loggers = new List<ILogger>();
var consoleLogger = new ConsoleLogger();
var fileLogger = new FileLogger("log.txt");
loggers.Add(consoleLogger);
loggers.Add(fileLogger);
var compositeLogger = new CompositeLogger(loggers);
var calculator = new Calculator(compositeLogger);






calculator.Help();

while (true)
{
    Console.Write("Enter an expression: ");
    string input = calculator.Input();

    if (string.Equals(input, "Exit", StringComparison.OrdinalIgnoreCase))
        break;

    if (string.Equals(input, "Help", StringComparison.OrdinalIgnoreCase))
    {
        calculator.Help();
        continue;
    }

    double result = calculator.ProcessInput(input);
    Console.WriteLine($"Result: {result}\n");
}

