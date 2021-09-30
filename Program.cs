using System;
using System.IO;

int hadEnough = 0;
bool inFight = false;
string enemyName; // Names should always be 11 Characters long, no exceptions even if you have to just fill them with spaces.
string playerName;
int enemyHealth;
int playerHealth = 10;
int maxEnemyHealth;
string enemyAction;
Random gen = new Random();

//attacks setup:

int[] equipedAttacks = new int[4]; // Current attacks the player has equiped
equipedAttacks[0]=1;    //1=starting weapon
equipedAttacks[1]=0;    //0=empty
equipedAttacks[2]=0;
equipedAttacks[3]=0;
string[] equipmentDbString = File.ReadAllLines(@"Equipment.txt"); //loading ALL Equipment data into a variable

//fighting styles setup:

string[] fightingStylesDBString = File.ReadAllLines(@"FightingStyles.txt");  //all fighting styles
string[,] fightingStylesLearned = new string[4, 3];   //current learned fighting style
for(int i=0;i<8;i++){                                                         //filling all spots in the string to prevent NULL exceptions
    string[] fightingStylesTemp = fightingStylesDBString[0].Split("|");       //making the db string usable temporarily,
    //fightingStylesLearned[i/2,i%2]=fightingStylesDBString[0];            
    if(i%2==0){
        fightingStylesLearned[i/2,i%2]=fightingStylesTemp[0];  //fills in the name
        fightingStylesLearned[i/2,2]="1";                      //fills in the id, 1 for "none" in this case
    } else {
        fightingStylesLearned[i/2,i%2]="0";                    //fills in the lvl for the Style, 1 for lvl 1
    }
    if(i==7){                                        //Equiping the starter fighting style, manually and hardcoded
        fightingStylesLearned[0,0]="Self-Taught";    //First Column stores the name of the style
        fightingStylesLearned[0,1]="1";              //Second column stores the level of the style
        fightingStylesLearned[0,2]="2";              //Third stores Fighting Style id, the line number it's stored on in FightingStyles.txt
    }
}
int[] fightingStyle = new int[2];  //currently equiped fighting style, with what it does math wise 
fightingStyle[0] = 4;              //[0]=+atk%
fightingStyle[1] = 4;              //[1]=+def%
figthingSytlesMeny();
actionStyleChange();
figthingSytlesMeny();
Console.WriteLine(fightingStylesLearned[0,0]);
Console.WriteLine(fightingStyle[0]);
Start:
Console.WriteLine("RPG adventure of the CMD");
Console.WriteLine("  Write Start to Begin");
Console.WriteLine();
//Console.WriteLine("Write Rules to learn how to play");

Choices:
string WhatPlayerDid = Console.ReadLine(); //lets the player choose between starting,
if(WhatPlayerDid == "Start"){              //checking how the game works,
    goto StartOfAdventure;                 //and for those who can't follow instructions.
} else if(WhatPlayerDid=="Rules"){
    Console.WriteLine("u moma");
    
    Console.ReadLine();
    goto Start;
} else {
    if(hadEnough > 5){
        Console.WriteLine("You're supposed to write 'Start' with the first letter capatilized and nothing else.");
        Console.WriteLine("You can do it, c'mon");
        string death = Console.ReadLine();
        if(death=="Start"){
            Console.WriteLine();
            Console.WriteLine("I knew you could do it!");
            Console.ReadLine();
            goto StartOfAdventure;
        } else {
            Console.WriteLine();
            Console.WriteLine("You know what, I've had enough.");
            goto End;
        }
    }
    Console.WriteLine("Try that again");
    hadEnough++;
    Console.WriteLine();
    goto Choices;
}




StartOfAdventure:
Console.Clear();
Console.WriteLine("What is your name Adventurer?");
playerName = Console.ReadLine();
Console.WriteLine();


Console.WriteLine("I see. Good luck on your Journey, "+playerName+".");
Console.ReadLine();
Console.Clear();
Console.WriteLine("As you set out on your Journey, your first steps lead you to The Peaceful Plains");
Console.WriteLine("Before you a little Bunny's jumping around.");
Console.ReadLine();
inFight=true;
while(inFight==true){
    int enemy = gen.Next(0,1);
    string[] enemyDbString = File.ReadAllLines(@"EnemySpecifics.txt");  //getting all of the enemy data into a variable 
    string[] currentEnemy = enemyDbString[1].Split('|');    //Splitting the data for the current enemy 
                                                            //into usable chunks

    enemyHealth = int.Parse(currentEnemy[1]);               
    maxEnemyHealth = enemyHealth;
    enemyAction="Bite";
    enemyName=currentEnemy[0];
    while(enemyHealth>0){
        Console.Clear();
        Console.WriteLine("+-----------------------+");
        Console.WriteLine($"|      {enemyName}      |");
        if(enemyHealth<10){
            Console.WriteLine($"|       0{enemyHealth}hp/0{maxEnemyHealth}hp       |");
        } else if(enemyHealth > 99){
            Console.WriteLine($"|      {enemyHealth}hp/{maxEnemyHealth}hp        |");
        } else {
            Console.WriteLine($"|       {enemyHealth}hp/{maxEnemyHealth}hp         |");
        }
        Console.WriteLine("+-----------------------+");
        Console.WriteLine("They're preparing to use:");
        Console.WriteLine("          "+enemyAction);
        for(int i = 0; i<5; i++){
        Console.WriteLine();
        }
        Console.WriteLine("+-----------------------+");
        //                 |    Player    10hp     |
        Console.WriteLine($"|    Player    {playerHealth}hp     |");
        Console.WriteLine("|  1:Attack 2:Style     |");
        Console.WriteLine("|  3:Flee   4:Inventory |");
        Console.WriteLine("+-----------------------+");
        playerAction:
        int PlayerAction = StrToInt(Console.ReadLine());
        Console.Clear();
        switch(PlayerAction){
            case 0:
            Console.WriteLine("Write a number");
            goto playerAction;
            
            case 1:
            attackMeny();
            actionAttack();
            break;

            case 2:
            figthingSytlesMeny();
            actionStyleChange();
            break;

        }
    }
    if(enemyHealth==0){
        Console.WriteLine($"You've defeated {enemyName},");
        Console.WriteLine($"Earning you {currentEnemy[3]}xp");
        inFight=false;
        
    }



    



    void actionAttack(){ //tar hand om matten och attack id för attaken
        int attackUsed = StrToInt(Console.ReadLine());
        int attackRoll = gen.Next(5,20);
        if(attackRoll<int.Parse(currentEnemy[2])){
            Console.WriteLine("You Missed");
            Console.ReadLine();
        } else {
            enemyHealth -= equipedAttacks[attackUsed-1];
            Console.WriteLine("You hit! Dealing "+equipedAttacks[attackUsed-1]+" dmg!");
            Console.ReadLine();
        }
    }
}


