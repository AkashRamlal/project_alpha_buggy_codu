using System.Linq.Expressions;


public class Location
{
    public int ID;
    public string Name;
    public string Description;
    public Quest? QuestAvailableHere;
    public Monster? MonsterLivingHere;
    public Location? LocationToNorth;
    public Location? LocationToWest;
    public Location? LocationToSouth;
    public Location? LocationToEast;

    public Location(int locID, string name, string desc, Quest? quest, Monster? monster) => (ID, Name, Description, QuestAvailableHere, MonsterLivingHere) = (locID, name, desc, quest, monster);

    public Tuple<String, Object> Main(Player player)
    {
        //Write locationname, description, health, questprog
        Console.WriteLine($"You are at: {Name}");
        Console.WriteLine(Description);
        Console.WriteLine($"Your health is {player.CurrentHitPoints}/{player.MaximumHitPoints}");
        Console.WriteLine("QuestProgPlaceholder");
        //Collect all valid options for the current situation: take quest, fight, move, open inventory
        List<Tuple<String, int>> options = [];
        if (QuestAvailableHere != null)
        {
            Tuple<String, int> entry = new Tuple<String, int> ($"Take a quest: {QuestAvailableHere.Description}.", 0);
            options.Add(entry);}
        if (MonsterLivingHere != null)
        {
            Tuple<String, int> entry = new Tuple<String, int> ($"Enter a battle against: {MonsterLivingHere.Name}.", 1);
            options.Add(entry);}
        Tuple<String, int> invEntry = new Tuple<String, int> ("Open inventory.", 2);
        options.Add(invEntry);
        if (LocationToNorth != null)
        {
            Tuple<String, int> entry = new Tuple<String, int> ($"Travel north towards: {LocationToNorth.Name}.", 3);
            options.Add(entry);}
        if (LocationToEast != null)
        {
            Tuple<String, int> entry = new Tuple<String, int> ($"Travel east towards: {LocationToEast.Name}.", 4);
            options.Add(entry);}
        if (LocationToSouth != null)
        {
            Tuple<String, int> entry = new Tuple<String, int> ($"Travel south towards: {LocationToSouth.Name}.", 5);
            options.Add(entry);}
        if (LocationToWest != null)
        {
            Tuple<String, int> entry = new Tuple<String, int> ($"Travel west towards: {LocationToWest.Name}.", 6);
            options.Add(entry);}
        int counter = 0;
        foreach (Tuple<String, int> entry in options)
        {
            counter += 1;
            Console.WriteLine($"{counter}. {entry.Item1}");
        }
        string result;
        while (true) {
            Console.WriteLine("Choose an option by number:");
            result = Console.ReadLine()!.Trim();
            if (int.TryParse(result, out int converted))
            {
                try {
                switch(options[converted-1].Item2)
                {
                    case 0:
                        return new Tuple<String, Object> ("TakeQuest", QuestAvailableHere!);
                    case 1:
                        return new Tuple<String, Object> ("EnterBattle", MonsterLivingHere!);
                    case 2:
                        return new Tuple<String, Object> ("OpenInventory", null!);
                    case 3:
                        return new Tuple<String, Object> ("Travel", LocationToNorth!);
                    case 4:
                        return new Tuple<String, Object> ("Travel", LocationToEast!);
                    case 5:
                        return new Tuple<String, Object> ("Travel", LocationToSouth!);
                    case 6:
                        return new Tuple<String, Object> ("Travel", LocationToWest!);
                    default:
                        continue;
                }
                } catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }
            } else
            {
                Console.WriteLine("Invalid input.");
                continue;
            }
        }
    }
}