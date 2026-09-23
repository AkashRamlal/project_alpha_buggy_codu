public static class StartMenu
{
    public const string GameName = "Legend of Spidersilk";


    public static string Show()
    {
        Console.WriteLine(@"
,--.   ,--.              ,--.   ,--.            ,---.     ,-----.                          ,--.
|  |   |  | ,---. ,--.--.|  | ,-|  |     ,---. /  .-'    '  .-.  '  ,--.,--. ,---.  ,---.,-'  '-. ,---.
|  |.'.|  || .-. ||  .--'|  |' .-. |    | .-. ||  `-,    |  | |  |  |  ||  || .-. :(  .-''-.  .-'(  .-'
|   ,'.   |' '-' '|  |   |  |\ `-' |    ' '-' '|  .-'    '  '-'  '-.'  ''  '\   --..-'  `) |  |  .-'  `)
'--'   '--' `---' `--'   `--' `---'      `---' `--'       `-----'--' `----'  `----'`----'  `--'  `----'
");
        Console.WriteLine("===========================================================================================================");
        Console.WriteLine();
        string text = "Welcome, adventurer!\n" +
                    "Explore the town and its surroundings, accept quests,\n" +
                    "defeat the monsters that threaten the land and earn\n" +
                    "stronger weapons along the way.";

        foreach (char letter in text)
        {
            Console.Write(letter);
            Thread.Sleep(30);
        }

        Console.WriteLine();
        Console.WriteLine();

        while (true)
        {
            Console.Write("Enter your Hero's name: ");
            string? input = Console.ReadLine();

            if (input == null)
            {
                return "Hero";
            }

            string name = input.Trim();

            if (name != "")
            {
                return name;
            }

            Console.WriteLine("You must enter a name to start the game.");
        }
    }
}