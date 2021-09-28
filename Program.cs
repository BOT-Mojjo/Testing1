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
int[] equipedAttacks = new int[4]; // Current attacks the player has equiped
equipedAttacks[0]=1;
equipedAttacks[1]=0;
equipedAttacks[2]=0;
equipedAttacks[3]=0;
string[] equipmentDbString = File.ReadAllLines(@"Equipment.txt"); //loading ALL Equipment data into a variable
  
Start:
Console.WriteLine("RPG adventure of the CMD");
Console.WriteLine("  Write Start to Begin");
Console.WriteLine();
Console.WriteLine("Write Rules to learn how to play");

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
            enemyHealth = enemyHealth-1;
            Console.WriteLine("You hit! Dealing "+equipedAttacks[attackUsed-1]+" dmg!");
            Console.ReadLine();
        }
    }
}


void attackMeny(){    //Gör menyn som visar vad man kan attakera med
        Console.Clear();
        Console.WriteLine("+-----------------------+");
        Console.WriteLine("|   -Equiped Attacks-   |");
        Console.WriteLine("|                       |");
        for(int menyLine = 0; menyLine != equipedAttacks.Length; menyLine++){
            string[] tempEquip = equipmentDbString[equipedAttacks[menyLine]].Split('|'); //tar alla equiped attacker och gör dem användbara
            string lineFiller= "                    ";
            lineFiller = lineFiller.Substring(0, 20-tempEquip[0].Length); //checks lenght of equipment name
            Console.WriteLine("| "+(menyLine+1)+":"+tempEquip[0]+lineFiller+"|");// loads the name of the equipment from the DBstring with the id from equipedattacks string
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




End:
Console.ReadLine();