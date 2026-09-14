public class Monster
{
    
    public int ID { get; set; }
    public string Name { get; set; }
    public int MaximumDamage { get; set; }
    public int CurrentHitPoints { get; set; }
    public int MaximumHitPoints { get; set; }

    public Monster(int id, string name, int maximumDamage, int currentHitPoints, int maximumHitPoints)
    {
        ID = id;
        Name = name;
        MaximumDamage = maximumDamage;
        CurrentHitPoints = currentHitPoints;
        MaximumHitPoints = maximumHitPoints;
    }
}