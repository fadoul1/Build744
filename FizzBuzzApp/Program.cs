using FizzBuzzApp;

// Configuration de la console
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Title = "★★★ FizzBuzz Game ★★★";
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Cyan;
Console.Clear();
Console.WriteLine(@"
  _______ _____ ________  ________  ___ _   ___________ 
 |  _____|_   _|___  /  \/  |  _ \ / _ \ | | |___  /___/
 |  |_     | |    / /| .  . | |_) / /_\ \ | | |  / /   
 |   _|    | |   / / | |\/| |  _ \|  _  | | | | / /    
 |  |     _| |_./ /__| |  | | |_) | | | \ \_/ /./ /    
 |_|     \___/\_____\_|  |_/____/\_| |_/\___/ \_/     
");

ConsoleUi.DrawBox(() => {
    Console.WriteLine("  RÈGLES DU JEU:  ");
    Console.WriteLine("  ► 'Fizz' si le nombre est divisible par 3  ");
    Console.WriteLine("  ► 'Buzz' si le nombre est divisible par 5  ");
    Console.WriteLine("  ► 'FizzBuzz' si le nombre est divisible par 3 ET par 5  ");
    Console.WriteLine("  ► Le nombre lui-même dans les autres cas  ");
    Console.WriteLine("  ► Tapez 'q' à tout moment pour quitter le jeu  ");
});

Console.WriteLine();

var score = 0;
var round = 1;
var random = new Random();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"\n╔═══════════════════════════════════════╗");
    Console.WriteLine($"║ ROUND {round,-3}           SCORE: {score,-5}   ║");
    Console.WriteLine($"╚═══════════════════════════════════════╝");

    var number = random.Next(1, 101); // Nombre aléatoire entre 1 et 100
    var fizzBuzz = new FizzBuzz(number);
    var correctAnswer = fizzBuzz.GetResult();

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"\n     ╔═══════════════╗");
    Console.WriteLine($"     ║  NOMBRE: {number,-4} ║");
    Console.WriteLine($"     ╚═══════════════╝");

    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("\n  ▶ Votre réponse: ");

    var userAnswer = Console.ReadLine();

    if (string.IsNullOrEmpty(userAnswer) || userAnswer.Equals("q", StringComparison.CurrentCultureIgnoreCase))
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
     ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
     ┃       PARTIE TERMINÉE !            ┃
     ┃                                    ┃");
        Console.WriteLine($"     ┃       NOMBRE DE PARTIE : {round,-5}     ┃");
        Console.WriteLine($"     ┃       SCORE FINAL: {score,-5}           ┃");
        Console.WriteLine(@"     ┃                                    ┃
     ┃       MERCI D'AVOIR JOUÉ !         ┃
     ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        break;
    }

    if (userAnswer.Equals(correctAnswer, StringComparison.CurrentCultureIgnoreCase))
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n  ✓ CORRECT! +1 point");
        ConsoleUi.DisplayReaction("GOOD");
        score++;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n  ✗ INCORRECT! La bonne réponse était: {correctAnswer}");
        ConsoleUi.DisplayReaction("BAD");
    }

    Thread.Sleep(1500); // Pause pour lire le résultat
    Console.Clear();
    round++;
}
