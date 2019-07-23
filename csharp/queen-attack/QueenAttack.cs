using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        return white.IsOnTheSameColumnWith(black) ||
               white.IsOnTheSameRowWith(black) ||
               white.IsOnTheSameDiagonalWith(black);    
    }


    public static bool IsOnTheSameColumnWith(this Queen queen, Queen otherQueen)
    {
        return queen.Column == otherQueen.Column;
    }

    public static bool IsOnTheSameRowWith(this Queen queen, Queen otherQueen)
    {
        return queen.Row == otherQueen.Row;
    }

    public static bool IsOnTheSameDiagonalWith(this Queen queen, Queen otherQueen)
    {
        return queen.Row - queen.Column == otherQueen.Row - otherQueen.Column ||
               queen.Row + queen.Column == otherQueen.Row + otherQueen.Column;
    }

    public static Queen Create(int row, int column)
    {
        if(row > 7 || row < 0 || column > 7 || column < 0)
            throw new ArgumentOutOfRangeException();

        return new Queen(row, column);
    }
}