using static FirstThing.RPG.RPG;

namespace FirstThing.RPG; 

public class Player {
    public int Money { get; set; }
    public int Health { get; set; }
    public Weapons Weapon { get; set; }
    public Armors Armor { get; set; }

    public Player() {
        Money = 2;
        Health = 100;
        Weapon = Weapons.Nothing;
        Armor = Armors.Nothing;
    }
}
