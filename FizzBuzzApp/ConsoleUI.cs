namespace FizzBuzzApp
{
    /// <summary>
    /// Classe utilitaire pour l'interface console du jeu FizzBuzz
    /// </summary>
    public static class ConsoleUi
    {
        /// <summary>
        /// Dessine une boîte autour du contenu fourni
        /// </summary>
        /// <param name="drawContent">Action qui dessine le contenu à l'intérieur de la boîte</param>
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

        /// <summary>
        /// Affiche une réaction ASCII art selon le type fourni
        /// </summary>
        /// <param name="type">Type de réaction ("GOOD" ou "BAD")</param>
        public static void DisplayReaction(string type)
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
    }
}
