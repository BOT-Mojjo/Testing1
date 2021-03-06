using System;
using System.IO;
using System.Collections.Generic;

public class Inventory{
    static string answer = "";
    static bool acted = false;
    static int windowWidth = 35;

    static public void actionInventory(){
        bool ongoing = true;
        while (ongoing == true){
            Console.Clear();
            drawInventory();
            int openedInventory = miscFunctions.StrToInt(Console.ReadLine());
            if(openedInventory>5 || openedInventory<1){                    
                ongoing = miscFunctions.GoBack();
            }
            Console.Clear();
            switch (openedInventory){
                case 1:
                    actionWeaponsInventory();
                    break;
                case 2:
                    actionArmourInventory();
                    break;
                case 3:
                    actionPotionsInventory();
                    break;
                case 4:
                    actionMiscellaneousInv();
                    break;
                case 5:
                    actionSpellInventory();
                    break;
            } 
        }
    }

    static void drawInventory(){
        string tempCoins = player.coins.ToString();
        while (tempCoins.Length < 4){
            tempCoins = tempCoins.Insert(0, "0");
        }
        Console.WriteLine("+------------=========------------+");
        Console.WriteLine("|        --==Inventory==--        |");
        Console.WriteLine("|     1:Weapons     2:Armour      |");
        Console.WriteLine("|   3:Potions  4:Miscellaneous    |");
        Console.WriteLine("|    5:Spells     Coins: " + tempCoins + "     |");
        Console.WriteLine("+------------=========------------+");
        Console.WriteLine();
            }

    static void actionWeaponsInventory(){
        bool ongoing = true;
        while(ongoing == true){
            Console.Clear();
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("|     --=Weapons Inventory=--     |");
            Console.WriteLine("|     -----------------------     |");
            Console.WriteLine("|        -Equiped Weapons-        |");
            for(int i = 0; i < 2; i++){
                Console.WriteLine($"| Weapons slot {i+1}: {InventoryLists.FetchWeaponName(i)}".PadRight(windowWidth-1)+"|");
            }
            Console.WriteLine("|     -----------------------     |");
            Console.WriteLine("|       -UnEquiped Weapons-       |");
            for(int i = 0; i < 5; i++){
                Console.WriteLine($"| Weapons slot {i+1}: {InventoryLists.FetchWeaponName(i+2)}".PadRight(windowWidth-1)+"|");
            }
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("");
            Console.WriteLine("         Change Weapon? y/n");
            Console.WriteLine();
            answer = Console.ReadLine().ToLower();
            if(answer == "y" || answer =="yes"){  
                if(acted == true && Fight.ongoing == true){
                    Console.Clear();
                    Console.WriteLine("You've already used the inventory this turn.");
                    Console.WriteLine("         Your time is running out.");
                    Console.ReadLine();
                } else {
                    bool ongoing1  = true;
                    while(ongoing1){                                                 //Let's you change equipped weapon
                        Console.Clear();
                        int temp = 0;       //Used to know what weapon slot is gonna change
                        Console.WriteLine("+------------=========------------+");       // during the change since i'll be 
                        Console.WriteLine("|       -=Equiped Weapons=-       |");       // overwriting the old one
                        for(int i = 0; i < 2; i++){
                            Console.WriteLine($"| Weapons slot {i+1}: {InventoryLists.FetchWeaponName(i)}".PadRight(windowWidth-1)+"|");
                        }
                        Console.WriteLine("+------------=========------------+");
                        Console.WriteLine();
                        Console.WriteLine("What weapon do you want to change?");
                        Console.WriteLine();
                        temp = miscFunctions.StrToInt(Console.ReadLine());               // Input from user, what weapon slot to change
                        if(temp!=1 && temp !=2){                    
                            ongoing1 = miscFunctions.GoBack();
                        }else{
                            Console.WriteLine("+------------=========------------+");       //Choosig what weapon to switch to.
                            Console.WriteLine("|      -=UnEquiped Weapons=-      |");       
                            for(int i = 0; i < 5; i++){
                                Console.WriteLine($"| Weapons slot {i+1}: {InventoryLists.FetchWeaponName(i+2)}".PadRight(windowWidth-1)+"|");
                            }
                            Console.WriteLine("+------------=========------------+");
                            Console.WriteLine();
                            Console.WriteLine("    What weapon do you want to");
                            Console.WriteLine("            switch to?");
                            Console.WriteLine();
                            int[] temp2 = new int[3];
                            temp2[1] = miscFunctions.StrToInt(Console.ReadLine());
                            if(temp2[1] == 0 || temp2[1] > 5){
                                ongoing1 = miscFunctions.GoBack();
                            } else {
                                temp2[0]=temp-1;
                                temp2[1]++;
                                temp2[2]=InventoryLists.weaponInventory[temp2[0]];
                                InventoryLists.weaponInventory[temp2[0]]=InventoryLists.weaponInventory[temp2[1]];
                                InventoryLists.weaponInventory[temp2[1]]=temp2[2];
                                acted=true;
                                ongoing1 = false;
                            }
                        }
                    }
                }
            } else {
                ongoing = miscFunctions.GoBack();       
            }
        }
    }


