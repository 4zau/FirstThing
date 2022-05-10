namespace FirstThing.RPG; 

public class Dragon {
    public static void BeginFight() {
        Random rnd = new Random();
        Enemy enemy = new Enemy() {
            Name = "Dragon",
            Armor = 35,
            Damage = 70,
            Health = 400,
            Reward = 99999999,
        };
        RPG.Fight(enemy, rnd);
    }
}