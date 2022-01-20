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
    static public bool GoBack(int windowWidth){        //Had to use this identical funciton for so many loops, so i made it a function
        Console.WriteLine("Go back? y/n".PadRight(windowWidth/2 - 6));
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
    // static public string PadSpread(string str, int desiredLength){  // for some odd cases where i wasnt stuff   spread   out 
    //     string[] words = str.Split(" ");
    //     if(words.Length < 2){
    //         return PadEqual(str, desiredLength);
    //     } else {
    //         string pad = "";
    //         for(int i = 0; i < (desiredLength-str.Length+words.Length-1)/words.Length-2; i++){  //while the string isnt right length, add " "
    //             pad = pad + " ";
    //         }
    //         string paddedString = String.Join(pad, words);
    //         if(paddedString.Length != desiredLength){  //if desired lenght was odd in numbered length, this might be needed every now and then.
    //             paddedString = paddedString.Insert(paddedString.Length/2, " ");
    //         }
    //         return paddedString;
    //     }
    // }

    static public string MiscInvList(int windowWidth, string name, string type = "all", string slotType = "", bool count = false, string[] extraText = null){
        List<int> invType = new List<int>();
        for(int i = 0; i < InventoryLists.miscInventory.Count; i++){
            if(type == "all"){
                invType.Add(i);
            }else if(InventoryLists.FetchMiscType(i)==type){
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
            BoxBorder(windowWidth);
            Console.WriteLine($"|{PadEqual($"--={name}=--", windowWidth-2)}|");
            if(invLength == 0){
                Console.WriteLine("|            -=Empty=-            |");   //if there are no items in Misc inv
            } else if(count==false){    //if there are items in MiscInv && we don't want the number of items
                Console.WriteLine("| Page: "+(page+1)+"                         |");
                if(invLength<12){  //if there are less than 12/1 page of items. 1 page = 12 items
                    for(int i = 0; i < invLength; i++){
                        Console.WriteLine($"| {slotType}{i+1}: {InventoryLists.FetchMiscName(invType[i])}".PadRight(windowWidth-1)+"|");
                    }
                } else if(invLength-page*12>12){   //when there are more than 12 items but not on the last page
                    for(int i = 0; i < 12; i++){
                        Console.WriteLine($"| {slotType}{i+1+(page*12)}: {InventoryLists.FetchMiscName(invType[i]+(page*12))}".PadRight(windowWidth-1)+"|");
                    }
                } else {    //more than 12 items, on the last page. Have to make it like this to keep the var within List lenght
                    for (int i = 0; i < invLength%12; i++){
                        Console.WriteLine($"| {slotType}{i+1+(page*12)}: {InventoryLists.FetchMiscName(invType[i]+(page*12))}".PadRight(windowWidth-1)+"|");
                    }
                }
            } else if(count==true){    //if there are items in MiscInv && we do want the number of items
                Console.WriteLine("| Page: "+(page+1)+"                         |");
                if(invLength<12){  //if there are less than 12/1 page of items. 1 page = 12 items
                    for(int i = 0; i < invLength; i++){
                        Console.WriteLine($"| {slotType}{i+1}: {InventoryLists.FetchMiscName(invType[i])} * {InventoryLists.FetchMiscAmount(invType[i])}".PadRight(windowWidth-1)+"|");
                    }
                } else if(invLength-page*12>12){   //when there are more than 12 items but not on the last page
                    for(int i = 0; i < 12; i++){
                        Console.WriteLine($"| {slotType}{i+1+(page*12)}: {InventoryLists.FetchMiscName(invType[i]+(page*12))} * {InventoryLists.FetchMiscAmount(invType[i]+(page*12))}".PadRight(windowWidth-1)+"|");
                    }
                } else {    //more than 12 items, on the last page. Have to make it like this to keep the var within List lenght
                    for (int i = 0; i < invLength%12; i++){
                        Console.WriteLine($"| {slotType}{i+1+(page*12)}: {InventoryLists.FetchMiscName(invType[i]+(page*12))} * {InventoryLists.FetchMiscAmount(invType[i]+(page*12))}".PadRight(windowWidth-1)+"|");
                    }
                }
            }
            BoxBorder(windowWidth);
            if(invLength == 0){
                answer = Console.ReadLine();
            } else {
                string[] temp = MovePage(page, pageTotal, windowWidth, extraText).Split("|");
                if(temp[0] == "p"){
                    page = int.Parse(temp[1]);
                } else {
                    answer = temp[1];
                return answer;
                }
            }
        }
        return "no";
    }

    static public string MovePage(int page, int pageTotal, int windowWidth, string[] extraText = null){
        if(pageTotal > 0){
            Console.WriteLine("        Move between pages");
            Console.WriteLine("       by typing '<' or '>'");
            if(extraText != null){
                for(int i = 0; i < extraText.Length; i++){
                    Console.WriteLine(PadEqual(extraText[i], windowWidth));
                }
            }
        }
        string answer = Console.ReadLine();
        if(pageTotal > 0 && (answer == "<" || answer == ">")){
            if(answer == "<"){
                if(page == 0){
                    Console.WriteLine("You're on the first page.");
                    Console.ReadKey();
                } else {
                    page--;
                    return $"p|{page}";
                }
            } else if(answer == ">"){
                if(page == pageTotal){
                    Console.WriteLine("You're on the last page.");
                    Console.ReadKey();
                } else {
                    page++;
                    return $"p|{page}";
                }
            }
        }
        return $"a|{answer}";
    }

    static public void TextBox(string textInput, int windowWidth = 35, string padDir = "equal"){
        BoxBorder(windowWidth);
        BoxLine(textInput, windowWidth, padDir);
        BoxBorder(windowWidth);
    }
    static public void BoxBorder(int windowWidth){  //replaces Console.WriteLine("+------------=========------------+"); because of variable window width for non-simple text boxes
        string border ="++";
        int thickLength = windowWidth/4;
        if((windowWidth%4)%2 != 0 && thickLength%2 == 0){
            thickLength = thickLength + 1;
        }
        // Console.WriteLine(windowWidth/4 +" "+ windowWidth%4);
        bool ongoing = true;
        while(ongoing){
            if(border.Length < (windowWidth/2) - thickLength/2){
                // Console.WriteLine("start thin");
                border = border.Insert(border.Length-1, "-");
            } else if(border.Length > (windowWidth/2) + thickLength/2){
                // Console.WriteLine("end thin");
                border = border.Insert(border.Length-1, "-");
            } else {
                // Console.WriteLine("thick");
                border = border.Insert(border.Length-1, "=");
            }
            if(border.Length == windowWidth){
                ongoing = false;
            }
        }
        Console.WriteLine(border);
    }
    static public void BoxLine(string textInput, int windowWidth = 35, string padDir = "right"){  // needed because of special boxes
        int wordCount = 0;
        bool ongoing = true;
        bool force = false;
        List<string> text = new List<string>();
        string[] textWIP = textInput.Split(" ");
        string textInternal = "";
        while(ongoing){
            if(textInternal.Length == 0){  //if it's the first "word"
                textInternal = textInternal.Insert(0, textWIP[wordCount]);
                wordCount++;
            } else {  //otherwise it adds an " " at the beggining of a word.
                textInternal = textInternal.Insert(textInternal.Length, " "+textWIP[wordCount]);
                wordCount++;
            }
            if(textInternal.Length > windowWidth-4){  //Checks if the current line is too big/ bigger than the wanted window width
                wordCount--;
                textInternal = textInternal.Remove(textInternal.Length-textWIP[wordCount].Length-1);
                text.Add(textInternal);
                textInternal = "";
                // Console.WriteLine("line"+text.Count+" is finished");
            }
            if(wordCount == textWIP.Length){ // checks if it is the last word of the text input
                // Console.WriteLine("last line finished");
                text.Add(textInternal);
                ongoing=false;
            } else if(textInternal.Contains(".") || force){
                text.Add(textInternal);
                textInternal = "";
                force = false;
            } else if(textInternal.Contains("?")){
                force = true;
            }
        }
        switch(padDir.ToLower()){
            case "right":
                foreach(string output in text){
                    Console.WriteLine("| "+output.PadRight(windowWidth-4)+" |");
                }
                break;
            
            case "left":
                foreach(string output in text){
                    Console.WriteLine("| "+output.PadRight(windowWidth-4)+" |");
                }
                break;

            // case "spread":
            //     foreach(string output in text){
            //         Console.WriteLine("| "+PadSpread(output,windowWidth-2)+" |");
            //     }
            //     break;

            case "equal":
                foreach(string output in text){
                    Console.WriteLine("| "+PadEqual(output, windowWidth-4)+" |");
                }
                break;
            
            default:
                Console.WriteLine("| "+text+" |");
                break;
        }
    }   
}