using System;
using System.Collections.Generic;
using System.Linq;

public static class SecretHandshake
{
    public static  readonly  string[] encodeTable = new string[]
    {
        "wink",
        "double blink",
        "close your eyes",
        "jump",
        "Reverse the order of the operations in the secret handshake."
    };

    public static readonly int MaxCommandValue = 1 << (encodeTable.Length - 1);

    public static string[] Commands(int commandValue)
    {
        bool needToRevertCommands = false;

        if (commandValue >= MaxCommandValue)
        {
            needToRevertCommands = true;
            commandValue -= MaxCommandValue;
        }

        IEnumerable<string> commands = GetCommands(commandValue);

        return needToRevertCommands ? commands.Reverse().ToArray() : commands.ToArray();
    }

    private static IEnumerable<string> GetCommands(int commandValue)
    {
        return commandValue
                     .ToBinary()
                     .Select((c, idx) => c == 1 ? encodeTable[idx] : "")
                     .Where(word => word != "");
    }

    private static IEnumerable<string> GetCommands1(int commandValue)
    {
        return commandValue
                    .GetIndexesOfOnes()
                    .Select(i => encodeTable[i]);
    }

    private static IEnumerable<string> GetCommands2(int commandValue)
    {
        return Convert
                 .ToString(commandValue, 2)
                 .Reverse()
                 .Select((c, idx) => c == '1' ? encodeTable[idx] : "")
                 .Where(word => word != "");
    }

    private static IEnumerable<int> ToBinary(this int number)
    {
        while(number != 0)
        {
            yield return number % 2;
            number /= 2;
        }
    }

    private static IEnumerable<int> GetIndexesOfOnes(this int number)
    {
        int index = 0;

        while(number != 0)
        {
            if(number % 2 == 1) 
                yield return index;
            number /= 2;
            index++;
        }
    }
}
