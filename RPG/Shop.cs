namespace FirstThing.RPG; 

public class Shop {
    
    // Prices
    static readonly int[] _weaponPrices = new [] {1, 100, 200, 300};
    static readonly int[] _armorPrices = new [] {1, 50, 150, 400};
    
    // choose category
    public static void Begin() {
        while (true) {
            Console.WriteLine("As you step into a door, a voice greets you:");
            Console.WriteLine("'Welcome, Stranger!'");
            Console.WriteLine("'What brought you here? Weapons? Armor?'");
            Console.WriteLine("1. I need weapons");
            Console.WriteLine("2. I need armor");
            Console.WriteLine("0. Leave.");
            int choice = -1;
            try {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception e) {
                Console.WriteLine("OOPS! Caught an error, here it is: {0}", e.Message);
            }
            switch (choice) {
                case 1:
                    ShopWeapons();
                    break;
                case 2:
                    ShopArmor();
                    break;
                case 0:
                    Console.WriteLine("Saying goodbye, you leave this place");
                    return;
                default:
                    Console.WriteLine("Try again");
                    break;
            }
        }
    }
    
    // shop for weapons
    static void ShopWeapons() {
        Console.WriteLine("Here's what i've got:");
        Console.WriteLine("1. Wooden Sword, price: {0}", _weaponPrices[0]);
        Console.WriteLine("2. Bronze Sword, price: {0}", _weaponPrices[1]);
        Console.WriteLine("3. Silver Sword, price: {0}", _weaponPrices[2]);
        Console.WriteLine("0 (or anything). No");
        Console.WriteLine("Something caught your eye? (your money: {0})", Player.Money);
        int choice = 0;
        try {
            choice = int.Parse(Console.ReadLine());
        }
        catch (Exception e) {
            Console.WriteLine("OOPS! Caught an error, here it is: {0}", e.Message);
        }
        switch (choice) {
            case 1:
                Buy(RPG.Weapons.WoodenSword, _weaponPrices[0]);
                break;
            case 2:
                Buy(RPG.Weapons.BronzeSword, _weaponPrices[1]);
                break;
            case 3:
                Buy(RPG.Weapons.SilverSword, _weaponPrices[2]);
                break;
            default:
                Console.WriteLine("No.");
                break;
        }
    }
    
    // shop for armors
    static void ShopArmor() {
        Console.WriteLine("Here's what i've got:");
        Console.WriteLine("1. Wooden Armor, price: {0}", _armorPrices[0]);
        Console.WriteLine("2. Bronze Armor, price: {0}", _armorPrices[1]);
        Console.WriteLine("3. Silver Armor, price: {0}", _armorPrices[2]);
        Console.WriteLine("0 (or anything). No");
        Console.WriteLine("Something caught your eye? (your money: {0})", Player.Money);
        int choice = 0;
        try {
            choice = int.Parse(Console.ReadLine());
        }
        catch (Exception e) {
            Console.WriteLine("OOPS! Caught an error, here it is: {0}", e.Message);
        }
        switch (choice) {
            case 1:
                Buy(RPG.Armors.WoodenArmor, _armorPrices[0]);
                break;
            case 2:
                Buy(RPG.Armors.BronzeArmor, _armorPrices[1]);
                break;
            case 3:
                Buy(RPG.Armors.SilverArmor, _armorPrices[2]);
                break;
            default:
                Console.WriteLine("No.");
                break;
        }
    }
    
    // buy a weapon
    static void Buy(RPG.Weapons item, int cost) {
        if (Player.Money < cost) {
            Console.WriteLine("Check your purse");    
        } else if (Player.Weapon == item) {
            Console.WriteLine("You already have this");
        } else {
            Player.Money -= cost;
            Player.Weapon = item;
        }
        Console.WriteLine("Deal! You know own this weapon!");
    }
    
    // buy a armor
    static void Buy(RPG.Armors item, int cost) {
        if (Player.Money < cost) {
            Console.WriteLine("Check your purse");    
        } else if (Player.Armor == item) {
            Console.WriteLine("You already have this");
        } else {
            Player.Money -= cost;
            Player.Armor = item;
        }
        Console.WriteLine("Deal! You know own this armor!");
    }
}