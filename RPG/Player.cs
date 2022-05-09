using static FirstThing.RPG.RPG;

namespace FirstThing.RPG; 

static class Player {
    // variables
    public static int Money { get; set; }
    public static int Health { get; set; }
    public static Weapons Weapon { get; set; }
    public static Armors Armor { get; set; }

    // constructor
    static Player() {
        Money = 2;
        Health = 100;
        Weapon = Weapons.Nothing;
        Armor = Armors.Nothing;
    }
    
    public static void OutputStats() {
        Console.WriteLine("Money: {0}", Money);
        Console.WriteLine("Health: {0}", Health);
        Console.WriteLine("Weapon: {0}, it deals: {1}", Weapon, (int)Weapon);
        Console.WriteLine("Armor: {0}, it blocks: {1}", Armor, (int)Armor);
    }
}
