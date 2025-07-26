using QuadraticEquationSolver;

// Configuration de la console
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Title = "★★★ Résolveur d'Équations Quadratiques ★★★";
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Cyan;
Console.Clear();

// Logo ASCII Art
Console.WriteLine(@"
   ____                  _           _   _        
  / __ \                | |         | | (_)       
 | |  | |_   _  __ _  __| |_ __ __ _| |_ _  ___   
 | |  | | | | |/ _` |/ _` | '__/ _` | __| |/ __|  
 | |__| | |_| | (_| | (_| | | | (_| | |_| | (__   
  \___\_\\__,_|\__,_|\__,_|_|  \__,_|\__|_|\___|  
                                                 
  _____                 _   _             
 |  ___|               | | (_)            
 | |__  __ _ _   _  ___| |_ _  ___  _ __  
 |  __|/ _` | | | |/ _ \ __| |/ _ \| '_ \ 
 | |__| (_| | |_| |  __/ |_| | (_) | | | |
 \____/\__, |\__,_|\___|\__|_|\___/|_| |_|
          | |                             
          |_|                             
");

ConsoleUi.DrawBox(() => {
    Console.WriteLine("  RÉSOLVEUR D'ÉQUATIONS QUADRATIQUES  ");
    Console.WriteLine("  ► Une équation quadratique est de la forme: ax² + bx + c = 0  ");
    Console.WriteLine("  ► Entrez les coefficients a, b et c pour trouver les racines  ");
    Console.WriteLine("  ► Tapez 'q' à tout moment pour quitter le programme  ");
});

Console.WriteLine();

var round = 1;

while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"\n╔════════════════════════════════════════════════════╗");
    Console.WriteLine($"║ ÉQUATION #{round,-3}                                   ║");
    Console.WriteLine($"╚════════════════════════════════════════════════════╝");
    
    var a = GetCoefficient("a");
    if (double.IsNaN(a)) break;
    
    var b = GetCoefficient("b");
    if (double.IsNaN(b)) break;
    
    var c = GetCoefficient("c");
    if (double.IsNaN(c)) break;

    try
    {
        var equation = new QuadraticEquation(a, b, c);
        
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\n     ╔═══════════════════════════════════════════╗");
        Console.WriteLine($"     ║  ÉQUATION: {equation,-30} ║");
        Console.WriteLine($"     ╚═══════════════════════════════════════════╝");
        
        var equationResult = equation.Solve();
        Console.WriteLine(equationResult);
    }
    catch (ArgumentException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n  ✗ ERREUR: {ex.Message}");
    }

    // Demander à l'utilisateur s'il veut continuer
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("\n  Appuyez sur Entrée pour résoudre une autre équation ou 'q' pour quitter: ");
    var input = Console.ReadLine();
    
    if (!string.IsNullOrEmpty(input) && input.Equals("q", StringComparison.CurrentCultureIgnoreCase))
    {
        // Quitter le programme
        ConsoleUi.DisplayExitMessage(round);
        break;
    }

    Console.Clear();

    round++;
}

return;

static double GetCoefficient(string coefficientName)
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"\n  ▶ Entrez le coefficient {coefficientName}: ");
        var input = Console.ReadLine();
        
        if (string.IsNullOrEmpty(input) || input.Equals("q", StringComparison.CurrentCultureIgnoreCase))
        {
           return double.NaN;
        }
        if (double.TryParse(input, out double value))
        {
            return value;
        }
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("    ✗ Valeur invalide. Veuillez entrer un nombre réel.");
    }
}