namespace Lab4_MiniProject.Helpers;

public static class ConsoleColorExtention
{
    public static void Writeline(ConsoleColor consoleColor,string message)
    {
        Console.ForegroundColor = consoleColor;
        Console.WriteLine(message);
        Console.ResetColor();
    }
   
    
}