    static void actionArmourInventory(){
        if(Fight.ongoing==true){
            Console.WriteLine();
            Console.WriteLine("You're in a fight, trying to change armour could be fatal.");
            Console.ReadLine();
        } else{
            bool ongoing = true;
            while(ongoing==true){
                Console.Clear();  
                Console.WriteLine("+------------=========------------+");
                Console.WriteLine("|     --=Armours Inventory=--     |");
                if(true){
                    Console.WriteLine($"| Equiped Armour: {InventoryLists.FetchArmourName(0)}".PadRight(windowWidth-1)+"|");
                    Console.WriteLine($"| Spare Armour: {InventoryLists.FetchArmourName(1)}".PadRight(windowWidth-1)+"|");
                }
                Console.WriteLine("+------------=========------------+");
                Console.WriteLine("        Change Armour? y/n");
                Console.WriteLine();
                answer=Console.ReadLine().ToLower();
                if(answer == "y" || answer == "yes"){
                    int[] temp = new int[3];
                    for(int i = 0; i < 3; i++){        //Switches the data places around for the armour
                        temp[i]=InventoryLists.armourInventory[0,i];
                        InventoryLists.armourInventory[0,i]=InventoryLists.armourInventory[1,i];
                        InventoryLists.armourInventory[1,i]=temp[i];
                    }
                } else {
                    ongoing = miscFunctions.GoBack();
                }
            }
        }
    }


