using System;
using System.IO;
using System.Collections.Generic;
static class Shops {
    static public List<assignments> assignmentList = new List<assignments>();
    static string answer;
    static  public int windowWidth = 35;
    public static void actionGuild(){ 
        AddAssignment(0);
        AddAssignment(2);
        bool ongoing = true;
        while (ongoing){   //Standard Meny layout and function, template är kopierad från inventory -- now a function
            Console.Clear();
            // miscFunctions.BoxBorder(windowWidth);
            // Console.WriteLine("|     --==Mercenary Guild==--     |");
            // Console.WriteLine("|       1:Sell Animal Parts       |");
            // Console.WriteLine("|    2:Collect Monster Bounties   |"); 
            // Console.WriteLine("|          3:Assignments          |");
            // miscFunctions.BoxBorder(windowWidth);
            miscFunctions.TextBox("(--==Mercenary Guild==--) (1:Sell Animal Parts) (2:Collect Monster Bounties) (3:Assignments)", windowWidth);
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
                        List<int> part = miscFunctions.MiscInvListType("AnimalPart");
                        //even though this code is technicaly redundant, i can't get the result from            //Redacted: made a function of it since i'll need it for
                        //inside MiscInvList without annoying, though easily fixable  spaghetti complications   //later actions anyway
                        if(miscFunctions.StrToInt(answer) > 0 && miscFunctions.StrToInt(answer) < part.Count+1){
                            string answer2;
                            int amount = InventoryLists.FetchMiscAmount(part[int.Parse(answer)-1]);  //cleaning up the amount of calls to fetch amount and names of items
                            int cost = InventoryLists.FetchMiscCost(part[int.Parse(answer)-1]);
                            string name = InventoryLists.FetchMiscName(part[int.Parse(answer)-1]);
                            Console.Clear();
                            miscFunctions.TextBox("How many " + name + " do you widh to sell? 1-"+amount, windowWidth);
                            answer2 = Console.ReadLine();
                            if(miscFunctions.StrToInt(answer2) > 0 && miscFunctions.StrToInt(answer2) <= amount){ //if answer > 0 and < amount of parts
                                Inventory.partyCoins =+ (cost*int.Parse(answer2))/2;  //curent gold + cost of part*amount of parts / 2
                                Console.Clear();
                                miscFunctions.TextBox($"You sold {int.Parse(answer2)} {name} for {cost*int.Parse(answer2)/2} gold.", windowWidth);
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
                        List<int> part = miscFunctions.MiscInvListType("MonsterPart");
                        if(miscFunctions.StrToInt(answer) > 0 && miscFunctions.StrToInt(answer) < part.Count+1){
                            string answer2;
                            int amount = InventoryLists.FetchMiscAmount(part[int.Parse(answer)-1]);  //cleaning up the amount of calls to fetch amount and names of items
                            int cost = InventoryLists.FetchMiscCost(part[int.Parse(answer)-1]);
                            string name = InventoryLists.FetchMiscName(part[int.Parse(answer)-1]);
                            Console.Clear();
                            miscFunctions.TextBox("How many " + name + " do you to turn in? 1-"+amount, windowWidth);
                            answer2 = Console.ReadLine();
                            if(miscFunctions.StrToInt(answer2) > 0 && miscFunctions.StrToInt(answer2) <= amount){ //if answer > 0 and < amount of parts
                                Inventory.partyCoins =+ (cost*int.Parse(answer2))/2;  //curent gold + cost of part*amount of parts / 2
                                Console.Clear();
                                miscFunctions.TextBox($"You turned in {int.Parse(answer2)} {name} for {cost*int.Parse(answer2)/2} gold.", windowWidth);
                                InventoryLists.RemoveMiscItem(part[int.Parse(answer)-1], false, int.Parse(answer2));
                                Console.ReadLine();
                            }
                        } else {
                            ongoing1 = miscFunctions.GoBack(windowWidth);
                        }
                    }
                    break;

                case 3:  // Assignments. Will be identical in nature (and code(hopefully)) to the merchant guild.
                    while(ongoing1){
                        Console.Clear();
                        // miscFunctions.BoxBorder(windowWidth);
                        // Console.WriteLine("|   --=Mercenary Assignments=--   |");
                        // Console.WriteLine("|   1:Check Current Assignments   |");
                        // Console.WriteLine("|      2:See New Assignments      |");
                        // miscFunctions.BoxBorder(windowWidth);
                        miscFunctions.TextBox("(--=Mercenary Assignments=--) (1:Check Current Assignments) (2:See New Assignments)", windowWidth);
                        answer = Console.ReadLine();
                        int intAnswer;
                        int.TryParse(answer, out intAnswer);
                        if(intAnswer == 1){
                            int page=0;
                            List<assignments> tempMercenary = new List<assignments>();
                            for(int i = 0; i != assignmentList.Count; i++){
                                if(assignmentList[i].type == "Mercenary"){
                                    tempMercenary.Add(assignmentList[i]);
                                }
                            }
                            int pageTotal = tempMercenary.Count/12;
                            while(ongoing){
                                Console.Clear();
                                miscFunctions.BoxBorder(windowWidth);
                                miscFunctions.BoxLine("-~Assignments~-", windowWidth, "equal");
                                if(tempMercenary.Count == 0){
                                    miscFunctions.BoxLine("-=Empty=-", windowWidth, "equal");   //if there are no items in Misc inv
                                } else{
                                    if(pageTotal==1){
                                        miscFunctions.BoxLine("Page: "+(page+1), windowWidth);
                                    }
                                    if(tempMercenary.Count<12){  //if there are less than 12/1 page of items. 1 page = 12 items
                                        for(int i = 0; i < tempMercenary.Count; i++){
                                            miscFunctions.BoxLine($"{i+1}: {tempMercenary[i].name}", windowWidth);
                                        }
                                    } else if(tempMercenary.Count-page*12>12){   //when there are more than 12 items but not on the last page
                                        for(int i = 0; i < 12; i++){
                                            miscFunctions.BoxLine($"{i+1+(page*12)}: {tempMercenary[i+(page*12)].name}", windowWidth);
                                        }
                                    } else {    //more than 12 items, on the last page. Have to make it like this to keep the var within List lenght
                                        for (int i = 0; i < tempMercenary.Count%12; i++){
                                            miscFunctions.BoxLine($"{i+1+(page*12)}: {tempMercenary[i+(page*12)].name}", windowWidth);
                                        }
                                    }
                                }
                                miscFunctions.BoxBorder(windowWidth);
                                if(tempMercenary.Count == 0){
                                    ongoing = miscFunctions.GoBack(windowWidth);
                                } else {
                                    string[] temp = miscFunctions.MovePage(page, pageTotal, windowWidth, new string[] {"Inspect an Assignment by", "inputting it's number instead"}).Split("|");
                                    if(temp[0] == "p"){
                                        page = int.Parse(temp[1]);
                                    } else {
                                        answer = temp[1];
                                    }
                                    int tempAnswer = miscFunctions.StrToInt(answer);
                                    if(tempAnswer == 0){
                                        ongoing = miscFunctions.GoBack(windowWidth);
                                    } else {
                                    tempAnswer--;
                                    Console.Clear();
                                    miscFunctions.TextBox("(--=" + tempMercenary[tempAnswer].name + "=--) " + tempMercenary[tempAnswer].description + " (Reward: " + tempMercenary[tempAnswer].rewards+" gold.) (Requirement for completion: " + tempMercenary[tempAnswer].requirements[1] + " " + InventoryLists.FetchMiscName(int.Parse(tempMercenary[tempAnswer].requirements[0])) + "s.)", windowWidth);
                                    /* what that 400 charachters of code does. god help me make shorter variable names
                                    +---------------------------------+
                                    |    --=[name of assignment]=--   |
                                    |   [Description of assignment]   |
                                    |             [Reward]            |
                                    |    [Requirment of Completion]   |
                                    +---------------------------------+
                                    */
                                    Console.ReadLine();
                                    }
                                }
                            }
                        } else if(intAnswer == 2){
                            //TODO: when world gen / biomes are complete finish this, generation of assignments
                        } else {
                            ongoing1 = miscFunctions.GoBack(windowWidth);
                        }
                    }
                    break;
                }
        }
    }
    


    static void AddAssignment(int AssignmentID){
        string[] assignmentDBstring = File.ReadAllLines(@"Assignments.txt"); //loading ALL of assignmrnts data into a variable
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
        miscFunctions.TextBox("You have completed your "+assignmentList[ListID].name+" assignment!", windowWidth);
        assignmentList.RemoveAt(ListID);
        Console.ReadLine();
    }

    static void RemoveAssignment(int ListID){
        miscFunctions.TextBox("You have chosen to abandon your \""+assignmentList[ListID].name+"\" assignment.", windowWidth);
        assignmentList.RemoveAt(ListID);
        Console.ReadLine();
    }
}
                        // foreach(assignments line in assignmentList){
                        //     if (line.type == "Mercenary"){
                        //         listID++;
                        //         Console.WriteLine($"|{line.name.PadRight(windowWidth-2)}|");
                        //     }
                        // }