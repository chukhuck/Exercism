using System;
using System.Linq;
using System.Collections.Generic;

public class Robot
{
    private static HashSet<int> Previous = new HashSet<int>();

    public const int MAX_NAME_COUNT = 26 * 26 * 10 * 10 *10;

    Random generator = new Random((int)DateTime.Now.Ticks * 3);

    public readonly char[] ALPHABET = new char[]
    {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 
        'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 
        'U', 'V', 'W', 'X', 'Y', 'Z'       
    };

    private int _id = -1;

    public string Name
    {
        get
        {
            if (_id == -1)
            {
                do
                {
                    _id = generator.Next(MAX_NAME_COUNT);
                } while (Previous.Contains(_id));
               Previous.Add(_id);
            }
            return TranslateIdToName(_id);
        }
    }

    public void Reset() => _id = -1;

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