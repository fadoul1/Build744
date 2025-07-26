using PhoneNumberParser;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Title = "★★★ Convertisseur de Numéro de Téléphone ★★★";
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Cyan;
Console.Clear();

Console.WriteLine(@"
  _____  _                        _   _                 _               
 |  __ \| |                      | \ | |               | |              
 | |__) | |__   ___  _ __   ___  |  \| |_   _ _ __ ___ | |__   ___ _ __ 
 |  ___/| '_ \ / _ \| '_ \ / _ \ | . ` | | | | '_ ` _ \| '_ \ / _ \ '__|
 | |    | | | | (_) | | | |  __/ | |\  | |_| | | | | | | |_) |  __/ |   
 |_|    |_| |_|\___/|_| |_|\___| |_| \_|\__,_|_| |_| |_|_.__/ \___|_|   
                                                                       
");

DrawBox(() => {
    Console.WriteLine("  CONVERTISSEUR DE NUMÉRO DE TÉLÉPHONE NORD-AMÉRICAIN  ");
    Console.WriteLine("  ► Entrez un numéro de téléphone à 10 chiffres  ");
    Console.WriteLine("  ► Le format (XXX)XXX-XXXX sera généré  ");
    Console.WriteLine("  ► Entrez 'q' à tout moment pour quitter  ");
});

Console.WriteLine();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\n╔════════════════════════════════════════════════════╗");
    Console.WriteLine("║         CONVERTISSEUR DE NUMÉRO DE TÉLÉPHONE         ║");
    Console.WriteLine("╚════════════════════════════════════════════════════╝");

    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("\n▶ Entrez un numéro de téléphone à 10 chiffres (ou 'q' pour quitter): ");
    
    var input = Console.ReadLine();
    
    if (string.IsNullOrEmpty(input) || input.Equals("q", StringComparison.CurrentCultureIgnoreCase))
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
     ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
     ┃       PROGRAMME TERMINÉ !          ┃
     ┃                                    ┃
     ┃       MERCI D'AVOIR UTILISÉ        ┃
     ┃       LE CONVERTISSEUR DE NUMÉRO        ┃
     ┃       DE TÉLÉPHONE !               ┃
     ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        break;
    }

    try
    {
        var phoneNumber = new NorthAmericaPhoneNumber(input);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✓ SUCCÈS! Format du numéro: {phoneNumber}");
        DisplayReaction("GOOD");
    }
    catch (ArgumentException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n✗ ERREUR! {ex.Message}");
        DisplayReaction("BAD");
    }

    Thread.Sleep(1500);
    Console.Clear();
}

// Méthodes utilitaires
static void DrawBox(Action drawContent)
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("╔════════════════════════════════════════════════════╗");
    Console.ForegroundColor = ConsoleColor.White;
    drawContent();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("╚════════════════════════════════════════════════════╝");
    Console.ForegroundColor = ConsoleColor.Cyan;
}

static void DisplayReaction(string type)
{
    if (type == "GOOD")
    {
        string[] animations = {
            @"  \o/  ",
            @"   |   ",
            @"  / \  "
        };

        foreach (string line in animations)
        {
            Console.WriteLine(line);
        }
    }
    else
    {
        string[] animations = {
            @"   x_x  ",
            @"    |   ",
            @"   / \  "
        };

        foreach (string line in animations)
        {
            Console.WriteLine(line);
        }
    }
}