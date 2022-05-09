namespace FirstThing.RPG; 

public class Forest {
    static readonly Enemy[] _enemies = {
        new Enemy() {
            Name = "Wolf",
            Armor = 1,
            Damage = 7,
            Health = 15,
            Reward = 50,
        },
        new Enemy() {
            Name = "Bear",
            Armor = 2,
            Damage = 20,
            Health = 30,
            Reward = 150,
        },
        new Enemy() {
            Name = "Bandit",
            Armor = 3,
            Damage = 16,
            Health = 12,
            Reward = 75,
        },
        new Enemy() {
            Name = "Monkey",
            Armor = 0,
            Damage = 2,
            Health = 5,
            Reward = 25,
        },
    };

    public static void BeginFight() {
        Random rnd = new Random();
        Enemy enemy = _enemies[rnd.Next(0,3)];
        RPG.Fight(enemy, rnd);
    }
    
}