public class Quest
{
    public int ID;
    public string Name;
    public string Description;
    public int RequiredMonsterID;
    public Weapon? Reward;

    public Quest(int id, string name, string description, int requiredMonsterID, Weapon? reward = null)
    {
        ID = id;
        Name = name;
        Description = description;
        RequiredMonsterID = requiredMonsterID;
        Reward = reward;
    }
}