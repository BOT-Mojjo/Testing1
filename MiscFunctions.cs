public class valueConvert{
    static public System.Random genRandom = new System.Random();

    static public int StrToInt(string text){
        int ParsedNumber;                                     //checks if the string can be used with int.parse
        if (int.TryParse(text, out ParsedNumber) == true){    //and if it can it does, otherwise it returns a 0
            return ParsedNumber;
        } else {
            return 0;
        }
    }
}