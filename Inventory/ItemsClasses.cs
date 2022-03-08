//This whole thing is scrapped, since i can't dynamicly create classes, therefore it will just be easier to make an array for each type of thing
//since i would've needed one anyway to keep track of each class type, and what objects existed.
//or maybe not.

//Update, i can create a list that works as a database, but currently i have to create a method for each type of
//variable in each class. it will work, but it's tedius.

//Consumables
class healingItem{
    public string name;
    public int healing;
    public int cost;
}

class manaItem{
    public string name;
    public int manaReplenished;
    public int cost;
}

class buffItem{
    public string name;
    public int atkEffect;
    public int defEffect;
    public int cost;
}

//Armour
class Armour{
    public string name;
    public int AC;
    public int dodge;
    public int def;
    public int repairCost;
    public int cost;
    public int durability;
    public int repairCostModifier;
}

//Weaponry
class MeleeWeapon{
    public string name;
    public int dmg;
    public int AcModifier;
    //public int[] spellModifiers = new int[2]; //Mana cost Modifier, Effectiveness Modifier
    public int ManaCostReduction;
    public int SpellEffectModifier;
    public int cost;
}

//Spells
class offensiveSpell{
    public string name;
    public int dmg;
    public bool aoe;
    public int manaCost;
    public int cost;
}

class utilitySpell{
    public string name;
    public int atkModifier;
    public int defModifier;
    public int acModifier;
    public int healing;
    public int duration;
    public int manaCost;
    public int cost;
}
//MiscInventory
class misc{
    public string type;
    public string name;
    public string description;
    public int cost;
}

class assignments{
    public string type;
    public string name;
    public string description;
    public int rewards;
    public string[] requirements;
    
}

//player
public class player{
    public string name;
    public int maxHealth;
    public int health;
    public int maxMana;
    public int mana;
    public int atkBuff;
    public int defBuff;
    public int coins;
}

//enemies
public class enemy{
    public string name;
    public int maxHealth;
    public int health;
    public int maxMana;
    public int mana;
    public int atkBuff;
    public int defBuff;
    public int itemsDropped;
}