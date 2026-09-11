using System;

public class Weapon
{
    public int Id { get; }
    public string Name { get; }
    public int MaximumDamage { get; }

    public Weapon(int id, string name, int maximumDamage)
    {
        Id = id;
        Name = name;
        MaximumDamage = maximumDamage;
    }
}
