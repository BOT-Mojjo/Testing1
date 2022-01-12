using System;
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
    static public bool GoBack(){
        Console.WriteLine("           Go back? y/n");
        string answer = Console.ReadLine().ToLower();
        if(answer == "y" || answer == "yes"){
            return false;
        } else {
            return true;
        }
    }

    static public string PadEqual(string str, int desiredLength){
        string paddedString=str.PadLeft(((desiredLength-str.Length)/2)+str.Length);
        return paddedString.PadRight(desiredLength);
    }
}