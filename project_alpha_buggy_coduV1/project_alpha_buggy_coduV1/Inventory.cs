public class Inventory
{
    List<Weapon> contents;

    public Inventory(List<Weapon> startWeapons)
    {
        contents = startWeapons;
    }

    public void AddWp(Weapon wpToAdd)
    {
        contents.Add(wpToAdd);
    }

    public void InvMenu(Player player)
    {
        Console.Clear();
        Console.WriteLine("- - - - - - - - - -");
        Console.WriteLine($"Your current weapon: {player.CurrentWeapon!.Name}");
        Console.WriteLine("- - - - - - - - - -");
        Console.WriteLine("Your current inventory:");
        int counter = 0;
        foreach(Weapon wp in contents)
        {
            counter++;
            Console.WriteLine($"{counter}. {wp.Name}");
        }
        Console.WriteLine("- - - - - - - - - -");
        Console.WriteLine("Enter what weapon you want to equip by number, don't enter anything to return:");
        string input = Console.ReadLine()!;
        if (int.TryParse(input, out int choice))
        {
            if (choice > 0 && choice <= contents.Count())
            {
                player.CurrentWeapon = contents[choice-1];
            }
        }
    }
}