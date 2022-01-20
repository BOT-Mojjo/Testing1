using System;
using System.IO;
using System.Collections.Generic;
static class Shops {
    static public List<assignments> assignmentList = new List<assignments>();
    static string answer;
    static int windowWidth = 35;
    public static void actionGuild(){ 
        bool ongoing = true;
        while (ongoing){   //Standard Meny layout and function, template är kopierad från inventory -- now a function
            Console.Clear();
            miscFunctions.BoxBorder(windowWidth);
            Console.WriteLine("|     --==Mercenary Guild==--     |");
            Console.WriteLine("|       1:Sell Animal Parts       |");
            Console.WriteLine("|    2:Collect Monster Bounties   |"); 
            Console.WriteLine("|          3:Assignments          |");
            miscFunctions.BoxBorder(windowWidth);
            bool ongoing1 = true;
            answer = Console.ReadLine();
            switch(miscFunctions.StrToInt(answer)){
                default:
                case 0:
                    ongoing = miscFunctions.GoBack(windowWidth);
                    break;
                case 1:
                    while(ongoing1){ //animal parts
                        answer = miscFunctions.MiscInvList(windowWidth, "Sell Animal Parts", "AnimalPart", "", true, new string[] {"Type the Parts Number", "to sell it."}); //find documentation in MiscFunctions.cs
                        List<int> part = new List<int>();  
                        for(int i = 0; i < InventoryLists.miscInventory.Count; i++){
                            if(InventoryLists.FetchMiscType(i)=="AnimalPart"){
                                part.Add(i);
                            }
                        }
                        //even though this code is technicaly redundant, i can't get the result from
                        //inside MiscInvList without annoying, though easily fixable  spaghetti complications
                        if(miscFunctions.StrToInt(answer) > 0 && miscFunctions.StrToInt(answer) < part.Count+1){
                            string answer2;
                            Console.Clear();
                            miscFunctions.BoxBorder(windowWidth);
                            Console.WriteLine("|"+miscFunctions.PadEqual("How many "+InventoryLists.FetchMiscName(part[int.Parse(answer)-1])+" do you", windowWidth-2)+"|");
                            Console.WriteLine("|          wish to sell?          |");
                            Console.WriteLine("|"+miscFunctions.PadEqual("1-"+InventoryLists.FetchMiscAmount(part[int.Parse(answer)-1]), windowWidth-2)+"|"); // 1-(amount of parts)
                            miscFunctions.BoxBorder(windowWidth);
                            answer2 = Console.ReadLine();
                            if(miscFunctions.StrToInt(answer2) > 0 && miscFunctions.StrToInt(answer2) <= InventoryLists.FetchMiscAmount(part[int.Parse(answer)-1])){ //if answer > 0 and < amount of parts
                                Inventory.partyCoins =+ (InventoryLists.FetchMiscCost(part[int.Parse(answer)-1])*miscFunctions.StrToInt(answer2))/2;  //curent gold + cost of part*amount of parts / 2
                                Console.Clear();
                                miscFunctions.BoxBorder(windowWidth);
                                Console.WriteLine("|"+miscFunctions.PadEqual($"You sold {int.Parse(answer2)} {InventoryLists.FetchMiscName(part[int.Parse(answer)-1])} for", windowWidth-2)+"|");
                                Console.WriteLine("|"+miscFunctions.PadEqual($"{InventoryLists.FetchMiscCost(part[int.Parse(answer)-1])*miscFunctions.StrToInt(answer2)/2} gold.", windowWidth-2)+"|");
                                miscFunctions.BoxBorder(windowWidth);
                                InventoryLists.RemoveMiscItem(part[int.Parse(answer)-1], false, int.Parse(answer2));
                                Console.ReadLine();
                            }
                        } else {
                            ongoing1 = miscFunctions.GoBack(windowWidth);
                        }
                    }
                    break;

                case 2:
                    while(ongoing1){  //Monster bounties, animal parts in disguise
                        answer = miscFunctions.MiscInvList(windowWidth, "Collect Bounties", "MonsterPart", "", true, new string[] {"Type the bounties Number", "to collect it."});
                        List<int> part = new List<int>();  
                        for(int i = 0; i < InventoryLists.miscInventory.Count; i++){
                            if(InventoryLists.FetchMiscType(i)=="MonsterPart"){
                                part.Add(i);
                            }
                        }
                        //even though this code is technicaly redundant, i can't get the result from
                        //inside MiscInvList without annoying, though easily fixable  spaghetti complications
                        if(miscFunctions.StrToInt(answer) > 0 && miscFunctions.StrToInt(answer) < part.Count+1){
                            string answer2;
                            Console.Clear();
                            miscFunctions.BoxBorder(windowWidth);
                            Console.WriteLine("|"+miscFunctions.PadEqual("How many "+InventoryLists.FetchMiscName(part[int.Parse(answer)-1])+" do you", windowWidth-2)+"|");
                            Console.WriteLine("|         wish to turn in?        |");
                            Console.WriteLine("|"+miscFunctions.PadEqual("1-"+InventoryLists.FetchMiscAmount(part[int.Parse(answer)-1]), windowWidth-2)+"|"); // 1-(amount of parts)
                            miscFunctions.BoxBorder(windowWidth);
                            answer2 = Console.ReadLine();
                            if(miscFunctions.StrToInt(answer2) > 0 && miscFunctions.StrToInt(answer2) <= InventoryLists.FetchMiscAmount(part[int.Parse(answer)-1])){ //if answer > 0 and < amount of parts
                                Inventory.partyCoins =+ (InventoryLists.FetchMiscCost(part[int.Parse(answer)-1])*miscFunctions.StrToInt(answer2))/2;  //curent gold + cost of part*amount of parts / 2
                                Console.Clear();
                                miscFunctions.BoxBorder(windowWidth);
                                Console.WriteLine("|"+miscFunctions.PadEqual($"You turned in {int.Parse(answer2)} {InventoryLists.FetchMiscName(part[int.Parse(answer)-1])} for", windowWidth-2)+"|");
                                Console.WriteLine("|"+miscFunctions.PadEqual($"{InventoryLists.FetchMiscCost(part[int.Parse(answer)-1])*miscFunctions.StrToInt(answer2)/2} gold.", windowWidth-2)+"|");
                                miscFunctions.BoxBorder(windowWidth);
                                InventoryLists.RemoveMiscItem(part[int.Parse(answer)-1], false,  int.Parse(answer2));
                                Console.ReadLine();
                            }
                        } else {
                            ongoing1 = miscFunctions.GoBack(windowWidth);
                        }
                    }
                    break;

                case 3:  // Assignments. Will be identical in nature (and code(hopefully)) to the merchant guild.
                    while(ongoing1){
                        int listID = 0;
                        Console.Clear();
                        miscFunctions.BoxBorder(windowWidth);
                        Console.WriteLine("|   --=Mercenary Assignemnts=--   |");
                        Console.WriteLine("|   1:Check Current Assignments   |");
                        Console.WriteLine("|      2:See New Assignments      |");
                        miscFunctions.BoxBorder(windowWidth);
                        answer = Console.ReadLine();
                        switch(miscFunctions.StrToInt(answer)){
                            case 0:
                                ongoing1 = miscFunctions.GoBack(windowWidth);
                                break;

                            case 1:
                                int page=0;
                                int pageTotal = assignmentList.Count/12;
                                while(ongoing){
                                    Console.Clear();
                                    miscFunctions.BoxBorder(windowWidth);
                                    Console.WriteLine($"|{miscFunctions.PadEqual("Assignemnts", windowWidth-2)}|");
                                    if(assignmentList.Count == 0){
                                        Console.WriteLine("|            -=Empty=-            |");   //if there are no items in Misc inv
                                    } else{
                                        Console.WriteLine("| Page: "+(page+1)+"                         |");
                                        if(assignmentList.Count<12){  //if there are less than 12/1 page of items. 1 page = 12 items
                                            for(int i = 0; i < assignmentList.Count; i++){
                                                Console.WriteLine($"| {i+1}: {assignmentList[i]}".PadRight(windowWidth-1)+"|");
                                            }
                                        } else if(assignmentList.Count-page*12>12){   //when there are more than 12 items but not on the last page
                                            for(int i = 0; i < 12; i++){
                                                Console.WriteLine($"| {i+1+(page*12)}: {assignmentList[i+(page*12)]}".PadRight(windowWidth-1)+"|");
                                            }
                                        } else {    //more than 12 items, on the last page. Have to make it like this to keep the var within List lenght
                                            for (int i = 0; i < assignmentList.Count%12; i++){
                                                Console.WriteLine($"| {i+1+(page*12)}: {assignmentList[i+(page*12)]}".PadRight(windowWidth-1)+"|");
                                            }
                                        }
                                    }
                                    miscFunctions.BoxBorder(windowWidth);
                                    if(assignmentList.Count == 0){
                                        answer = Console.ReadLine();
                                    } else {
                                        string[] temp = miscFunctions.MovePage(page, pageTotal, windowWidth, new string[] {"Inspect an Assignment by", "inputting it's number instead"}).Split("|");
                                        if(temp[0] == "p"){
                                            page = int.Parse(temp[1]);
                                        } else {
                                            answer = temp[1];
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    break;
            }
        }
    }


    static void AddAssignment(int AssignmentID){
        string[] assignmentDBstring = File.ReadAllLines(@"Assignments.txt"); //loading ALL of Misc data into a variable
        string[] data = assignmentDBstring[AssignmentID].Split('|');
        assignmentList.Add(new assignments(){
            type = data[0],
            name = data[1],
            description = data[2],
            rewards = int.Parse(data[3]),
            requirements = new string[] {data[4], data[5]}
        });
            //WhatItIs|Name|Description|Cost|Requirements Type|Requirements Amount|
    }

    static void CompleteAssignemnt(int ListID){
        Inventory.partyCoins =+ assignmentList[ListID].rewards;
        InventoryLists.RemoveMiscItem(int.Parse(assignmentList[ListID].requirements[0]), false, int.Parse(assignmentList[ListID].requirements[1])); //Itemid, if it's an id to the inventory list, how many we remove
        miscFunctions.TextBox("You have completed your "+assignmentList[ListID]+" assignment!", windowWidth);
    }
}
                        // foreach(assignments line in assignmentList){
                        //     if (line.type == "Mercenary"){
                        //         listID++;
                        //         Console.WriteLine($"|{line.name.PadRight(windowWidth-2)}|");
                        //     }
                        // }