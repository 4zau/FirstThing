namespace FirstThing.RPG; 

public class Catacombs {
    static readonly Enemy[] _enemies = {
        new Enemy() {
            Name = "Zombie",
            Armor = 0,
            Damage = 30,
            Health = 40,
            Reward = 175,
        },
        new Enemy() {
            Name = "Rat",
            Armor = 0,
            Damage = 4,
            Health = 10,
            Reward = 25,
        },
        new Enemy() {
            Name = "Fallen knight",
            Armor = 10,
            Damage = 40,
            Health = 72,
            Reward = 250,
        },
        new Enemy() {
            Name = "Treasure hunter",
            Armor = 5,
            Damage = 30,
            Health = 60,
            Reward = 225,
        },
    };

    public static void BeginFight() {
        Random rnd = new Random();
        Enemy enemy = _enemies[rnd.Next(0,3)];
        RPG.Fight(enemy, rnd);
    }
}