using TemperatureConverter;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Title = "★★★ Convertisseur de Température ★★★";
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Cyan;
Console.Clear();
Console.WriteLine(@"
  _______                                 _                      
 |__   __|                               | |                     
    | | ___ _ __ ___  _ __   ___ _ __ __ _| |_ _   _ _ __ ___    
    | |/ _ \ '_ ` _ \| '_ \ / _ \ '__/ _` | __| | | | '__/ _ \   
    | |  __/ | | | | | |_) |  __/ | | (_| | |_| |_| | | |  __/   
    |_|\___|_| |_| |_| .__/ \___|_|  \__,_|\__|\__,_|_|  \___|   
                     | |                                         
                     |_|                                         
   _____                          _            
  / ____|                        | |           
 | |     ___  _ ____   _____ _ __| |_ ___ _ __ 
 | |    / _ \| '_ \ \ / / _ \ '__| __/ _ \ '__|
 | |___| (_) | | | \ V /  __/ |  | ||  __/ |   
  \_____\___/|_| |_|\_/ \___|_|   \__\___|_|   
                                               
            ");

// Instructions
DrawBox(() =>
{
    Console.WriteLine("  CONVERTISSEUR DE TEMPÉRATURE  ");
    Console.WriteLine("  ► Convertit entre Celsius (°C), Fahrenheit (°F) et Kelvin (K)  ");
    Console.WriteLine("  ► Entrez une valeur et sélectionnez les unités  ");
    Console.WriteLine("  ► Tapez 'q' à tout moment pour quitter le programme  ");
});

Console.WriteLine();

var round = 1;

while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"\n╔════════════════════════════════════════════════════╗");
    Console.WriteLine($"║ CONVERSION #{round,-3}                                 ║");
    Console.WriteLine($"╚════════════════════════════════════════════════════╝");

    // Obtenir la température d'entrée
    double inputValue;
    if (!TryGetTemperatureValue(out inputValue))
        break;

    // Obtenir l'unité d'entrée
    TemperatureUnit fromUnit;
    if (!TryGetTemperatureUnit("d'origine", out fromUnit))
        break;
    
    if (fromUnit == TemperatureUnit.Kelvin && inputValue < 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n  ✗ ERREUR: La température en Kelvin ne peut pas être négative.");

        if (ShouldContinue())
        {
            Console.Clear();
            DisplayHeader();
            round++;
            continue;
        }

        DisplayExitMessage();
        break;
    }

    // Obtenir l'unité cible
    TemperatureUnit toUnit;
    if (!TryGetTemperatureUnit("cible", out toUnit))
        break;

    try
    {
        // Créer l'objet Temperature et effectuer la conversion
        var temperature = new Temperature(inputValue, fromUnit);
        var convertedTemperature = temperature.ConvertTo(toUnit);

        // Afficher le résultat
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n  ✓ RÉSULTAT DE LA CONVERSION:");
        Console.WriteLine($"    {temperature} = {convertedTemperature}");
    }
    catch (ArgumentException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n  ✗ ERREUR: {ex.Message}");
    }

    if (ShouldContinue())
    {
        Console.Clear();
        DisplayHeader();
        round++;
    }
    else
    {
        DisplayExitMessage();
        break;
    }
}

return;


static bool TryGetTemperatureValue(out double value)
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\n  ▶ Entrez la valeur de température: ");
        var input = Console.ReadLine();

        if (string.IsNullOrEmpty(input) || input.Equals("q", StringComparison.OrdinalIgnoreCase))
        {
            value = 0;
            return false;
        }

        if (double.TryParse(input, out value)) return true;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("    ✗ Valeur invalide. Veuillez entrer un nombre.");
    }
}

static bool TryGetTemperatureUnit(string unitType, out TemperatureUnit unit)
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"\n  ▶ Sélectionnez l'unité {unitType}:");
        Console.WriteLine("    1. Celsius (°C)");
        Console.WriteLine("    2. Fahrenheit (°F)");
        Console.WriteLine("    3. Kelvin (K)");
        Console.Write("    Votre choix (1-3): ");

        var input = Console.ReadLine();

        if (string.IsNullOrEmpty(input) || input.Equals("q", StringComparison.OrdinalIgnoreCase))
        {
            unit = TemperatureUnit.Celsius;
            return false;
        }

        if (int.TryParse(input, out var choice) && choice >= 1 && choice <= 3)
        {
            unit = (TemperatureUnit)(choice - 1);
            return true;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("    ✗ Choix invalide. Veuillez entrer un nombre entre 1 et 3.");
    }
}

static bool ShouldContinue()
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("\n  Appuyez sur Entrée pour une autre conversion ou 'q' pour quitter: ");
    var input = Console.ReadLine();

    return string.IsNullOrEmpty(input) || !input.Equals("q", StringComparison.OrdinalIgnoreCase);
}

static void DisplayHeader()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(@"
  _______                                 _                      
 |__   __|                               | |                     
    | | ___ _ __ ___  _ __   ___ _ __ __ _| |_ _   _ _ __ ___    
    | |/ _ \ '_ ` _ \| '_ \ / _ \ '__/ _` | __| | | | '__/ _ \   
    | |  __/ | | | | | |_) |  __/ | | (_| | |_| |_| | | |  __/   
    |_|\___|_| |_| |_| .__/ \___|_|  \__,_|\__|\__,_|_|  \___|   
                     | |                                         
                     |_|                                         
            ");
}

static void DisplayExitMessage()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(@"
     ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓
     ┃       PROGRAMME TERMINÉ !          ┃
     ┃                                    ┃");
    Console.WriteLine(@"     ┃                                    ┃
     ┃       MERCI D'AVOIR UTILISÉ        ┃
     ┃       NOTRE CONVERTISSEUR !        ┃
     ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
}

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