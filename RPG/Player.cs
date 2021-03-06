using System.Runtime.CompilerServices;
using static FirstThing.RPG.RPG;

namespace FirstThing.RPG; 

static class Player {
    // variables
    public static int Money { get; set; }

    static int _health;
    public static int Health {
        get => _health;
        set {
            _health = value;
            if (_health > 100) 
                _health = 100;
        } 
    }

    public static Weapons Weapon { get; set; }
    public static Armors Armor { get; set; }

    public static List<Potions> PotionsList { get; set; }

    // constructor
    static Player() {
        Money = 200;
        Health = 100;
        Weapon = Weapons.WoodenSword;
        Armor = Armors.WoodenArmor;
        PotionsList = new List<Potions>();
    }
    
    public static void OutputStats() {
        Console.WriteLine("Money: {0}", Money);
        Console.WriteLine("Health: {0}", Health);
        Console.WriteLine("Weapon: {0}, it deals: {1}", Weapon, (int)Weapon);
        Console.WriteLine("Armor: {0}, it blocks: {1}", Armor, (int)Armor);
        Console.WriteLine("All your potions:");
        foreach (var potion in PotionsList) {
            Console.WriteLine(potion);
        }
    }
}
