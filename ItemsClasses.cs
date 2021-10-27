//This whole thing is scrapped, since i can't dynamicly create classes, therefore it will just be easier to make an array for each type of thing
//since i would've needed one anyway to keep track of each class type, and what objects existed.
//or maybe not.

//Consumables
class healingItem{
    public string name;
    public int healing;
    public int cost;
}

class buffItem{
    public string name;
    public int[] effect = new int[2];
    public int cost;
}

//Armour
class armour{
    public string name;
    public int AC;
    public int dodge;
    public int def;
    public int cost;
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
    static public int coins = valueConvert.genRandom.Next(5,15);
}