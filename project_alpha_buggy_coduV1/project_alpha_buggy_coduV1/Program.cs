class Program{

    
    public static void Main(){
        bool gameIsRunning = true;
        Location startingLocation = World.Locations[0];
        Player player = new Player("AAA", 200, 200, startingLocation, null);
        while(gameIsRunning)
        {
            Tuple<String, Object> actionToPerform = player.CurrentLocation.Main(player);
            //USE actionToPerform.Item2 to get the appropriate parameter
            switch(actionToPerform.Item1)
            {
                case "Travel":
                    player.CurrentLocation = (Location)actionToPerform.Item2;
                break;
                case "OpenInventory":
                
                break;
                case "EnterBattle":
                    Monster monsterToUse = (Monster)actionToPerform.Item2;
                
                break;
                case "TakeQuest":
                    Quest questToUse = (Quest)actionToPerform.Item2;
                
                break;
            }
        }
    }

}