    static void actionPotionsInventory(){
        bool ongoing = true;
        while(ongoing == true){
            Console.Clear();
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("|        --=Potion Belt=--        |");
            for(int i = 0; i < 7; i++){
                Console.WriteLine($"| Potion slot {i+1}: {InventoryLists.FetchPotionName(i)}".PadRight(windowWidth-1)+"|");
            }
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("   'Move' to move potions around");
            Console.WriteLine("       'Use' to use a potion");
            Console.Write("               ");
            answer=Console.ReadLine().ToLower();
            if(answer == "move"){
                int[] temp = new int[4];
                Console.Clear();
                Console.WriteLine("+------------=========------------+");
                Console.WriteLine("|        --=Potion Belt=--        |");
                for(int i = 0; i < 7; i++){
                    Console.WriteLine($"| Potion slot {i+1}: {InventoryLists.FetchPotionName(i)}".PadRight(windowWidth-1)+"|");
                }
                Console.WriteLine("+------------=========------------+");
                Console.WriteLine();
                Console.WriteLine("            Move Potion");
                Console.Write("                 ");
                temp[0]=miscFunctions.StrToInt(Console.ReadLine())-1;
                Console.WriteLine("              To Slot");
                Console.Write("                 ");
                temp[1]=miscFunctions.StrToInt(Console.ReadLine())-1;
                temp[2]=InventoryLists.potionInventory[temp[0],0];  //puts pot 1 into temp storage
                temp[3]=InventoryLists.potionInventory[temp[0],1];
                InventoryLists.potionInventory[temp[0],0] = InventoryLists.potionInventory[temp[1],0]; //moves pot 2 into pot 1s old place
                InventoryLists.potionInventory[temp[0],1] = InventoryLists.potionInventory[temp[1],1];
                InventoryLists.potionInventory[temp[1],0] = temp[2];  // moves pot 1 from storage int pot 2s old place
                InventoryLists.potionInventory[temp[1],1] = temp[3];


            } else if(acted == true && answer=="use" && Fight.ongoing == true){
                Console.Clear();
                Console.WriteLine("You've already used the inventory this turn.");
                Console.WriteLine("         Your time is running out.");
                Console.ReadLine();
            } else if(answer == "use"){   // using potions
                bool ongoing1 = true;
                Console.Clear();
                Console.WriteLine("+------------=========------------+");
                Console.WriteLine("|  --=What potion do you Use?=--  |");
                for(int i = 0; i < 7; i++){
                    Console.WriteLine($"| Potion slot {i+1}: {InventoryLists.FetchPotionName(i)}".PadRight(windowWidth-1)+"|");
                }
                Console.WriteLine("+------------=========------------+");
                Console.Write("                 ");
                while(ongoing1 == true){
                    int potionUsed = miscFunctions.StrToInt(Console.ReadLine());
                    if(potionUsed>0 && potionUsed<8){  //a potion is used
                        potionUsed--; //nudges the variable so it lines up with the array, since it starts at 0 and the meny at 1.
                        if(InventoryLists.FetchPotionName(potionUsed)=="Empty"){
                            Console.WriteLine("That vial is empty.");
                        } else {
                            int temp2;
                            switch(InventoryLists.potionInventory[potionUsed,1]){  //differentiates what happens based on potion type
                                case 0:
                                    temp2 = player.health;
                                    player.health = player.health + InventoryLists.FetchHealpotAmount(potionUsed);
                                    if(player.health>player.maxHealth){
                                        player.health=player.maxHealth;
                                    }
                                    temp2 = player.health - temp2;
                                    Console.WriteLine("You Regained "+temp2+"Hp!");
                                    break;
                                case 1:
                                    temp2 = player.mana;
                                    player.mana = player.mana + InventoryLists.FetchManapotAmount(potionUsed);
                                    if(player.mana>player.maxMana){
                                        player.mana=player.maxMana;
                                    }
                                    temp2 = player.mana - temp2;
                                    Console.WriteLine("Your Replenished "+temp2+"Mp!");
                                    break;
                                case 2:
                                    int[] temp3 = new int[2];
                                    temp3 = InventoryLists.FetchBuffPotEffect(potionUsed);
                                    player.atkBuff = player.atkBuff+temp3[0];
                                    player.defBuff = player.defBuff+temp3[1];
                                    Console.WriteLine("You feel strength surge through you.");
                                    break;
                                default:   
                                    //Only fires if there is a potion with a type outside of the Health/Mana/Buff Trifecta, and the array doesn't spit out a failure
                                    //honsetly never expect this to work since the file data list will throw an out of array exeption and crash
                                    Console.WriteLine("potions are malfunctioning?");
                                    Console.WriteLine("what did you even do?");
                                    break;
                            }
                            InventoryLists.potionInventory[potionUsed,0] = 0;  //Removes the potion from the inventory
                            InventoryLists.potionInventory[potionUsed,1] = 0;
                            Console.ReadLine();
                            acted=true;
                            ongoing1=false;
                        } 
                    } else {
                        ongoing1 = miscFunctions.GoBack();
                    }
                }
            } else {
                ongoing = miscFunctions.GoBack();
            }
        }
    }


