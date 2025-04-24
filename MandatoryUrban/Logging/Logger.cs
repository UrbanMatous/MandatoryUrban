using System;
using System.Diagnostics;
/// <summary>
/// Handles logging output from the game.
/// </summary>
public static class GameLogger
{
    static GameLogger()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
    }

    /// <summary>
    /// Logs a message with a timestamp.
    /// </summary>

    public static void Log(string message)
    {
        Trace.WriteLine($"[{DateTime.Now}] {message}");
    }
}