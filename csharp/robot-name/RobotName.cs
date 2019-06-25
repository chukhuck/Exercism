using System;
using System.Linq;
using System.Collections.Generic;

public class Robot
{
    private static HashSet<int> Previous = new HashSet<int>();

    public const int MAX_NAME_COUNT = 26 * 26 * 10 * 10 *10;

    private static Random generator = new Random();

    private readonly char[] ALPHABET = new char[]
    {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 
        'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 
        'U', 'V', 'W', 'X', 'Y', 'Z'       
    };

    public int? ID {get; private set;}

    public string Name
    {
        get
        {
            return TranslateIdToName(ID ??  GenerateId() );
        }
    }

    private int GenerateId()
    {
        int tempID;
        do
        {
            tempID = generator.Next(MAX_NAME_COUNT);
        } while (Previous.Contains(tempID));
        
        ID = tempID;
        Previous.Add(tempID);

        return tempID;
    }

    public void Reset() => ID = null;

    private string TranslateIdToName(int id)
    {
        string reversedName = "";
        for (int i = 0; i < 3; i++)
        {
            reversedName += id % 10;
            id = id / 10;
        }

        reversedName += ALPHABET[id % 26];
        reversedName += ALPHABET[id / 26];

        return new string(reversedName.ToCharArray().Reverse().ToArray());
    }
}