using System;
using System.Collections.Generic;

public class miscFunctions{
    static public Random genRandom = new Random();

    static public int StrToInt(string text){
        int ParsedNumber;                                     //checks if the string can be used with int.parse
        if (int.TryParse(text, out ParsedNumber) == true){    //and if it can it does, otherwise it returns a 0
            return ParsedNumber;
        } else {
            return 0;
        }
    }
    static public bool GoBack(){        //Had to use this identical funciton for so many loops, so i made it a function
        Console.WriteLine("           Go back? y/n");
        string answer = Console.ReadLine().ToLower();
        if(answer == "y" || answer == "yes"){
            return false;
        } else {
            return true;
        }
    }

    static public string PadEqual(string str, int desiredLength){   // if i have padRight and padLeft, why cant i have PadEqual
        string paddedString=str.PadLeft(((desiredLength-str.Length)/2)+str.Length);//Pads the left side, half of the total pad
        return paddedString.PadRight(desiredLength);                               //Pads the right side, other half of the total pad
    }

    static public string MiscInvList(int windowWidth, string name, int player, string type = "all", string slotType = "", bool count = false, string[] extraText = null){
        List<int> invType = new List<int>();
        for(int i = 0; i < Inventory.InvLists[player].miscInventory.Count; i++){
            if(type == "all"){
                invType.Add(i);
            }else if(Inventory.InvLists[player].FetchMiscType(i)==type){
                invType.Add(i);
            }
        }
        bool ongoing = true;
        int invLength = invType.Count;
        string answer;
        int page=0;                                    //Keeps track of what page you're on
        int pageTotal=(invLength/12);                  //Keeps track of how many pages your inventory has
        while(ongoing){
            Console.Clear();
            Console.WriteLine("+------------=========------------+");
            Console.WriteLine($"|{PadEqual($"--={name}=--", windowWidth-2)}|");
            if(invLength == 0){
                Console.WriteLine("|            -=Empty=-            |");   //if there are no items in Misc inv
            } else if(count==false){    //if there are items in MiscInv && we don't want the number of items
                Console.WriteLine("| Page: "+(page+1)+"                         |");
                if(invLength<12){  //if there are less than 12/1 page of items. 1 page = 12 items
                    for(int i = 0; i < invLength; i++){
                        Console.WriteLine($"| {slotType}{i+1}: {Inventory.InvLists[player].FetchMiscName(invType[i])}".PadRight(windowWidth-1)+"|");
                    }
                } else if(invLength-page*12>12){   //when there are more than 12 items but not on the last page
                    for(int i = 0; i < 12; i++){
                        Console.WriteLine($"| {slotType}{i+1+(page*12)}: {Inventory.InvLists[player].FetchMiscName(invType[i]+(page*12))}".PadRight(windowWidth-1)+"|");
                    }
                } else {    //more than 12 items, on the last page. Have to make it like this to keep the var within List lenght
                    for (int i = 0; i < invLength%12; i++){
                        Console.WriteLine($"| {slotType}{i+1+(page*12)}: {Inventory.InvLists[player].FetchMiscName(invType[i]+(page*12))}".PadRight(windowWidth-1)+"|");
                    }
                }
            } else if(count==true){    //if there are items in MiscInv && we do want the number of items
                Console.WriteLine("| Page: "+(page+1)+"                         |");
                if(invLength<12){  //if there are less than 12/1 page of items. 1 page = 12 items
                    for(int i = 0; i < invLength; i++){
                        Console.WriteLine($"| {slotType}{i+1}: {Inventory.InvLists[player].FetchMiscName(invType[i])} * {Inventory.InvLists[player].FetchMiscAmount(invType[i])}".PadRight(windowWidth-1)+"|");
                    }
                } else if(invLength-page*12>12){   //when there are more than 12 items but not on the last page
                    for(int i = 0; i < 12; i++){
                        Console.WriteLine($"| {slotType}{i+1+(page*12)}: {Inventory.InvLists[player].FetchMiscName(invType[i]+(page*12))} * {Inventory.InvLists[player].FetchMiscAmount(invType[i]+(page*12))}".PadRight(windowWidth-1)+"|");
                    }
                } else {    //more than 12 items, on the last page. Have to make it like this to keep the var within List lenght
                    for (int i = 0; i < invLength%12; i++){
                        Console.WriteLine($"| {slotType}{i+1+(page*12)}: {Inventory.InvLists[player].FetchMiscName(invType[i]+(page*12))} * {Inventory.InvLists[player].FetchMiscAmount(invType[i]+(page*12))}".PadRight(windowWidth-1)+"|");
                    }
                }
            }
            Console.WriteLine("+------------=========------------+");
            if(invLength == 0){
                answer="0";
            } else {
                if(pageTotal != 0){
                    Console.WriteLine("        Move between pages");
                    Console.WriteLine("       by typing '<' or '>'");
                }
                if(extraText!=null){
                    for(int i = 0; i < extraText.Length; i++){
                        Console.WriteLine(PadEqual(extraText[i], windowWidth));
                    }
                }
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
            } else {
                return answer;
            }
        }
        return "no";
    }
}