    static void actionSpellInventory(){
        bool ongoing = true;
        while(ongoing==true){
            Console.Clear();
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("|     --=Spells Inventory=--      |");
            Console.WriteLine("|        -Readied Spells-         |");
            for(int i = 0; i < 2; i++){
                Console.WriteLine($"| Spell slot {i+1}: {InventoryLists.FetchSpellName(i)}".PadRight(windowWidth-1)+"|");
            }
            Console.WriteLine("|     -----------------------     |");
            Console.WriteLine("|         -Known Spells-          |");
            for(int i = 0; i < 5; i++){ 
                Console.WriteLine($"| Spell slot {i+1}: {InventoryLists.FetchSpellName(i+2)}".PadRight(windowWidth-1)+"|");
            }
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("");
            Console.WriteLine("     Change readied spell? y/n");
            answer=Console.ReadLine().ToLower();
            if(answer == "y" || answer =="yes"){  
                if(acted == true && Fight.ongoing == true){
                    Console.Clear();
                    Console.WriteLine("You've already used the inventory this turn.");
                    Console.WriteLine("         Your time is running out.");
                    Console.ReadLine();
                } else { 
                    bool ongoing1 = true;
                     while(ongoing1){
                        int[] temp = new int[4];       //Used to know what weapon slot is gonna change
                        Console.Clear();    //Let's you change equipped weapon
                        Console.WriteLine("+------------=========------------+");       // during the change since i'll be 
                        Console.WriteLine("|        -=Redied Spells=-        |");       // overwriting the old one
                        for(int i = 0; i < 2; i++){
                            Console.WriteLine($"| Spell slot {i+1}: {InventoryLists.FetchSpellName(i)}".PadRight(windowWidth-1)+"|");
                        }
                        Console.WriteLine("+------------=========------------+");
                        Console.WriteLine();
                        Console.WriteLine(" What spell do you want to change?");
                        Console.WriteLine();
                        temp[0] = miscFunctions.StrToInt(Console.ReadLine())-1;               // Input from user, what weapon slot to change
                        if(temp[0] !=0 && temp[0] !=1){                    
                            ongoing = miscFunctions.GoBack();
                        }else{
                            Console.WriteLine("+------------=========------------+");       //Choosig what weapon to switch to.
                            Console.WriteLine("|         -=Known Spells=-        |");       
                            for(int i = 0; i < 5; i++){
                                Console.WriteLine($"| Spell slot {i+1}: {InventoryLists.FetchSpellName(i+2)}".PadRight(windowWidth-1)+"|");
                            }
                            Console.WriteLine("+------------=========------------+");
                            Console.WriteLine();
                            Console.WriteLine("     What Spell do you want to");
                            Console.WriteLine("            switch to?");
                            Console.WriteLine();
                            temp[1] = miscFunctions.StrToInt(Console.ReadLine());
                            if(temp[1] == 1 || temp[1] > 5){
                                ongoing1 = miscFunctions.GoBack();
                            } else {
                                temp[1]++;
                                temp[2]=InventoryLists.spellInventory[temp[0],0];  //puts pot 1 into temp storage
                                temp[3]=InventoryLists.spellInventory[temp[0],1];
                                InventoryLists.spellInventory[temp[0],0] = InventoryLists.spellInventory[temp[1],0]; //moves pot 2 into pot 1s old place
                                InventoryLists.spellInventory[temp[0],1] = InventoryLists.spellInventory[temp[1],1];
                                InventoryLists.spellInventory[temp[1],0] = temp[2];  // moves pot 1 from storage int pot 2s old place
                                InventoryLists.spellInventory[temp[1],1] = temp[3];
                                ongoing1=false;
                                acted=true;
                            }
                        }
                    }
                }
            } else {
                ongoing = miscFunctions.GoBack();
            }
        }
    }

