using System;
using System.IO;
using System.Collections.Generic;
Fight.ongoing=false;
int hadEnough = 0;
string playerName;


InventoryLists.inventorySetup();
FightingStyles.fightingStyleSetup();
Inventory.actionInventory();


Start:
Console.WriteLine("RPG adventure of the CMD");
Console.WriteLine("  Write Start to Begin");
Console.WriteLine();
//Console.WriteLine("Write Rules to learn how to play");

Choices:
string WhatPlayerDid = Console.ReadLine().ToLower(); //lets the player choose between starting,
if (WhatPlayerDid == "start"){              //checking how the game works,
    goto StartOfAdventure;                 //and for those who can't follow instructions.
} else if (WhatPlayerDid == "Rules"){
    Console.WriteLine("u moma");

    Console.ReadLine();
    goto Start;
} else {
    if (hadEnough > 5){
        Console.WriteLine("You're supposed to write 'Start' nothing else.");
        Console.WriteLine("You can do it, c'mon");
        string death = Console.ReadLine().ToLower();
        if (death == "start"){
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
player.name = Console.ReadLine();
Console.WriteLine();
while(player.name.Length>15){
    Console.WriteLine("Would you happen to have a shorter nickname?");
    Console.WriteLine();
    playerName=Console.ReadLine();
}

//tutorial
Console.WriteLine("I see. Good luck on your Journey, " + player.name + ".");
Console.ReadLine();
Console.Clear();
Console.WriteLine("As you set out on your Journey, your first steps lead you to The Peaceful Plains");
Console.WriteLine("Before you a little Bunny's jumping around.");
Console.ReadLine();

End:
Console.ReadLine();