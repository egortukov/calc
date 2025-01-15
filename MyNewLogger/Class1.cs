using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;


namespace MyNewLogger;

public interface ILogger
{
    public void LogInformation(string message);

    public void LogError(Exception exception, string? additionalMessage = null);
}

public class ConsoleLogger : ILogger
{
    public void LogInformation(string message)
    {
        Console.WriteLine(message);
    }

    public void LogError(Exception exception, string? additionalMessage = null)
    {
        Console.WriteLine($"Error: {exception.Message} \n {additionalMessage}");
    }
}

public class FileLogger : ILogger
{
    private string _fileName;

    public FileLogger(string fileName)
    {
        _fileName = fileName;
    }

    public void LogInformation(string message)
    {
        using var streamWriter = new StreamWriter(_fileName, true);
        streamWriter.WriteLine(message);
    }

    public void LogError(Exception exception, string? additionalMessage = null)
    {
        using var streamWriter = new StreamWriter(_fileName, true);
        streamWriter.WriteLine($"Error: {exception.Message} \n {additionalMessage}");
    }
}

public class CompositeLogger : ILogger
{
    private readonly List<ILogger> _loggers;

    public CompositeLogger(List<ILogger> loggers)
    {
        _loggers = loggers;
    }

    public void LogInformation(string message)
    {
        foreach (var logger in _loggers)
        {
            logger.LogInformation(message);
        }
    }

    public void LogError(Exception exception, string? additionalMessage = null)
    {
        foreach (var logger in _loggers)
        {
            logger.LogError(exception, additionalMessage);
        }
    }
}