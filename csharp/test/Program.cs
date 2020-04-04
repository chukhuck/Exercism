using System;
using System.Linq;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var plaintext = "If man was meant to stay on the ground, god would have given us roots.";

            Console.WriteLine(Ciphertext(plaintext));


        }

        public static string NormalizedPlaintext(string plaintext)
        {
            return string.Concat(plaintext
                                    .ToLower()
                                    .Where(char.IsLetterOrDigit));
        }

        public static IEnumerable<string> PlaintextSegments(string plaintext)
        {
            (int column, int row) = CalculateRowsAndColumns(plaintext);

            for (int i = 0; i < column; i++)
            {
                yield return plaintext.Substring(i * row, row);
            }
        }

        private static (int columns, int rows) CalculateRowsAndColumns(string plaintext)
        {
            int column = (int)Math.Ceiling(Math.Sqrt(plaintext.Length));

            return (column, (int)Math.Round((double)plaintext.Length / column));
        }

        public static string Encoded(string plaintext)
        {
            (int columnCount, int rowCount) = CalculateRowsAndColumns(plaintext);
            int paddingLenght = columnCount * rowCount - plaintext.Length;

            plaintext = plaintext.PadRight(plaintext.Length + paddingLenght);

            char[] cipheredText = new char[plaintext.Length];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    cipheredText[j * rowCount + i] = plaintext[i * columnCount + j];
                }
            }

            return new String(cipheredText);
        }

        public static string Ciphertext(string plaintext)
        {
            string normalizedText = NormalizedPlaintext(plaintext);

            if (string.IsNullOrEmpty(normalizedText))
                return string.Empty;

            return string.Join(' ', PlaintextSegments(Encoded(normalizedText)));
        }
    }

}