    static void actionMiscellaneousInv(){
        bool ongoing = true;
        int page=0;                                                             //Keeps track of what page you're on
        int pageTotal=(InventoryLists.miscInventory.Count/10);                  //Keeps track of how many pages your inventory has
        while (ongoing){
            Console.Clear();
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine("|  --=Miscellaneous Inventory=--  |");
            if(InventoryLists.miscInventory.Count == 0){
                Console.WriteLine("|            -=Empty=-            |");
            } else {
                Console.WriteLine("| Page: "+(page+1)+"                         |");
                if(InventoryLists.miscInventory.Count<10){
                    for(int i = 0; i < InventoryLists.miscInventory.Count; i++){
                        Console.WriteLine($"| Inv slot {i+1}: {InventoryLists.FetchMiscName(i)}".PadRight(windowWidth-1)+"|");
                    }
                } else {
                    for(int i = 0; i < InventoryLists.miscInventory.Count-(page*10)-1; i++){
                        Console.WriteLine($"| Inv slot {i+1+(page*10)}: {InventoryLists.FetchMiscName(i+(page*10))}".PadRight(windowWidth-1)+"|");
                    }
                }
            }
            Console.WriteLine("+------------=========------------+");
            if(InventoryLists.miscInventory.Count == 0){
                answer="0";
            } else if(pageTotal>0){
                Console.WriteLine("        Move between pages");
                Console.WriteLine("       by typing '<' or '>'");
                Console.WriteLine("   Inspect an Item by inputting");
                Console.WriteLine("       it's number instead.");
                answer=Console.ReadLine();
            } else {    
                Console.WriteLine("           Inspect item?");
                answer=Console.ReadLine();
            }
            if(pageTotal>0 && (answer == "<" || answer == ">")){
                if(answer == "<"){
                    if(page==0){
                        Console.WriteLine("You're on the first page.");
                        Console.ReadKey();
                    } else {
                        page--;
                    }
                } else if(answer == ">"){
                    if(page==pageTotal){
                        Console.WriteLine("You're on the last page.");
                        Console.ReadKey();
                    } else {
                        page++;
                    }
                }
            } else if(miscFunctions.StrToInt(answer)==0 || miscFunctions.StrToInt(answer) > InventoryLists.miscInventory.Count+1){
                ongoing = miscFunctions.GoBack();
            } else {
                int i = miscFunctions.StrToInt(answer)-1;
                Console.Clear();
                Console.WriteLine("+------------=========------------+");
                string name = InventoryLists.FetchMiscName(i);
                Console.WriteLine("|"+miscFunctions.PadEqual("--="+name+"=--", windowWidth-2)+"|");
                Console.WriteLine("|"+miscFunctions.PadEqual("Count: "+InventoryLists.FetchMiscAmount(i), windowWidth-2)+"|");
                string[] tempDescription = InventoryLists.FetchMiscDesc(i);
                foreach(string line in tempDescription){
                    Console.WriteLine("|"+miscFunctions.PadEqual(line, windowWidth-2)+"|");
                }
                Console.WriteLine("+------------=========------------+");
                Console.ReadLine();
            }
        }
    }
}

/*              Misc name & equalPad Legacy code
                string linefiller = "                                 ";
                string name = InventoryLists.FetchMiscName(miscFunctions.StrToInt(answer)-1);
                linefiller = linefiller.Substring(0, 27 - name.Length);
                if(linefiller.Length % 2 == 1){
                    linefiller = linefiller.Substring(0, linefiller.Length/2); //delar "linefiller p?? 2
                    Console.WriteLine("|"+linefiller+"--="+name+"=--"+linefiller+" |"); // skriver "mellanrum ordstr??k mellanrum
                } else {
                    linefiller = linefiller.Substring(0, linefiller.Length/2); // den andra biten finns ifall orden ??r j??mna
                    Console.WriteLine("|"+linefiller+"--="+name+"=--"+linefiller+"|");  // d?? skulle man beh??va olika l??ngd av mellanrum
                }
*/
public class InventoryLists{
    static public int[] weaponInventory = new int[7];            //Actual weapon inventory
    static List<MeleeWeapon> weapons = new List<MeleeWeapon>();  //Acts as a database fromwhere to draw weapon stats
    
    static public int[,] armourInventory = new int[2,3];
    static List<Armour> armour = new List<Armour>();

    static public int[,] potionInventory = new int[7,2];
    static List<healingItem> healingItem = new List<healingItem>();
    static List<manaItem> manaItem = new List<manaItem>();
    static List<buffItem> buffItem = new List<buffItem>();

