public class Monster
{
    public int ID;
    public string Name;
    public int MaximumDamage;
    public int CurrentHitPoints;
    public int MaximumHitPoints;

    public Monster(int a, string b, int c, int d, int e) => (ID, Name, MaximumDamage, CurrentHitPoints, MaximumHitPoints) = (a, b, c, d, e);
}

public class Quest
{
    public int ID;
    public string Name;
    public string Description;

    public Quest(int a, string b, string c) => (ID, Name, Description) = (a, b, c);
}

public class Weapon
{
    public int ID;
    public string Name;
    public int MaximumDamage;

    public Weapon(int a, string b, int c) => (ID, Name, MaximumDamage) = (a, b, c);
}