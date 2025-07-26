namespace QuadraticEquationSolver;

public static class ConsoleUi
{
    public static void DrawBox(Action drawContent)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("╔════════════════════════════════════════════════════╗");
        Console.ForegroundColor = ConsoleColor.White;
        drawContent();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("╚════════════════════════════════════════════════════╝");
        Console.ForegroundColor = ConsoleColor.Cyan;
    }
    
    public static void DisplayExitMessage(int equationsCount)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
     ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
     ┃       PROGRAMME TERMINÉ !          ┃
     ┃                                    ┃");
        Console.WriteLine($"     ┃       ÉQUATIONS RÉSOLUES : {equationsCount,-5}     ┃");
        Console.WriteLine(@"     ┃                                    ┃
     ┃       MERCI D'AVOIR UTILISÉ        ┃
     ┃       NOTRE RÉSOLVEUR D'ÉQUATIONS  ┃
     ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
    }
}