    static public int[,] spellInventory = new int[7,2];
    static List<offensiveSpell> offensiveSpell = new List<offensiveSpell>();
    static List<utilitySpell> utilitySpell = new List<utilitySpell>();

    static public List<string> miscInventory = new List<string>();
    static List<misc> miscItem = new List<misc>();
    
    static public string FetchWeaponName(int InventoryID){
        return weapons[weaponInventory[InventoryID]].name;
    }
    static public int FetchWeaponDmg(int InventoryID){
        return weapons[weaponInventory[InventoryID]].dmg;
    }

    static public string FetchArmourName(int InventoryID){
        return armour[armourInventory[InventoryID,0]].name;   //<List of data>[array of player inventory[what position item has in invenotry,if it's id or type]]
    }
    static public string FetchPotionName(int InventoryID){
        switch(potionInventory[InventoryID,1]){
            case 0:
                return healingItem[potionInventory[InventoryID,0]].name;    //<List of data>[array of player inventory[what position item has in invenotry,if it's id or type]]
            case 1:
                return manaItem[potionInventory[InventoryID,0]].name;
            case 2:
                return manaItem[potionInventory[InventoryID,0]].name;
            default:
                return "PotionName";
        }
    }
    static public string FetchSpellName(int InventoryID){
        if(spellInventory[InventoryID,1] == 0){
            return offensiveSpell[spellInventory[InventoryID,0]].name; //<List of data>[array of player inventory[what position item has in invenotry,if it's id or type]]
        } else {
            return utilitySpell[spellInventory[InventoryID,0]].name;
        }
    }

    static public string FetchMiscName(int InventoryID){
        string[] temp = miscInventory[InventoryID].Split("|");
        return miscItem[int.Parse(temp[0])].name;
    }
    static public int FetchMiscAmount(int InventoryID){
        string[] temp = miscInventory[InventoryID].Split("|");
        return int.Parse(temp[1]);
    }
    static public string[] FetchMiscDesc(int InventoryID){
        string[] temp = miscInventory[InventoryID].Split("|");
        return miscItem[int.Parse(temp[0])].description.Split("#");
    }
    static public string FetchMiscType(int InventoryID){
        string[] temp = miscInventory[InventoryID].Split("|");
        return miscItem[int.Parse(temp[0])].type;
    }