void attackMeny(){                                                                       //Gör menyn som visar vad man kan attakera med
        Console.Clear();
        Console.WriteLine("+-----------------------+");
        Console.WriteLine("|   -Equiped Attacks-   |");
        Console.WriteLine("|                       |");
        for(int menyLine = 0; menyLine != equipedAttacks.Length; menyLine++){
            string[] tempEquip = equipmentDbString[equipedAttacks[menyLine]].Split('|'); //tar alla equiped attacker och gör dem användbara
            string lineFiller= "                    ";
            lineFiller = lineFiller.Substring(0, 20-tempEquip[0].Length);                //checks lenght of equipment name
            Console.WriteLine("| "+(menyLine+1)+":"+tempEquip[0]+lineFiller+"|");        // loads the name of the equipment from the DBstring with the id from equipedattacks string
        }
        Console.WriteLine("|                       |");
        Console.WriteLine("+-----------------------+");
    }





int StrToInt(string text){     
    int ParsedNumber;                                   //checks if the string can be used with int.parse
    if (int.TryParse(text,out ParsedNumber)==true){    //and if it can it does, otherwise it returns a 0
        return ParsedNumber;
    } else {
        return 0;
    }
}


void figthingSytlesMeny(){                    //Gör menyn som visar vad man den innehåller --kan attakera med--
    int useless;                              //Variable needed for int.TryParse, not used anywhere else but to make it happy
    int i3 = 0;
    for(int i=0; i<4; i++){                   // Lägger till lvl i roman nummer i slutet av namnen, funkar inte för mer än 3
        string TempStyleLvl = " ";
        for(int i2=0; i2<int.Parse(fightingStylesLearned[i,1]); i2++){
            TempStyleLvl=TempStyleLvl.Insert(TempStyleLvl.Length,"I");
        }
        fightingStylesLearned[i,0] = fightingStylesLearned[i,0].Insert(fightingStylesLearned[i,0].Length, TempStyleLvl);  //Adds the lvl values to the end of the name temporarily for the purpose of the meny
    }
    
    //Console.Clear();
    Console.WriteLine("+-----------------------+");
    Console.WriteLine("|   -Fighting Styles-   |");
    Console.WriteLine("|                       |");
    //for(int menyLine = 0; menyLine != fightingStylesLearned.Length-1; menyLine++){
        //string[] tempEquip = DBString[idString[menyLine]].Split('|');                //tar alla equiped attacker och gör dem användbara
    foreach(string menyLine in fightingStylesLearned){
        if(int.TryParse(menyLine,out useless)==false){     //int.TryParse used to filter the names of the styles from thier levels
        int i=1;
        string lineFiller= "                    ";
        lineFiller = lineFiller.Substring(0, 20-menyLine.Length);                //checks lenght of equipment name
        Console.WriteLine("| "+i+":"+menyLine+lineFiller+"|");        // loads the name of the equipment from the DBstring with the id from equipedattacks string
        i++;
        }
    }
    Console.WriteLine("|                       |");
    Console.WriteLine("+-----------------------+");
    foreach(string menyLine in fightingStylesLearned){  //städar upp namnen när menyn är klar
                                              //int i, håller koll på vilka namn den har redan gått över
        if(int.TryParse(menyLine,out useless)==false){  //kollar om det är ett namn som den har i minne just nu
            fightingStylesLearned[i3,0] = menyLine.Remove(menyLine.Length-int.Parse(fightingStylesLearned[i3,1])-1);
            i3++;                                        //^tar bort lvl+1 antal charaktärer i slutet av namnet, som borde bara var ett mällenslag och lvl
        }
    }
}

void actionStyleChange(){
    //int styleChangedTo = StrToInt(Console.ReadLine());
    int styleChangedTo = 2;
    if(styleChangedTo==0){

    } else {
        
        string[] tempStyleData = fightingStylesDBString[int.Parse(fightingStylesLearned[styleChangedTo-1,2])].Split("|");    //DBstring[idnummer från Learned[vadman vill byta till, id nummer plats i array]]
        //ger data i ett {"namn","x1,y1","x2,y2","x3,y2"} format.
        string tempStyleDatalevel = tempStyleData[int.Parse(fightingStylesLearned[styleChangedTo,2])];
        int tempNum = tempStyleDatalevel.IndexOf(",")+1;
        fightingStyle[0] = int.Parse(tempStyleDatalevel.Substring(0, tempStyleDatalevel.Length-tempNum));
        fightingStyle[1] = int.Parse(tempStyleDatalevel.Substring(tempNum, tempStyleDatalevel.Length-tempNum));
    
    }
}

End:
Console.ReadLine();