using System;
using System.Linq;

public static class RotationalCipher
{
    public const int ModuleOfRing = 26;

    public static string Rotate(string text, int shiftKey)
    {
        return string.Concat(text.Select(c => char.IsLetter(c) ? RotateChar(shiftKey, c) : c));
    }

    private static char RotateChar(int shiftKey, char c)
    {
        char nullOfRing = char.IsLower(c) ? 'a' : 'A';

        return (char)((c + shiftKey - nullOfRing) % ModuleOfRing + nullOfRing);
    }
}