    static public int FetchHealpotAmount(int InventoryID){
        return healingItem[potionInventory[InventoryID,0]].healing;
    }
    static public int FetchManapotAmount(int InventoryID){
        return manaItem[potionInventory[InventoryID,0]].manaReplenished;
    }
    static public int[] FetchBuffPotEffect(int InventoryID){
        int[] temp = new int[2];
        temp[0] = buffItem[potionInventory[InventoryID,0]].atkEffect;
        temp[1] = buffItem[potionInventory[InventoryID,0]].defEffect;
        return temp;
    }
    static public void AddMiscItem(int itemID, int itemCount){
        int listID = 0;
        bool exists = false;
        foreach(string item in miscInventory){
            string[] temp = item.Split("|");
            if(itemID==int.Parse(temp[0])){
                string newItem = $"{itemID}|{int.Parse(temp[1])+itemCount}";
                miscInventory.RemoveAt(listID);
                miscInventory.Add(newItem);
                exists = true;
                break;
            }
            listID++;
        }
        if (exists==false){
            miscInventory.Add($"{itemID}|{itemCount}");
        }
    }
    static public void inventorySetup(){
        //Weaponry Setup

        string[] equipmentDbString = File.ReadAllLines(@"Inventory\Weaponry.txt"); //loading ALL Weapons data into a variable
        foreach (string line in equipmentDbString){
            if (!(line[0] == '/')){
                string[] weaponData = line.Split('|');

                weapons.Add(new MeleeWeapon() {
                    name = weaponData[0],
                    dmg = int.Parse(weaponData[1]),
                    AcModifier = int.Parse(weaponData[2]),
                    ManaCostReduction = int.Parse(weaponData[3]),
                    SpellEffectModifier = int.Parse(weaponData[4]),
                    cost = int.Parse(weaponData[5])

                });
            }
        }
        weaponInventory[0] = 1;
        //armour

        equipmentDbString = File.ReadAllLines(@"Inventory\Armour.txt"); //loading ALL of Armour data into a variable
        foreach (string line in equipmentDbString){
            if (!(line[0] == '/')){
                string[] data = line.Split('|');

                armour.Add(new Armour() {
                    name = data[0],
                    AC = int.Parse(data[1]),
                    dodge = int.Parse(data[2]),
                    def = int.Parse(data[3]),
                    repairCost = int.Parse(data[4]),
                    cost = int.Parse(data[5]),
                    durability = int.Parse(data[6]),
                    repairCostModifier = int.Parse(data[7])
                });
            }
        }
        armourInventory[0,0]=1;
        armourInventory[0,1]=20;
        armourInventory[0,2]=1;
        //Potions

        equipmentDbString = File.ReadAllLines(@"Inventory\Potions.txt"); //loading ALL of Potion data into a variable
        foreach (string line in equipmentDbString){
            if (!(line[0] == '/')){
                if(line[0]=='h'){
                    string[] data = line.Split('|');

                    healingItem.Add(new healingItem() {
                        name = data[1],
                        healing = int.Parse(data[2]),
                        cost = int.Parse(data[3])
                    });
                }
                if(line[0]=='m'){
                    string[] data = line.Split('|');

                    manaItem.Add(new manaItem() {
                        name = data[1],
                        manaReplenished = int.Parse(data[2]),
                        cost = int.Parse(data[3])
                    });
                }
                if(line[0]=='b'){
                    string[] data = line.Split('|');

                    buffItem.Add(new buffItem() {
                        name = data[1],
                        atkEffect = int.Parse(data[2]),
                        defEffect = int.Parse(data[3]),
                        cost = int.Parse(data[4])
                    });
                }
            }
        }
        potionInventory[0,0]=1; //*,0 is the id of the potion
        potionInventory[0,1]=3; //*,1 is the type of potion. 0 = healing, 1 = mana, 2 = buff.
        potionInventory[1,0]=1;
        potionInventory[0,1]=0;
        potionInventory[2,0]=0;
        potionInventory[2,1]=1;

        equipmentDbString = File.ReadAllLines(@"Inventory\Spells.txt"); //loading ALL of Spell data into a variable
        foreach (string line in equipmentDbString){
            if (!(line[0] == '/')){
                if(line[0]=='o'){
                    string[] data = line.Split('|');

                    offensiveSpell.Add(new offensiveSpell() {
                        name = data[1],
                        dmg = int.Parse(data[2]),
                        aoe = bool.Parse(data[3]),
                        manaCost = int.Parse(data[4]),
                        cost = int.Parse(data[5])
                    });
                }
                if(line[0]=='u'){
                    string[] data = line.Split('|');

                    utilitySpell.Add(new utilitySpell() {
                        name = data[1],
                        atkModifier = int.Parse(data[2]),
                        defModifier = int.Parse(data[3]),
                        acModifier = int.Parse(data[4]),
                        healing = int.Parse(data[5]),
                        duration = int.Parse(data[6]),
                        manaCost = int.Parse(data[7]),
                        cost = int.Parse(data[8])
                    });
                }
            }
        }
        spellInventory[0,0]=1;
        spellInventory[0,1]=0;
        spellInventory[1,0]=0;
        spellInventory[1,1]=1;
        spellInventory[2,0]=1;
        spellInventory[2,1]=1;
        spellInventory[3,0]=2;
        spellInventory[3,1]=1;


        equipmentDbString = File.ReadAllLines(@"Inventory\Miscellaneous.txt"); //loading ALL of Misc data into a variable
        foreach (string line in equipmentDbString){
            if (!(line[0] == '/')){
                string[] data = line.Split('|');

                miscItem.Add(new misc() {
                    type = data[0],
                    name = data[1],
                    description = data[2],
                    cost = int.Parse(data[3])
                });
            }
        }
    }
}