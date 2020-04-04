using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class CryptoSquare
{
        public static string NormalizedPlaintext(string plaintext)
        {
            return string.Concat(plaintext
                                    .ToLower()
                                    .Where(char.IsLetterOrDigit));
        }

        public static IEnumerable<string> PlaintextSegments(string plaintext, int chunks, int chunkLenght)
        {
            for (int i = 0; i < chunks; i++)
            {
                yield return plaintext.Substring(i * chunkLenght, chunkLenght);
            }
        }

        private static (int columns, int rows, int padding) CalculateSquareParams(string plaintext)
        {
            int column = (int)Math.Ceiling(Math.Sqrt(plaintext.Length));
            int row = (int)Math.Round((double)plaintext.Length / column);
            int padding = column * row - plaintext.Length;

            return (column, row, padding);
        }

        public static string Encoded(string plaintext, int row, int column)
        {
            char[] cipheredText = new char[plaintext.Length];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    cipheredText[j * row + i] = plaintext[i * column + j];
                }
            }

            return new String(cipheredText);
        }

        public static string Ciphertext(string plaintext)
        {
            string normalizedText = NormalizedPlaintext(plaintext);

            if (string.IsNullOrEmpty(normalizedText))
                return string.Empty;

            (int column, int row, int paddingCount) = CalculateSquareParams(normalizedText);
            
            string normalizedTextWithPadding = normalizedText.PadRight(normalizedText.Length + paddingCount);

            return string.Join(' ', PlaintextSegments(
                                            Encoded(normalizedTextWithPadding, row, column),
                                            chunks: column, 
                                            chunkLenght: row));
        }
}