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
    public int manaCost;
    public int cost;
}

class utilitySpell{
    public string name;
    public int[] Modifiers = new int[3]; //AtkModifier[0], DefModifier[1], AcModifier[2]
    /*public int atkModifier;
    public int AcModifier;*/
    public int manaCost;
    public int cost;
}

//player
class player{
    static public string name;
    static public int maxHealth;
    static public int health;
    static public int maxMana;
    static public int mana;
    static public int atkBuff;
    static public int defBuff;
    static public int coins = valueConvert.genRandom.Next(5,15);
}